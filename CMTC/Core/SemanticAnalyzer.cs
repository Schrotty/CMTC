// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="SemanticAnalyzer.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CMTC.Core.Extensions;
using CMTC.Core.SymTable;
using CMTC.Utilities;
using static CMTC.Core.SymTable.BaseScope;
using static CMTC.Core.SymTable.Symbol;

/// <summary>
/// The Core namespace.
/// </summary>
namespace CMTC.Core
{
    /// <summary>
    /// Class SemanticAnalyzer.
    /// Implements the <see cref="CymbolBaseVisitor{CMTC.Core.SymTable.IScope}" />
    /// </summary>
    /// <seealso cref="CymbolBaseVisitor{CMTC.Core.SymTable.IScope}" />
    class SemanticAnalyzer : CymbolBaseVisitor<IScope>
    {
        /// <summary>
        /// The symbol table
        /// </summary>
        private SymbolTable _symbolTable = new SymbolTable();

        private bool _globalContext = true;

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.file" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>IScope.</returns>
        /// <return>The visitor result.</return>
        public override IScope VisitFile([NotNull] CymbolParser.FileContext context)
        {
            _symbolTable.Scopes.Push(_symbolTable.Global);
            foreach (var c in context.varDecl())
            {
                Visit(c);
            }

            _globalContext = false;
            foreach (var c in context.functionDecl())
            {
                _symbolTable.Scopes.Peek().AddChild(Visit(c));
            }

            return _symbolTable.Scopes.Pop();
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.varDecl" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>IScope.</returns>
        /// <exception cref="System.Exception">Nope</exception>
        /// <return>The visitor result.</return>
        public override IScope VisitVarDecl([NotNull] CymbolParser.VarDeclContext context)
        {
            if (!_symbolTable.Scopes.Peek().VariableIsInScope(context.ID().GetText()))
            {
                _symbolTable.Scopes.Peek().Define(new Symbol(context.ID().GetText(), -1, _symbolTable.Global.Resolve(context.type().GetText()))
                {
                    GlobalSymbol = _globalContext
                });

                return _symbolTable.Scopes.Peek();
            }

            throw new System.Exception(TemplateManager.GetTemplate("EXISTS_ALREADY").Render());
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.functionDecl" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>IScope.</returns>
        /// <exception cref="System.Exception">
        /// </exception>
        /// <return>The visitor result.</return>
        public override IScope VisitFunctionDecl([NotNull] CymbolParser.FunctionDeclContext context)
        {
            if (!_symbolTable.Global.VariableIsInScope(context.ID().GetText()))
            {
                var funcName = context.ID().GetText();
                MethodSymbol method = new MethodSymbol(funcName,
                    _symbolTable.Global.Resolve(context.type().Start.Text), _symbolTable.Global);

                if (context.HasValidReturnStatement(method, _symbolTable.Global))
                {
                    var index = 0;
                    _symbolTable.Global.Define(method);
                    if (context.formalParameters() != null)
                    {
                        foreach (var c in context.formalParameters().formalParameter())
                        {
                            var identifier = c.ID().GetText().Trim(trimChars: new char[] { '*', '[', ']' });
                            var tmp = new Symbol(identifier, index++,
                                _symbolTable.Global.Resolve(c.type().GetText()));

                            method.Define(tmp);
                        }
                    }

                    _symbolTable.Scopes.Push(method);
                    _symbolTable.Scopes.Peek().AddChild(Visit(context.block()));
                    if (index > 0)
                    {
                        _symbolTable.Scopes.Peek().GetChild(0).Define(new Symbol(string.Format("placeholder.{0}", index), index));
                    }

                    return _symbolTable.Scopes.Pop();
                }

                throw new System.Exception("NO_VALID_RETURN");
            }

            throw new System.Exception("NO_SUCH_FUNC");
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.block" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>IScope.</returns>
        /// <return>The visitor result.</return>
        public override IScope VisitBlock([NotNull] CymbolParser.BlockContext context)
        {
            var local = new LocalScope(_symbolTable.Scopes.Peek());

            _symbolTable.Scopes.Peek().AddChild(local);
            _symbolTable.Scopes.Push(local);

            if (context.stat() != null)
            {
                foreach (var c in context.stat())
                {
                    Visit(c);
                }
            }

            var scope = _symbolTable.Scopes.Pop();
            return _symbolTable.Scopes.Peek().AddChild(scope);
        }

        /// <summary>
        /// <inheritDoc />
        /// <p>The default implementation returns the result of
        /// <see cref="P:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.DefaultResult">defaultResult</see>
        /// .</p>
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>IScope.</returns>
        /// <exception cref="System.Exception"></exception>
        public override IScope VisitTerminal(ITerminalNode node)
        {
            if (node.Symbol.Type == CymbolLexer.ID)
            {
                if (!_symbolTable.Scopes.Peek().VariableIsInScopeNested(node.GetText()))
                {
                    throw new System.Exception(TemplateManager.GetTemplate("UNDEFINED")
                        .Add("id", node.Symbol.Text)
                        .Add("line", node.Symbol.Line)
                        .Add("position", node.Symbol.Column)
                        .Render());
                }
            }

            return _symbolTable.Scopes.Peek();
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.ifStat" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>IScope.</returns>
        /// <return>The visitor result.</return>
        public override IScope VisitIfStat([NotNull] CymbolParser.IfStatContext context)
        {
            Visit(context.expr());
            foreach (var c in context.stat())
            {
                Visit(c);
            }

            return _symbolTable.Scopes.Peek();
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.forStat" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>IScope.</returns>
        /// <return>The visitor result.</return>
        public override IScope VisitForStat([NotNull] CymbolParser.ForStatContext context)
        {
            foreach (var c in context.assignStat())
            {
                Visit(c);
            }

            Visit(context.expr());
            Visit(context.block());

            return _symbolTable.Scopes.Peek();
        }

        /// <summary>
        /// Visit a parse tree produced by <see cref="M:CymbolParser.returnStat" />.
        /// <para>
        /// The default implementation returns the result of calling <see cref="M:Antlr4.Runtime.Tree.AbstractParseTreeVisitor`1.VisitChildren(Antlr4.Runtime.Tree.IRuleNode)" />
        /// on <paramref name="context" />.
        /// </para>
        /// </summary>
        /// <param name="context">The parse tree.</param>
        /// <returns>IScope.</returns>
        /// <return>The visitor result.</return>
        public override IScope VisitReturnStat([NotNull] CymbolParser.ReturnStatContext context)
        {
            Visit(context.expr());

            return _symbolTable.Scopes.Peek();
        }

        /// <summary>
        /// Visits the print stat.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>IScope.</returns>
        /// <return>The visitor result.</return>
        public override IScope VisitPrintStat([NotNull] CymbolParser.PrintStatContext context)
        {
            Visit(context.expr());

            return _symbolTable.Scopes.Peek();
        }

        public override IScope VisitExpr([NotNull] CymbolParser.ExprContext context)
        {
            if (context.IsNegation() && !context.IsValidNegation())
            {
                throw new System.Exception(TemplateManager.GetTemplate("INVALID_NEGATION").Render());
            }

            if (context.IsMinus() && !context.IsValidMinus())
            {
                throw new System.Exception(TemplateManager.GetTemplate("INVALID_MINUS").Render());
            }

            return base.VisitExpr(context);
        }
    }
}
