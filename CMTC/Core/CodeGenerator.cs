// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="CodeGenerator.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Antlr4.StringTemplate;
using CMTC.Core.Extensions;
using CMTC.Core.SymTable;
using CMTC.Core.SymTable.Models;
using CMTC.Utilities;
using System.Collections.Generic;
using static CMTC.Core.SymTable.Models.Expression;
using static CMTC.Core.SymTable.Symbol;
using static CymbolParser;

/// <summary>
/// The Core namespace.
/// </summary>
namespace CMTC.Core
{
    /// <summary>
    /// Class CodeGenerator.
    /// </summary>
    /// <seealso cref="CymbolBaseVisitor{Antlr4.StringTemplate.Template}" />
    class CodeGenerator : CymbolBaseVisitor<Template>
    {
        /// <summary>
        /// The templates
        /// </summary>
        private readonly Stack<Template> _templates = new Stack<Template>();

        /// <summary>
        /// The expression results
        /// </summary>
        private readonly Stack<Expression> _expressionResults = new Stack<Expression>();

        /// <summary>
        /// The pairs
        /// </summary>
        private readonly Dictionary<string, Symbol> _pairs = new Dictionary<string, Symbol>();

        /// <summary>
        /// The global
        /// </summary>
        private readonly IScope _globalScope;

        /// <summary>
        /// The current scope
        /// </summary>
        private IScope _currentScope;

