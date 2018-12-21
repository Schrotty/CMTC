// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="CymbolListener.cs" company="CMTC">
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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="CymbolParser" />.
/// </summary>
/// <seealso cref="Antlr4.Runtime.Tree.IParseTreeListener" />
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public interface ICymbolListener : IParseTreeListener {
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.file" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterFile([NotNull] CymbolParser.FileContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.file" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitFile([NotNull] CymbolParser.FileContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.functionDecl" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterFunctionDecl([NotNull] CymbolParser.FunctionDeclContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.functionDecl" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitFunctionDecl([NotNull] CymbolParser.FunctionDeclContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.formalParameters" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterFormalParameters([NotNull] CymbolParser.FormalParametersContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.formalParameters" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitFormalParameters([NotNull] CymbolParser.FormalParametersContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.formalParameter" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterFormalParameter([NotNull] CymbolParser.FormalParameterContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.formalParameter" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitFormalParameter([NotNull] CymbolParser.FormalParameterContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.stat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterStat([NotNull] CymbolParser.StatContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.stat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitStat([NotNull] CymbolParser.StatContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.block" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterBlock([NotNull] CymbolParser.BlockContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.block" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitBlock([NotNull] CymbolParser.BlockContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.assignStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterAssignStat([NotNull] CymbolParser.AssignStatContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.assignStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitAssignStat([NotNull] CymbolParser.AssignStatContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.ifStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterIfStat([NotNull] CymbolParser.IfStatContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.ifStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitIfStat([NotNull] CymbolParser.IfStatContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.forStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterForStat([NotNull] CymbolParser.ForStatContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.forStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitForStat([NotNull] CymbolParser.ForStatContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.returnStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterReturnStat([NotNull] CymbolParser.ReturnStatContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.returnStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitReturnStat([NotNull] CymbolParser.ReturnStatContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.args" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterArgs([NotNull] CymbolParser.ArgsContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.args" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitArgs([NotNull] CymbolParser.ArgsContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.printStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterPrintStat([NotNull] CymbolParser.PrintStatContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.printStat" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitPrintStat([NotNull] CymbolParser.PrintStatContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.varDecl" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterVarDecl([NotNull] CymbolParser.VarDeclContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.varDecl" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitVarDecl([NotNull] CymbolParser.VarDeclContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.type" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterType([NotNull] CymbolParser.TypeContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.type" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitType([NotNull] CymbolParser.TypeContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.expr" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterExpr([NotNull] CymbolParser.ExprContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.expr" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitExpr([NotNull] CymbolParser.ExprContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.id" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterId([NotNull] CymbolParser.IdContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.id" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitId([NotNull] CymbolParser.IdContext context);
    /// <summary>
    /// Enter a parse tree produced by <see cref="CymbolParser.int" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void EnterInt([NotNull] CymbolParser.IntContext context);
    /// <summary>
    /// Exit a parse tree produced by <see cref="CymbolParser.int" />.
    /// </summary>
    /// <param name="context">The parse tree.</param>
    void ExitInt([NotNull] CymbolParser.IntContext context);
}
