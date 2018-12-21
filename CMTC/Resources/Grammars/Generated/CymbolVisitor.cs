// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="CymbolVisitor.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

// Generated from Cymbol.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="CymbolParser" />.
/// Implements the <see cref="Antlr4.Runtime.Tree.IParseTreeVisitor{Result}" />
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
/// <seealso cref="Antlr4.Runtime.Tree.IParseTreeVisitor{Result}" />
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public interface ICymbolVisitor<Result> : IParseTreeVisitor<Result> {
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.file" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitFile([NotNull] CymbolParser.FileContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.functionDecl" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitFunctionDecl([NotNull] CymbolParser.FunctionDeclContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.formalParameters" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitFormalParameters([NotNull] CymbolParser.FormalParametersContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.formalParameter" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitFormalParameter([NotNull] CymbolParser.FormalParameterContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.stat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitStat([NotNull] CymbolParser.StatContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.block" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitBlock([NotNull] CymbolParser.BlockContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.assignStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitAssignStat([NotNull] CymbolParser.AssignStatContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.ifStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitIfStat([NotNull] CymbolParser.IfStatContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.forStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitForStat([NotNull] CymbolParser.ForStatContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.returnStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitReturnStat([NotNull] CymbolParser.ReturnStatContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.args" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitArgs([NotNull] CymbolParser.ArgsContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.printStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitPrintStat([NotNull] CymbolParser.PrintStatContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.varDecl" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitVarDecl([NotNull] CymbolParser.VarDeclContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.type" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitType([NotNull] CymbolParser.TypeContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.expr" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitExpr([NotNull] CymbolParser.ExprContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.id" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitId([NotNull] CymbolParser.IdContext context);
    /// <summary>
    /// Visit a parse tree produced by <see cref="CymbolParser.int" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <returns>Result.</returns>
    /// <return>The visitor result.</return>
    Result VisitInt([NotNull] CymbolParser.IntContext context);
}
