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
using Antlr4.Runtime.Misc;
using Antlr4.StringTemplate;
using CMTC.Core.SymTable;
using CMTC.Utilities;
using System.Collections.Generic;
using static CMTC.Core.SymTable.Symbol;

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
        /// The global
        /// </summary>
        private bool _global = true;

        /// <summary>
        /// The local scope name
        /// </summary>
        private string _localScopeName;

        /// <summary>
        /// The local scope variable index
        /// </summary>
        private int _localScopeVarIndex;

        /// <summary>
        /// The templates
        /// </summary>
        private readonly Stack<Template> _templates = new Stack<Template>();

        /// <summary>
        /// The expression results
        /// </summary>
        private readonly Stack<int> _expressionResults = new Stack<int>();

        /// <summary>
        /// The saved values
        /// </summary>
        private readonly Dictionary<int, int> _savedValues = new Dictionary<int, int>();

        /// <summary>
        /// The global
        /// </summary>
        private readonly IScope global;

        /// <summary>
        /// The current scope
        /// </summary>
        private IScope _currentScope;

        /// <summary>
        /// The parent
        /// </summary>
        private string _parent = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeGenerator" /> class.
        /// </summary>
        /// <param name="global">The global.</param>
        public CodeGenerator(IScope global)
        {
            this.global = global;
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
            _templates.Push(TemplateManager.GetTemplate("file"));
            foreach (var c in context.varDecl())
            {
                _templates.Peek().Add("symbols", VisitVarDecl(c));
            }

            _global = false;
            foreach (var c in context.functionDecl())
            {              
                _templates.Peek().Add("symbols", VisitFunctionDecl(c));                
            }

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
            var symbol = global.GetMethod(_localScopeName).GetSymbol(context.ID().GetText());
            if (!_global) symbol.Position++;

            return TemplateManager.SymbolDeclaration(symbol);
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
            _templates.Push(
                TemplateManager.FunctionDeclaration((MethodSymbol)global.GetMethod(context.ID().GetText()))
            );

            return _templates.Pop().Add("block", VisitBlock(context.block()));
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
            _templates.Push(TemplateManager.GetTemplate("statement"));
            if (context.stat() != null)
            {
                foreach (var c in context.stat())
                {
                    VisitStat(c);
                }
            }

            _localScopeVarIndex = 0;
            return _templates.Pop();
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
            if (context.expr() != null)
            {
                _templates.Peek().Add("statement", VisitExpr(context.expr()));
            }

            if (context.returnStat() != null)
            {
                //_templates.Peek().Add("statement", VisitReturnStat(context.returnStat()));
            }

            if (context.varDecl() != null)
            {
                _templates.Peek().Add("statement", VisitVarDecl(context.varDecl()));
            }

            if (context.assignStat() != null)
            {
                _templates.Peek().Add("statement", VisitAssignStat(context.assignStat()));
            }

            if (context.block() != null)
            {
                _templates.Peek().Add("statement", VisitBlock(context.block()));
            }

            return _templates.Peek();
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
            _templates.Push(TemplateManager.GetTemplate("returnStatement"));
            _templates.Peek().Add("expr", Visit(context.expr()));
            _templates.Peek().Add("type", "int").Add("result", _expressionResults.Pop());

            return _templates.Pop();
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
            _parent = "assign";

            _templates.Peek().Add("statement", Visit(context.expr()));
            _templates.Push(TemplateManager.GetTemplate("loadValue"));

            var isGlobal = global.GetSymbolLocal(context.ID().GetText()) != null;
            var source = _currentScope.GetSymbol(context.ID().GetText()).Position.ToString();
            if (isGlobal) source = context.ID().GetText();

            _templates.Peek()
                .Add("type", "int")
                .Add("source", source)
                .Add("globalSource", isGlobal)
                .Add("target", ++((Symbol)_currentScope).Position);

            _currentScope.GetSymbol(context.ID().GetText()).Position = ((Symbol)_currentScope).Position;

            return _templates.Pop();
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

            foreach (var c in context.expr())
            {
                _templates.Peek().Add("expr", Visit(c));
            }

            var symbol = (Symbol)_currentScope;
            if (context.ChildCount == 1)
            {
                if (context.INT() != null)
                {
                    var rInt = -1;
                    var integer = -1;
                    int.TryParse(context.INT().GetText(), out rInt);

                    var valExists = _savedValues.TryGetValue(rInt, out integer);
                    if (!valExists && _parent != "assign")
                    {
                        _templates.Peek().Add("expr",
                            TemplateManager.GetTemplate("symbol")
                                .Add("type", "int")
                                .Add("id", ++((Symbol)_currentScope).Position));
                    }

                    var isGlobal = global.GetSymbolLocal(context.ID().GetText()) != null;
                    var source = _currentScope.GetSymbol(context.ID().GetText()).Position.ToString();
                    if (isGlobal) source = context.ID().GetText();

                    var pos = !valExists ? ((Symbol)_currentScope).Position : integer;
                    _templates.Peek().Add("expr", 
                        TemplateManager.GetTemplate("storeValue")
                            .Add("type", "int")
                            .Add("source", context.INT().GetText())
                            .Add("target", pos));

                    if (!valExists && _parent != "assign")
                    {
                        _templates.Peek().Add("expr",
                            TemplateManager.GetTemplate("loadValue")
                                .Add("type", "int")
                                .Add("source", pos)
                                .Add("target", ++((Symbol)_currentScope).Position));
                    }
                }
            }

            if (context.ChildCount == 3)
            {
                var op2 = _expressionResults.Pop();
                var op = context.GetChild(1);
                _templates.Peek().Add("expr", 
                    TemplateManager.GetTemplate("addSubExpr")
                        .Add("index", ++symbol.Position)
                        .Add("type", "int")
                        .Add("op", op)
                        .Add("op1", _expressionResults.Pop())
                        .Add("op2", op2));
            }

            _parent = string.Empty;
            _expressionResults.Push(symbol.Position);
            return _templates.Pop();
        }

        #endregion
    }
}
