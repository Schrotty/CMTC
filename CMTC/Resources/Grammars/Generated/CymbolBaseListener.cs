//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ICymbolListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class CymbolBaseListener : ICymbolListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.file"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFile([NotNull] CymbolParser.FileContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.file"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFile([NotNull] CymbolParser.FileContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.functionDecl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionDecl([NotNull] CymbolParser.FunctionDeclContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.functionDecl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionDecl([NotNull] CymbolParser.FunctionDeclContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.formalParameters"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFormalParameters([NotNull] CymbolParser.FormalParametersContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.formalParameters"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFormalParameters([NotNull] CymbolParser.FormalParametersContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.formalParameter"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFormalParameter([NotNull] CymbolParser.FormalParameterContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.formalParameter"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFormalParameter([NotNull] CymbolParser.FormalParameterContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.stat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStat([NotNull] CymbolParser.StatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.stat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStat([NotNull] CymbolParser.StatContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBlock([NotNull] CymbolParser.BlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBlock([NotNull] CymbolParser.BlockContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.assignStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignStat([NotNull] CymbolParser.AssignStatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.assignStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignStat([NotNull] CymbolParser.AssignStatContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.ifStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIfStat([NotNull] CymbolParser.IfStatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.ifStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIfStat([NotNull] CymbolParser.IfStatContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.forStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterForStat([NotNull] CymbolParser.ForStatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.forStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitForStat([NotNull] CymbolParser.ForStatContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.returnStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReturnStat([NotNull] CymbolParser.ReturnStatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.returnStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReturnStat([NotNull] CymbolParser.ReturnStatContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.args"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArgs([NotNull] CymbolParser.ArgsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.args"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArgs([NotNull] CymbolParser.ArgsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.printStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPrintStat([NotNull] CymbolParser.PrintStatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.printStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPrintStat([NotNull] CymbolParser.PrintStatContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.varDecl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVarDecl([NotNull] CymbolParser.VarDeclContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.varDecl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVarDecl([NotNull] CymbolParser.VarDeclContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterType([NotNull] CymbolParser.TypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitType([NotNull] CymbolParser.TypeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpr([NotNull] CymbolParser.ExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpr([NotNull] CymbolParser.ExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.id"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterId([NotNull] CymbolParser.IdContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.id"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitId([NotNull] CymbolParser.IdContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CymbolParser.int"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInt([NotNull] CymbolParser.IntContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CymbolParser.int"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInt([NotNull] CymbolParser.IntContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
