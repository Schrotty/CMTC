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
        private readonly Dictionary<int, Symbol> _symbols = new Dictionary<int, Symbol>();

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

            _currentScope = global.GetMethod(context.ID().GetText());
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
            _templates.Push(TemplateManager.AssignStatement(new Symbol("tmp", 0), new Symbol("tmp", 1)));

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
            
            return _templates.Pop();
        }

        #endregion
    }
}
