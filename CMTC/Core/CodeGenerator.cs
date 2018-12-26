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
using CMTC.Core.Extensions;
using CMTC.Core.SymTable;
using CMTC.Core.SymTable.Models;
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
        /// The templates
        /// </summary>
        private readonly Stack<Template> _templates = new Stack<Template>();

        /// <summary>
        /// The expression results
        /// </summary>
        private readonly Stack<Expression> _expressionResults = new Stack<Expression>();

        /// <summary>
        /// The global
        /// </summary>
        private readonly IScope _globalScope;

        /// <summary>
        /// The current scope
        /// </summary>
        private IScope _currentScope;

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
            _templates.Push(TemplateManager.GetTemplate("file"));
            foreach (var c in context.varDecl())
            {
                _templates.Peek().Add("symbols", VisitVarDecl(c));
            }

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
            _templates.Push(
                TemplateManager.FunctionDeclaration((MethodSymbol)_globalScope.GetMethod(context.ID().GetText()))
            );

            _currentScope = _globalScope.GetMethod(context.ID().GetText());
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
                _templates.Peek().Add("statement", VisitReturnStat(context.returnStat()));
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
            _templates.Peek().Add("statement", VisitExpr(context.expr()));

            var template = TemplateManager.GetTemplate("returnStatement");
            template.Add("symbol", _expressionResults.Pop().Value);

            return template;
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
            _templates.Peek().Add("statement", VisitExpr(context.expr()));

            var name = _currentScope.GetSymbol(context.ID().GetText()).Name;
            var target = new Symbol(name, _currentScope.IncreasedIndex(), SymbolType.INT);
            var source = new Symbol("source", _expressionResults.Pop().Value, SymbolType.INT);

            _templates.Push(TemplateManager.AssignStatement(target, source));

            // update variable
            _currentScope.GetSymbol(context.ID().GetText()).Name = string.Format("{0}*", name);
            _currentScope.GetChild(0).Define(target);

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

            if (context.IsInteger())
            {
                var symbol = new Symbol("target", _currentScope.GetIndex(), SymbolType.INT);
                _templates.Peek().Add("expr", TemplateManager.StoreStatement(symbol, context.GetText()));

                _expressionResults.Push(Expression.Create(symbol.Position));
            }

            if (context.IsIdentifier())
            {
                _expressionResults.Push(
                    Expression.Create(_currentScope.GetSymbol(context.ID().GetText()))  
                );
            }

            return _templates.Pop();
        }

        #endregion
    }
}