        private bool _negateComparision = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeGenerator" /> class.
        /// </summary>
        /// <param name="global">The global.</param>
        public CodeGenerator(IScope global)
        {
            _globalScope = global;
            _currentScope = global;
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.file" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>Template.</returns>
        /// <return>The visitor result.</return>
        public override Template VisitFile([NotNull] CymbolParser.FileContext context)
        {
            // push initial file template
            _templates.Push(TemplateManager.GetTemplate("file"));

            // loop through all global variable declarations
            foreach (var c in context.varDecl())
            {
                _templates.Peek().Add("symbols", VisitVarDecl(c));
            }

            // loop through all function declarations
            foreach (var c in context.functionDecl())
            {
                _templates.Peek().Add("symbols", VisitFunctionDecl(c));
            }

            // pop file template
            return _templates.Pop();
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.varDecl" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>Template.</returns>
        /// <return>The visitor result.</return>
        public override Template VisitVarDecl([NotNull] CymbolParser.VarDeclContext context)
        {
            return TemplateManager.SymbolDeclaration(
                _currentScope.GetSymbol(context.ID().GetText()).UpdateIndex(_currentScope.IncreasedIndex())
            );
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.functionDecl" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>Template.</returns>
        /// <return>The visitor result.</return>
        public override Template VisitFunctionDecl([NotNull] CymbolParser.FunctionDeclContext context)
        {
            //update current scope
            _currentScope = _globalScope.GetMethod(context.ID().GetText());

            return TemplateManager.FunctionDeclaration((MethodSymbol)_globalScope.GetMethod(context.ID().GetText()))
                .Add("block", VisitBlock(context.block()));
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.block" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>Template.</returns>
        /// <return>The visitor result.</return>
        public override Template VisitBlock([NotNull] CymbolParser.BlockContext context)
        {
            var stats = new List<Template>();
            if (context.stat() != null)
            {
                foreach (var c in context.stat())
                {
                    stats.Add(Visit(c));
                }
            }

            return TemplateManager.Block(stats);
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.stat" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>Template.</returns>
        /// <return>The visitor result.</return>
        public override Template VisitStat([NotNull] CymbolParser.StatContext context)
        {
            var template = TemplateManager.GetTemplate("statement");

            if (context.expr() != null)
                template.Add("statement", VisitExpr(context.expr()));

            if (context.returnStat() != null)
                template.Add("statement", VisitReturnStat(context.returnStat()));

            if (context.varDecl() != null)
                template.Add("statement", VisitVarDecl(context.varDecl()));

            if (context.assignStat() != null)
                template.Add("statement", VisitAssignStat(context.assignStat()));

            if (context.block() != null)
                template.Add("statement", VisitBlock(context.block()));

            if (context.printStat() != null)
                template.Add("statement", VisitPrintStat(context.printStat()));

            if (context.ifStat() != null)
                template.Add("statement", VisitIfStat(context.ifStat()));

            if (context.forStat() != null)
                template.Add("statement", VisitForStat(context.forStat()));

            return template;
        }

        #region statements

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.returnStat" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>Template.</returns>
        /// <return>The visitor result.</return>
        public override Template VisitReturnStat([NotNull] CymbolParser.ReturnStatContext context)
        {
            // return single integer - no expression
            if (context.expr().IsInteger())
            {
                int.TryParse(context.expr().INT().GetText(), out var integer);
                return TemplateManager.PlainReturnStatement(integer);
            }

            // return single identifier - no expression
            if (context.expr().IsIdentifier())
            {
                dynamic target = null;
                dynamic source = null;

                var identifier = context.expr().GetText();
                var template = TemplateManager.ReturnStatement(_currentScope.GetChild(0).GetSymbol(identifier));
                
                var isPointer = _currentScope.GetChild(0).GetSymbol(identifier).Type == SymbolType.INT_P;
                if (isPointer)
                {
                    target = new Symbol("result", _currentScope.IncreasedIndex(), SymbolType.INT);
                    source = _currentScope.GetSymbol(context.expr().ID().GetText());

                    _currentScope.GetChild(0).Define(target);

                    template = TemplateManager.ReturnStatement(
                        new Symbol(string.Empty, _currentScope.GetIndex(), SymbolType.INT));

                    template.Add("expression", TemplateManager.AssignStatement(target, source));
                }

                return template;
            }

            // return expression result
            var tmp = VisitExpr(context.expr());
            return TemplateManager.ReturnStatement(
                _expressionResults.Pop().Value)
                .Add("expression", tmp);
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.assignStat" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>Template.</returns>
        /// <return>The visitor result.</return>
        public override Template VisitAssignStat([NotNull] CymbolParser.AssignStatContext context)
        {
            var name = _currentScope.GetSymbol(context.ID().GetText()).Name;

            var expressionTemplate = VisitExpr(context.expr());
            var current = _currentScope.GetChild(0).GetSymbol(name);
            current.Type = SymbolType.INT_P;

            _currentScope.GetChild(0).Define(current);

            var expressionResult = _expressionResults.Pop();
            if (expressionResult.Type == ExprType.SYMBOL)
            {
                Symbol symbol = expressionResult.Value;
                if (symbol.Type == SymbolType.INT_P)
                {
                    var id = new ExprContext(context, 0);
                    id.AddChild(new TerminalNodeImpl(new CommonToken(ID, symbol.Name)));

                    expressionTemplate.Add("expr", VisitExpr(id));
                    return TemplateManager.StoreStatement(current, _expressionResults.Pop().Value).Add("expression", expressionTemplate);
                }
            }

            return TemplateManager.StoreStatement(current, expressionResult.Value).Add("expression", expressionTemplate);
        }

        public override Template VisitPrintStat([NotNull] CymbolParser.PrintStatContext context)
        {
            var expression = VisitExpr(context.expr());

            var index = _currentScope.IncreasedIndex();
            var symbol = new Symbol(string.Format("printf.{0}", index), index, SymbolType.INT);
            _currentScope.GetChild(0).Define(symbol);

            return TemplateManager.Printf(symbol, _expressionResults.Pop().Value).Add("expression", expression);
        }

        public override Template VisitIfStat([NotNull] CymbolParser.IfStatContext context)
        {
            // is IF-ELSE?
            var isIfElse = context.ChildCount > 5;

            // expression for IF
            var expr = VisitExpr(context.expr());

            // first jmp label
            var index = _currentScope.IncreasedIndex();
            var labelOnePlain = index;
            var labelOne = new Symbol(string.Format("label.{0}", index), index, SymbolType.LABEL);
            _currentScope.GetChild(0).Define(labelOne);

            // satement(s) for TRUE
            var ifStat = VisitStat(context.stat()[0]);

            // second jmp label
            index = _currentScope.IncreasedIndex();
            var labelTwoPlain = index;
            var labelTwo = new Symbol(string.Format("label.{0}", index), index, SymbolType.LABEL);
            _currentScope.GetChild(0).Define(labelTwo);

            Template elseStat = null;
            Symbol labelThird = null;
            var labelThirdPlain = 0;
            if (isIfElse)
            {
                // satement(s) for FALSE
                elseStat = VisitStat(context.stat()[1]);

                // second jmp label
                index = _currentScope.IncreasedIndex();
                labelThirdPlain = index;
                labelThird = new Symbol(string.Format("label.{0}", index), index, SymbolType.LABEL);
                _currentScope.GetChild(0).Define(labelThird);
            }

            // finished IF
            var template = TemplateManager.Condition(isIfElse)
                .Add("expr", expr)
                .Add("exprResult", _expressionResults.Pop().Value)
                .Add("ifStat", ifStat)
                .Add("first", labelOnePlain)
                .Add("second",labelTwoPlain)
                .Add("jmpFirst", !_negateComparision ? labelOnePlain : labelTwoPlain)
                .Add("jmpSecond", !_negateComparision ? labelTwoPlain : labelOnePlain);

            if (isIfElse)
            {
                template.Add("elseStat", elseStat).Add("third", labelThirdPlain);
            }

            _negateComparision = false;
            return template;
        }

        public override Template VisitForStat([NotNull] ForStatContext context)
        {
            var condition = context.expr();
            var initialAssign = VisitAssignStat(context.assignStat()[0]);
            var incrementAssign = context.assignStat()[1];

            // loop condition
            var index = _currentScope.IncreasedIndex();
            var headerPlain = index;
            var header = new Symbol(string.Format("label.{0}", index), index, SymbolType.LABEL);
            _currentScope.GetChild(0).Define(header);

            var headerExpr = VisitExpr(condition);
            var headerResult = _expressionResults.Pop().Value;
            
            // loop body
            index = _currentScope.IncreasedIndex();
            var bodyPlain = index;
            var body = new Symbol(string.Format("label.{0}", index), index, SymbolType.LABEL);
            _currentScope.GetChild(0).Define(body);

            var bodyStat = VisitBlock(context.block());
            
            // after-loop assigment
            index = _currentScope.IncreasedIndex();
            var footerPlain = index;
            var footer = new Symbol(string.Format("label.{0}", index), index, SymbolType.LABEL);
            _currentScope.GetChild(0).Define(footer);

            var footerStat = VisitAssignStat(incrementAssign);

            // exit
            index = _currentScope.IncreasedIndex();
            var exitPlain = index;
            var exit = new Symbol(string.Format("label.{0}", index), index, SymbolType.LABEL);
            _currentScope.GetChild(0).Define(exit);
            
            
            return TemplateManager.ForLoop()
                .Add("init", initialAssign)
                .Add("header", headerPlain)
                .Add("headerExpr", headerExpr)
                .Add("headerResult", headerResult)
                .Add("body", bodyPlain)
                .Add("bodyStat", bodyStat)
                .Add("footer", footerPlain)
                .Add("footerStat", footerStat)
                .Add("exit", exitPlain);
        }

        #endregion

        #region expression

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.expr" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>Template.</returns>
        /// <return>The visitor result.</return>
        public override Template VisitExpr([NotNull] CymbolParser.ExprContext context)
        {
            _templates.Push(TemplateManager.GetTemplate("expression"));

            // is plain integer?
            if (context.IsInteger())
            {
                // add plain integer to expression stack
                _expressionResults.Push(Expression.Create(context.INT().GetText()));
            }

            // is identifier?
            if (context.IsIdentifier())
            {
                // find symbol in current scope
                var symbol = _currentScope.GetSymbol(context.ID().GetText());
                Symbol target = symbol;

                // is symbol a pointer?
                if (symbol.Type == SymbolType.INT_P)
                {
                    target = CastPointer();
                    _templates.Peek().Add("expr", TemplateManager.AssignStatement(target, symbol));
                }

                // add symbol to expression stack
                _expressionResults.Push(
                    Expression.Create(target, ExprType.SYMBOL)  
                );
            }

            // is calculation or boolean comparison?
            if (context.IsCalc() || context.IsBooleanComparison())
            {
                var op = context.GetChild(1).GetText();

                _templates.Peek().Add("expr", VisitExpr(context.expr()[0]));
                var op1 = _expressionResults.Pop().Value;
                
                _templates.Peek().Add("expr", VisitExpr(context.expr()[1]));
                var op2 = _expressionResults.Pop().Value;

                var index = _currentScope.IncreasedIndex();
                var symbol = new Symbol(string.Format("calc.{0}", index), index, SymbolType.INT);
                _currentScope.GetChild(0).Define(symbol);

                if (context.IsCalc())
                {
                    _templates.Peek().Add("expr", TemplateManager.CalcExpression(symbol, op, op1, op2));
                }

                if (context.IsBooleanComparison())
                {
                    _templates.Peek().Add("expr", TemplateManager.CompareExpression(symbol, op, op1, op2));
                }

                _expressionResults.Push(Expression.Create(symbol, ExprType.SYMBOL));
            }

            // is method call?
            if (context.IsMethodCall())
            {
                var parameter = new List<KeyValuePair<dynamic, dynamic>>();
                if (context.args() != null)
                {
                    foreach (var expr in context.args().expr())
                    {
                        _templates.Peek().Add("expr", VisitExpr(expr));
                        parameter.Add(new KeyValuePair<dynamic, dynamic>("INT", _expressionResults.Pop().Value));
                    }
                }

                var index = _currentScope.IncreasedIndex();
                var symbol = new Symbol(string.Format("call.{0}", index), index, SymbolType.INT);
                _currentScope.GetChild(0).Define(symbol);

                _expressionResults.Push(Expression.Create(symbol, ExprType.SYMBOL));

                _templates.Peek().Add("expr", 
                    TemplateManager.MethodCall(symbol, (MethodSymbol)_currentScope.GetSymbolGlobal(context.ID().GetText()), parameter));

                _expressionResults.Push(Expression.Create(symbol, ExprType.SYMBOL));
            }

            // is short IF-Else?
            if (context.IsShortIf())
            {
                var index = _currentScope.IncreasedIndex();
                var tmp = new Symbol(string.Format("shortIf.{0}", index), index, SymbolType.INT);
                _currentScope.GetChild(0).Define(tmp);

                _templates.Peek().Add("expr", TemplateManager.SymbolDeclaration(tmp));

                // build IfStatContext from expr values
                var ifContext = new IfStatContext(context, 0);

                // IF-ELSE header
                ifContext.AddChild(new TerminalNodeImpl(new CommonToken(0, "if")));
                ifContext.AddChild(new TerminalNodeImpl(new CommonToken(0, "(")));
                ifContext.AddChild(context.expr()[0]);
                ifContext.AddChild(new TerminalNodeImpl(new CommonToken(0, ")")));

                // tmp assignment #1
                var tmpAssigmentIF = new AssignStatContext(ifContext, 0);
                tmpAssigmentIF.AddChild(new TerminalNodeImpl(new CommonToken(ID, string.Format("shortIf.{0}", index))));
                tmpAssigmentIF.AddChild(new TerminalNodeImpl(new CommonToken(0, "=")));
                tmpAssigmentIF.AddChild(context.expr()[1]);

                // tmp assignment #1
                var tmpAssigmentELSE = new AssignStatContext(ifContext, 0);
                tmpAssigmentELSE.AddChild(new TerminalNodeImpl(new CommonToken(ID, string.Format("shortIf.{0}", index))));
                tmpAssigmentELSE.AddChild(new TerminalNodeImpl(new CommonToken(0, "=")));
                tmpAssigmentELSE.AddChild(context.expr()[2]);

                // IF-statement
                var ifStat = new StatContext(ifContext, 0);
                ifStat.AddChild(tmpAssigmentIF);
                ifContext.AddChild(ifStat);

                // ELSE-statement
                ifContext.AddChild(new TerminalNodeImpl(new CommonToken(0, "else")));

                var elseStat = new StatContext(ifContext, 0);
                elseStat.AddChild(tmpAssigmentELSE);
                ifContext.AddChild(elseStat);

                _expressionResults.Push(Expression.Create(tmp, ExprType.SYMBOL));
                _templates.Peek().Add("expr", VisitIfStat(ifContext));
                _expressionResults.Push(Expression.Create(new Symbol(string.Format("shortIf.{0}", index), index, SymbolType.INT_P), ExprType.SYMBOL));
            }

            // is expression surrounded by brackets?
            if (context.IsBracketExpr())
            {
                _templates.Peek().Add("expr", VisitExpr(context.expr()[0]));
            }

            // is negation?
            if (context.IsNegation())
            {
                _templates.Peek().Add("expr", VisitExpr(context.expr()[0]));

                _negateComparision = true;
            }

            if (context.IsMinus())
            {
                _templates.Peek().Add("expr", VisitExpr(context.expr()[0]));

                var index = _currentScope.IncreasedIndex();
                var target = new Symbol(string.Format("calc.{0}", index), index, SymbolType.INT);
                _currentScope.GetChild(0).Define(target);

                _templates.Peek().Add("expr", TemplateManager.CalcExpression(target, "-", 0, _expressionResults.Pop().Value));

                _expressionResults.Push(Expression.Create(target, ExprType.SYMBOL));
            }

            if (context.IsArrayAccess())
            {
                var index = _currentScope.IncreasedIndex();

                var allocSym = new Symbol(string.Format("alloc.{0}", index), index, SymbolType.CHAR_ARRAY_P);
                
                _templates.Peek().Add("expr", TemplateManager.SymbolDeclaration(allocSym));
                _templates.Peek().Add("expr", TemplateManager.StoreStatement(allocSym, "%1"));
                _currentScope.GetChild(0).Define(allocSym);

                index = _currentScope.IncreasedIndex();
                var alloc = new Symbol(string.Format("alloc.{0}", index), index, SymbolType.INT);
                _templates.Peek().Add("expr", TemplateManager.SymbolDeclaration(alloc));
                _currentScope.GetChild(0).Define(alloc);

                index = _currentScope.IncreasedIndex();
                var loadTarget = new Symbol(string.Format("load.{0}", index), index, SymbolType.CHAR_ARRAY_P);
                _templates.Peek().Add("expr", TemplateManager.AssignStatement(loadTarget, allocSym));
                _currentScope.GetChild(0).Define(loadTarget);

                index = _currentScope.IncreasedIndex();
                var ptrTarget = new Symbol(string.Format("load.{0}", index), index, SymbolType.CHAR);
                _templates.Peek().Add("expr", TemplateManager.GetElementPtr(ptrTarget, loadTarget, int.Parse(context.INT().GetText())));
                _currentScope.GetChild(0).Define(ptrTarget);

                index = _currentScope.IncreasedIndex();
                var secLoadTarget = new Symbol(string.Format("load.{0}", index), index, SymbolType.CHAR);
                _templates.Peek().Add("expr", TemplateManager.AssignStatement(secLoadTarget, ptrTarget));
                _currentScope.GetChild(0).Define(secLoadTarget);

                index = _currentScope.IncreasedIndex();
                var atoiTarget = new Symbol(string.Format("call.{0}", index), index, SymbolType.INT);
                var atoi = new MethodSymbol("atoi", SymbolType.INT);
                var paras = new List<KeyValuePair<dynamic, dynamic>>
                {
                    new KeyValuePair<dynamic, dynamic>(secLoadTarget.Type, string.Format("%{0}", secLoadTarget.Position))
                };

                _templates.Peek().Add("expr", TemplateManager.MethodCall(atoiTarget, atoi, paras));
                _currentScope.GetChild(0).Define(atoiTarget);

                index = _currentScope.IncreasedIndex();
                _templates.Peek().Add("expr", TemplateManager.StoreStatement(alloc, atoiTarget));

                index = _currentScope.IncreasedIndex();
                var trdLoadTarget = new Symbol(string.Format("load.{0}", index), index, SymbolType.INT);
                _templates.Peek().Add("expr", TemplateManager.AssignStatement(trdLoadTarget, alloc));
                _currentScope.GetChild(0).Define(trdLoadTarget);

                _expressionResults.Push(Expression.Create(trdLoadTarget, ExprType.SYMBOL));
            }

            return _templates.Pop();
        }

        #endregion

        #region Utilities

        private Symbol CastPointer()
        {
            var index = _currentScope.IncreasedIndex();
            var target = new Symbol(string.Format("cast.{0}", index), index, SymbolType.INT);
            _currentScope.GetChild(0).Define(target);

            return target;
        }

        #endregion
    }
}
