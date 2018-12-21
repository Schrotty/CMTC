// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="CymbolParser.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

/// <summary>
/// Class CymbolParser.
/// Implements the <see cref="Antlr4.Runtime.Parser" />
/// </summary>
/// <seealso cref="Antlr4.Runtime.Parser" />
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class CymbolParser : Parser {
    /// <summary>
    /// The decision to dfa
    /// </summary>
    protected static DFA[] decisionToDFA;
    /// <summary>
    /// The shared context cache
    /// </summary>
    protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
    /// <summary>
    /// The t 0
    /// </summary>
    public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		STRING=25, BOOL=26, ID=27, INT=28, WS=29, COMMENT=30;
    /// <summary>
    /// The rule file
    /// </summary>
    public const int
		RULE_file = 0, RULE_functionDecl = 1, RULE_formalParameters = 2, RULE_formalParameter = 3, 
		RULE_stat = 4, RULE_block = 5, RULE_assignStat = 6, RULE_ifStat = 7, RULE_forStat = 8, 
		RULE_returnStat = 9, RULE_args = 10, RULE_printStat = 11, RULE_varDecl = 12, 
		RULE_type = 13, RULE_expr = 14, RULE_id = 15, RULE_int = 16;
    /// <summary>
    /// The rule names
    /// </summary>
    public static readonly string[] ruleNames = {
		"file", "functionDecl", "formalParameters", "formalParameter", "stat", 
		"block", "assignStat", "ifStat", "forStat", "returnStat", "args", "printStat", 
		"varDecl", "type", "expr", "id", "int"
	};

    /// <summary>
    /// The literal names
    /// </summary>
    private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "','", "';'", "'{'", "'}'", "'='", "'if'", "'else'", 
		"'for'", "'return'", "'printf'", "'int'", "'-'", "'!'", "'*'", "'/'", 
		"'+'", "'=='", "'!='", "'<'", "'>'", "'?'", "':'"
	};
    /// <summary>
    /// The symbolic names
    /// </summary>
    private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, "STRING", "BOOL", "ID", "INT", "WS", "COMMENT"
	};
    /// <summary>
    /// The default vocabulary
    /// </summary>
    public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

    /// <summary>
    /// Get the vocabulary used by the recognizer.
    /// </summary>
    /// <value>The vocabulary.</value>
    /// <remarks>Get the vocabulary used by the recognizer.</remarks>
    [NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

    /// <summary>
    /// For debugging and other purposes, might want the grammar name.
    /// </summary>
    /// <value>The name of the grammar file.</value>
    /// <remarks>For debugging and other purposes, might want the grammar name.
    /// Have ANTLR generate an implementation for this method.</remarks>
    public override string GrammarFileName { get { return "Cymbol.g4"; } }

    /// <summary>
    /// Used to print out token names like ID during debugging and
    /// error reporting.
    /// </summary>
    /// <value>The rule names.</value>
    /// <remarks>Used to print out token names like ID during debugging and
    /// error reporting.  The generated parsers implement a method
    /// that overrides this to point to their String[] tokenNames.</remarks>
    public override string[] RuleNames { get { return ruleNames; } }

    /// <summary>
    /// If this recognizer was generated, it will have a serialized ATN
    /// representation of the grammar.
    /// </summary>
    /// <value>The serialized atn.</value>
    /// <remarks>If this recognizer was generated, it will have a serialized ATN
    /// representation of the grammar.
    /// <p>For interpreters, we don't know their serialized ATN despite having
    /// created the interpreter from it.</p></remarks>
    public override string SerializedAtn { get { return new string(_serializedATN); } }

    /// <summary>
    /// Initializes static members of the <see cref="CymbolParser" /> class.
    /// </summary>
    static CymbolParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

    /// <summary>
    /// Initializes a new instance of the <see cref="CymbolParser" /> class.
    /// </summary>
    /// <param name="input">The input.</param>
    public CymbolParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CymbolParser" /> class.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="output">The output.</param>
    /// <param name="errorOutput">The error output.</param>
    public CymbolParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}
    /// <summary>
    /// Class FileContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class FileContext : ParserRuleContext {
        /// <summary>
        /// Functions the decl.
        /// </summary>
        /// <returns>FunctionDeclContext[].</returns>
        public FunctionDeclContext[] functionDecl() {
			return GetRuleContexts<FunctionDeclContext>();
		}
        /// <summary>
        /// Functions the decl.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>FunctionDeclContext.</returns>
        public FunctionDeclContext functionDecl(int i) {
			return GetRuleContext<FunctionDeclContext>(i);
		}
        /// <summary>
        /// Variables the decl.
        /// </summary>
        /// <returns>VarDeclContext[].</returns>
        public VarDeclContext[] varDecl() {
			return GetRuleContexts<VarDeclContext>();
		}
        /// <summary>
        /// Variables the decl.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>VarDeclContext.</returns>
        public VarDeclContext varDecl(int i) {
			return GetRuleContext<VarDeclContext>(i);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="FileContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public FileContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_file; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterFile(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitFile(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFile(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Files this instance.
    /// </summary>
    /// <returns>FileContext.</returns>
    [RuleVersion(0)]
	public FileContext file() {
		FileContext _localctx = new FileContext(Context, State);
		EnterRule(_localctx, 0, RULE_file);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 36;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				State = 36;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,0,Context) ) {
				case 1:
					{
					State = 34; functionDecl();
					}
					break;
				case 2:
					{
					State = 35; varDecl();
					}
					break;
				}
				}
				State = 38;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==T__12 );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class FunctionDeclContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class FunctionDeclContext : ParserRuleContext {
        /// <summary>
        /// Types this instance.
        /// </summary>
        /// <returns>TypeContext.</returns>
        public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
        /// <summary>
        /// Identifiers this instance.
        /// </summary>
        /// <returns>ITerminalNode.</returns>
        public ITerminalNode ID() { return GetToken(CymbolParser.ID, 0); }
        /// <summary>
        /// Blocks this instance.
        /// </summary>
        /// <returns>BlockContext.</returns>
        public BlockContext block() {
			return GetRuleContext<BlockContext>(0);
		}
        /// <summary>
        /// Formals the parameters.
        /// </summary>
        /// <returns>FormalParametersContext.</returns>
        public FormalParametersContext formalParameters() {
			return GetRuleContext<FormalParametersContext>(0);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionDeclContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public FunctionDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_functionDecl; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterFunctionDecl(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitFunctionDecl(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFunctionDecl(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Functions the decl.
    /// </summary>
    /// <returns>FunctionDeclContext.</returns>
    [RuleVersion(0)]
	public FunctionDeclContext functionDecl() {
		FunctionDeclContext _localctx = new FunctionDeclContext(Context, State);
		EnterRule(_localctx, 2, RULE_functionDecl);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 40; type();
			State = 41; Match(ID);
			State = 42; Match(T__0);
			State = 44;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==T__12) {
				{
				State = 43; formalParameters();
				}
			}

			State = 46; Match(T__1);
			State = 47; block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class FormalParametersContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class FormalParametersContext : ParserRuleContext {
        /// <summary>
        /// Formals the parameter.
        /// </summary>
        /// <returns>FormalParameterContext[].</returns>
        public FormalParameterContext[] formalParameter() {
			return GetRuleContexts<FormalParameterContext>();
		}
        /// <summary>
        /// Formals the parameter.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>FormalParameterContext.</returns>
        public FormalParameterContext formalParameter(int i) {
			return GetRuleContext<FormalParameterContext>(i);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="FormalParametersContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public FormalParametersContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_formalParameters; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterFormalParameters(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitFormalParameters(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFormalParameters(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Formals the parameters.
    /// </summary>
    /// <returns>FormalParametersContext.</returns>
    [RuleVersion(0)]
	public FormalParametersContext formalParameters() {
		FormalParametersContext _localctx = new FormalParametersContext(Context, State);
		EnterRule(_localctx, 4, RULE_formalParameters);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 49; formalParameter();
			State = 54;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__2) {
				{
				{
				State = 50; Match(T__2);
				State = 51; formalParameter();
				}
				}
				State = 56;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class FormalParameterContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class FormalParameterContext : ParserRuleContext {
        /// <summary>
        /// Types this instance.
        /// </summary>
        /// <returns>TypeContext.</returns>
        public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
        /// <summary>
        /// Identifiers this instance.
        /// </summary>
        /// <returns>ITerminalNode.</returns>
        public ITerminalNode ID() { return GetToken(CymbolParser.ID, 0); }
        /// <summary>
        /// Initializes a new instance of the <see cref="FormalParameterContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public FormalParameterContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_formalParameter; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterFormalParameter(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitFormalParameter(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFormalParameter(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Formals the parameter.
    /// </summary>
    /// <returns>FormalParameterContext.</returns>
    [RuleVersion(0)]
	public FormalParameterContext formalParameter() {
		FormalParameterContext _localctx = new FormalParameterContext(Context, State);
		EnterRule(_localctx, 6, RULE_formalParameter);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 57; type();
			State = 58; Match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class StatContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class StatContext : ParserRuleContext {
        /// <summary>
        /// Blocks this instance.
        /// </summary>
        /// <returns>BlockContext.</returns>
        public BlockContext block() {
			return GetRuleContext<BlockContext>(0);
		}
        /// <summary>
        /// Variables the decl.
        /// </summary>
        /// <returns>VarDeclContext.</returns>
        public VarDeclContext varDecl() {
			return GetRuleContext<VarDeclContext>(0);
		}
        /// <summary>
        /// Ifs the stat.
        /// </summary>
        /// <returns>IfStatContext.</returns>
        public IfStatContext ifStat() {
			return GetRuleContext<IfStatContext>(0);
		}
        /// <summary>
        /// Fors the stat.
        /// </summary>
        /// <returns>ForStatContext.</returns>
        public ForStatContext forStat() {
			return GetRuleContext<ForStatContext>(0);
		}
        /// <summary>
        /// Returns the stat.
        /// </summary>
        /// <returns>ReturnStatContext.</returns>
        public ReturnStatContext returnStat() {
			return GetRuleContext<ReturnStatContext>(0);
		}
        /// <summary>
        /// Assigns the stat.
        /// </summary>
        /// <returns>AssignStatContext.</returns>
        public AssignStatContext assignStat() {
			return GetRuleContext<AssignStatContext>(0);
		}
        /// <summary>
        /// Prints the stat.
        /// </summary>
        /// <returns>PrintStatContext.</returns>
        public PrintStatContext printStat() {
			return GetRuleContext<PrintStatContext>(0);
		}
        /// <summary>
        /// Exprs this instance.
        /// </summary>
        /// <returns>ExprContext.</returns>
        public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="StatContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public StatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_stat; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterStat(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitStat(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStat(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Stats this instance.
    /// </summary>
    /// <returns>StatContext.</returns>
    [RuleVersion(0)]
	public StatContext stat() {
		StatContext _localctx = new StatContext(Context, State);
		EnterRule(_localctx, 8, RULE_stat);
		try {
			State = 76;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 60; block();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 61; varDecl();
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 62; ifStat();
				}
				break;
			case 4:
				EnterOuterAlt(_localctx, 4);
				{
				State = 63; forStat();
				}
				break;
			case 5:
				EnterOuterAlt(_localctx, 5);
				{
				State = 64; returnStat();
				State = 65; Match(T__3);
				}
				break;
			case 6:
				EnterOuterAlt(_localctx, 6);
				{
				State = 67; assignStat();
				State = 68; Match(T__3);
				}
				break;
			case 7:
				EnterOuterAlt(_localctx, 7);
				{
				State = 70; printStat();
				State = 71; Match(T__3);
				}
				break;
			case 8:
				EnterOuterAlt(_localctx, 8);
				{
				State = 73; expr(0);
				State = 74; Match(T__3);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class BlockContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class BlockContext : ParserRuleContext {
        /// <summary>
        /// Stats this instance.
        /// </summary>
        /// <returns>StatContext[].</returns>
        public StatContext[] stat() {
			return GetRuleContexts<StatContext>();
		}
        /// <summary>
        /// Stats the specified i.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>StatContext.</returns>
        public StatContext stat(int i) {
			return GetRuleContext<StatContext>(i);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public BlockContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_block; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterBlock(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitBlock(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBlock(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Blocks this instance.
    /// </summary>
    /// <returns>BlockContext.</returns>
    [RuleVersion(0)]
	public BlockContext block() {
		BlockContext _localctx = new BlockContext(Context, State);
		EnterRule(_localctx, 10, RULE_block);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 78; Match(T__4);
			State = 82;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << T__4) | (1L << T__7) | (1L << T__9) | (1L << T__10) | (1L << T__11) | (1L << T__12) | (1L << T__13) | (1L << T__14) | (1L << ID) | (1L << INT))) != 0)) {
				{
				{
				State = 79; stat();
				}
				}
				State = 84;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 85; Match(T__5);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class AssignStatContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class AssignStatContext : ParserRuleContext {
        /// <summary>
        /// Identifiers this instance.
        /// </summary>
        /// <returns>ITerminalNode.</returns>
        public ITerminalNode ID() { return GetToken(CymbolParser.ID, 0); }
        /// <summary>
        /// Exprs this instance.
        /// </summary>
        /// <returns>ExprContext.</returns>
        public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignStatContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public AssignStatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_assignStat; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterAssignStat(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitAssignStat(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAssignStat(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Assigns the stat.
    /// </summary>
    /// <returns>AssignStatContext.</returns>
    [RuleVersion(0)]
	public AssignStatContext assignStat() {
		AssignStatContext _localctx = new AssignStatContext(Context, State);
		EnterRule(_localctx, 12, RULE_assignStat);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 87; Match(ID);
			State = 88; Match(T__6);
			State = 89; expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class IfStatContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class IfStatContext : ParserRuleContext {
        /// <summary>
        /// Exprs this instance.
        /// </summary>
        /// <returns>ExprContext.</returns>
        public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
        /// <summary>
        /// Stats this instance.
        /// </summary>
        /// <returns>StatContext[].</returns>
        public StatContext[] stat() {
			return GetRuleContexts<StatContext>();
		}
        /// <summary>
        /// Stats the specified i.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>StatContext.</returns>
        public StatContext stat(int i) {
			return GetRuleContext<StatContext>(i);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="IfStatContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public IfStatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_ifStat; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterIfStat(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitIfStat(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIfStat(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Ifs the stat.
    /// </summary>
    /// <returns>IfStatContext.</returns>
    [RuleVersion(0)]
	public IfStatContext ifStat() {
		IfStatContext _localctx = new IfStatContext(Context, State);
		EnterRule(_localctx, 14, RULE_ifStat);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 91; Match(T__7);
			State = 92; Match(T__0);
			State = 93; expr(0);
			State = 94; Match(T__1);
			State = 95; stat();
			State = 98;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,6,Context) ) {
			case 1:
				{
				State = 96; Match(T__8);
				State = 97; stat();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class ForStatContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class ForStatContext : ParserRuleContext {
        /// <summary>
        /// Assigns the stat.
        /// </summary>
        /// <returns>AssignStatContext[].</returns>
        public AssignStatContext[] assignStat() {
			return GetRuleContexts<AssignStatContext>();
		}
        /// <summary>
        /// Assigns the stat.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>AssignStatContext.</returns>
        public AssignStatContext assignStat(int i) {
			return GetRuleContext<AssignStatContext>(i);
		}
        /// <summary>
        /// Exprs this instance.
        /// </summary>
        /// <returns>ExprContext.</returns>
        public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
        /// <summary>
        /// Blocks this instance.
        /// </summary>
        /// <returns>BlockContext.</returns>
        public BlockContext block() {
			return GetRuleContext<BlockContext>(0);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ForStatContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public ForStatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_forStat; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterForStat(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitForStat(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitForStat(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Fors the stat.
    /// </summary>
    /// <returns>ForStatContext.</returns>
    [RuleVersion(0)]
	public ForStatContext forStat() {
		ForStatContext _localctx = new ForStatContext(Context, State);
		EnterRule(_localctx, 16, RULE_forStat);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 100; Match(T__9);
			State = 101; Match(T__0);
			State = 102; assignStat();
			State = 103; Match(T__3);
			State = 104; expr(0);
			State = 105; Match(T__3);
			State = 106; assignStat();
			State = 107; Match(T__1);
			State = 108; block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class ReturnStatContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class ReturnStatContext : ParserRuleContext {
        /// <summary>
        /// Exprs this instance.
        /// </summary>
        /// <returns>ExprContext.</returns>
        public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnStatContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public ReturnStatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_returnStat; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterReturnStat(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitReturnStat(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitReturnStat(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Returns the stat.
    /// </summary>
    /// <returns>ReturnStatContext.</returns>
    [RuleVersion(0)]
	public ReturnStatContext returnStat() {
		ReturnStatContext _localctx = new ReturnStatContext(Context, State);
		EnterRule(_localctx, 18, RULE_returnStat);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 110; Match(T__10);
			State = 111; expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class ArgsContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class ArgsContext : ParserRuleContext {
        /// <summary>
        /// Exprs this instance.
        /// </summary>
        /// <returns>ExprContext[].</returns>
        public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
        /// <summary>
        /// Exprs the specified i.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>ExprContext.</returns>
        public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgsContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public ArgsContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_args; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterArgs(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitArgs(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitArgs(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Argumentses this instance.
    /// </summary>
    /// <returns>ArgsContext.</returns>
    [RuleVersion(0)]
	public ArgsContext args() {
		ArgsContext _localctx = new ArgsContext(Context, State);
		EnterRule(_localctx, 20, RULE_args);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 113; expr(0);
			State = 118;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__2) {
				{
				{
				State = 114; Match(T__2);
				State = 115; expr(0);
				}
				}
				State = 120;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class PrintStatContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class PrintStatContext : ParserRuleContext {
        /// <summary>
        /// Exprs this instance.
        /// </summary>
        /// <returns>ExprContext.</returns>
        public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintStatContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public PrintStatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_printStat; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterPrintStat(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitPrintStat(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrintStat(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Prints the stat.
    /// </summary>
    /// <returns>PrintStatContext.</returns>
    [RuleVersion(0)]
	public PrintStatContext printStat() {
		PrintStatContext _localctx = new PrintStatContext(Context, State);
		EnterRule(_localctx, 22, RULE_printStat);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 121; Match(T__11);
			State = 122; Match(T__0);
			State = 123; expr(0);
			State = 124; Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class VarDeclContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class VarDeclContext : ParserRuleContext {
        /// <summary>
        /// Types this instance.
        /// </summary>
        /// <returns>TypeContext.</returns>
        public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
        /// <summary>
        /// Identifiers this instance.
        /// </summary>
        /// <returns>ITerminalNode.</returns>
        public ITerminalNode ID() { return GetToken(CymbolParser.ID, 0); }
        /// <summary>
        /// Initializes a new instance of the <see cref="VarDeclContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public VarDeclContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_varDecl; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterVarDecl(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitVarDecl(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVarDecl(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Variables the decl.
    /// </summary>
    /// <returns>VarDeclContext.</returns>
    [RuleVersion(0)]
	public VarDeclContext varDecl() {
		VarDeclContext _localctx = new VarDeclContext(Context, State);
		EnterRule(_localctx, 24, RULE_varDecl);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 126; type();
			State = 127; Match(ID);
			State = 128; Match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class TypeContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class TypeContext : ParserRuleContext {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public TypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_type; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterType(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitType(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitType(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Types this instance.
    /// </summary>
    /// <returns>TypeContext.</returns>
    [RuleVersion(0)]
	public TypeContext type() {
		TypeContext _localctx = new TypeContext(Context, State);
		EnterRule(_localctx, 26, RULE_type);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 130; Match(T__12);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class ExprContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class ExprContext : ParserRuleContext {
        /// <summary>
        /// Exprs this instance.
        /// </summary>
        /// <returns>ExprContext[].</returns>
        public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
        /// <summary>
        /// Exprs the specified i.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>ExprContext.</returns>
        public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
        /// <summary>
        /// Identifiers this instance.
        /// </summary>
        /// <returns>ITerminalNode.</returns>
        public ITerminalNode ID() { return GetToken(CymbolParser.ID, 0); }
        /// <summary>
        /// Ints this instance.
        /// </summary>
        /// <returns>ITerminalNode.</returns>
        public ITerminalNode INT() { return GetToken(CymbolParser.INT, 0); }
        /// <summary>
        /// Argumentses this instance.
        /// </summary>
        /// <returns>ArgsContext.</returns>
        public ArgsContext args() {
			return GetRuleContext<ArgsContext>(0);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ExprContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_expr; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterExpr(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitExpr(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Exprs this instance.
    /// </summary>
    /// <returns>ExprContext.</returns>
    [RuleVersion(0)]
	public ExprContext expr() {
		return expr(0);
	}

    /// <summary>
    /// Exprs the specified p.
    /// </summary>
    /// <param name="_p">The p.</param>
    /// <returns>ExprContext.</returns>
    /// <exception cref="FailedPredicateException">Precpred(Context, 8)
    /// or
    /// Precpred(Context, 7)
    /// or
    /// Precpred(Context, 6)
    /// or
    /// Precpred(Context, 5)</exception>
    private ExprContext expr(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExprContext _localctx = new ExprContext(Context, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 28;
		EnterRecursionRule(_localctx, 28, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 149;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,9,Context) ) {
			case 1:
				{
				State = 133; Match(T__13);
				State = 134; expr(10);
				}
				break;
			case 2:
				{
				State = 135; Match(T__14);
				State = 136; expr(9);
				}
				break;
			case 3:
				{
				State = 137; Match(ID);
				}
				break;
			case 4:
				{
				State = 138; Match(INT);
				}
				break;
			case 5:
				{
				State = 139; Match(T__0);
				State = 140; expr(0);
				State = 141; Match(T__1);
				}
				break;
			case 6:
				{
				State = 143; Match(ID);
				State = 144; Match(T__0);
				State = 146;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << T__13) | (1L << T__14) | (1L << ID) | (1L << INT))) != 0)) {
					{
					State = 145; args();
					}
				}

				State = 148; Match(T__1);
				}
				break;
			}
			Context.Stop = TokenStream.LT(-1);
			State = 168;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,11,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 166;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,10,Context) ) {
					case 1:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 151;
						if (!(Precpred(Context, 8))) throw new FailedPredicateException(this, "Precpred(Context, 8)");
						State = 152;
						_la = TokenStream.LA(1);
						if ( !(_la==T__15 || _la==T__16) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 153; expr(9);
						}
						break;
					case 2:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 154;
						if (!(Precpred(Context, 7))) throw new FailedPredicateException(this, "Precpred(Context, 7)");
						State = 155;
						_la = TokenStream.LA(1);
						if ( !(_la==T__13 || _la==T__17) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 156; expr(8);
						}
						break;
					case 3:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 157;
						if (!(Precpred(Context, 6))) throw new FailedPredicateException(this, "Precpred(Context, 6)");
						State = 158;
						_la = TokenStream.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__18) | (1L << T__19) | (1L << T__20) | (1L << T__21))) != 0)) ) {
						ErrorHandler.RecoverInline(this);
						}
						else {
							ErrorHandler.ReportMatch(this);
						    Consume();
						}
						State = 159; expr(7);
						}
						break;
					case 4:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 160;
						if (!(Precpred(Context, 5))) throw new FailedPredicateException(this, "Precpred(Context, 5)");
						State = 161; Match(T__22);
						State = 162; expr(0);
						State = 163; Match(T__23);
						State = 164; expr(6);
						}
						break;
					}
					} 
				}
				State = 170;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,11,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

    /// <summary>
    /// Class IdContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class IdContext : ParserRuleContext {
        /// <summary>
        /// Identifiers this instance.
        /// </summary>
        /// <returns>ITerminalNode.</returns>
        public ITerminalNode ID() { return GetToken(CymbolParser.ID, 0); }
        /// <summary>
        /// Initializes a new instance of the <see cref="IdContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public IdContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_id; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterId(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitId(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitId(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Identifiers this instance.
    /// </summary>
    /// <returns>IdContext.</returns>
    [RuleVersion(0)]
	public IdContext id() {
		IdContext _localctx = new IdContext(Context, State);
		EnterRule(_localctx, 30, RULE_id);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 171; Match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Class IntContext.
    /// Implements the <see cref="Antlr4.Runtime.ParserRuleContext" />
    /// </summary>
    /// <seealso cref="Antlr4.Runtime.ParserRuleContext" />
    public partial class IntContext : ParserRuleContext {
        /// <summary>
        /// Ints this instance.
        /// </summary>
        /// <returns>ITerminalNode.</returns>
        public ITerminalNode INT() { return GetToken(CymbolParser.INT, 0); }
        /// <summary>
        /// Initializes a new instance of the <see cref="IntContext" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="invokingState">State of the invoking.</param>
        public IntContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
        /// <summary>
        /// Gets the index of the rule.
        /// </summary>
        /// <value>The index of the rule.</value>
        public override int RuleIndex { get { return RULE_int; } }
        /// <summary>
        /// Enters the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void EnterRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.EnterInt(this);
		}
        /// <summary>
        /// Exits the rule.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public override void ExitRule(IParseTreeListener listener) {
			ICymbolListener typedListener = listener as ICymbolListener;
			if (typedListener != null) typedListener.ExitInt(this);
		}
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <returns>TResult.</returns>
        public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICymbolVisitor<TResult> typedVisitor = visitor as ICymbolVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInt(this);
			else return visitor.VisitChildren(this);
		}
	}

    /// <summary>
    /// Ints this instance.
    /// </summary>
    /// <returns>IntContext.</returns>
    [RuleVersion(0)]
	public IntContext @int() {
		IntContext _localctx = new IntContext(Context, State);
		EnterRule(_localctx, 32, RULE_int);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 173; Match(INT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

    /// <summary>
    /// Sempreds the specified localctx.
    /// </summary>
    /// <param name="_localctx">The localctx.</param>
    /// <param name="ruleIndex">Index of the rule.</param>
    /// <param name="predIndex">Index of the pred.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 14: return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
    /// <summary>
    /// Exprs the sempred.
    /// </summary>
    /// <param name="_localctx">The localctx.</param>
    /// <param name="predIndex">Index of the pred.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 8);
		case 1: return Precpred(Context, 7);
		case 2: return Precpred(Context, 6);
		case 3: return Precpred(Context, 5);
		}
		return true;
	}

    /// <summary>
    /// The serialized atn
    /// </summary>
    private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', ' ', '\xB2', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', 
		'\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', '\t', 
		'\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x3', '\x2', '\x3', 
		'\x2', '\x6', '\x2', '\'', '\n', '\x2', '\r', '\x2', '\xE', '\x2', '(', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x5', '\x3', 
		'/', '\n', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\a', '\x4', '\x37', '\n', '\x4', '\f', '\x4', 
		'\xE', '\x4', ':', '\v', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x5', '\x6', 'O', '\n', '\x6', '\x3', '\a', '\x3', '\a', 
		'\a', '\a', 'S', '\n', '\a', '\f', '\a', '\xE', '\a', 'V', '\v', '\a', 
		'\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', 
		'\b', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', 
		'\x3', '\t', '\x3', '\t', '\x5', '\t', '\x65', '\n', '\t', '\x3', '\n', 
		'\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', 
		'\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\a', '\f', 'w', '\n', 
		'\f', '\f', '\f', '\xE', '\f', 'z', '\v', '\f', '\x3', '\r', '\x3', '\r', 
		'\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x5', '\x10', '\x95', '\n', '\x10', 
		'\x3', '\x10', '\x5', '\x10', '\x98', '\n', '\x10', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\a', '\x10', '\xA9', 
		'\n', '\x10', '\f', '\x10', '\xE', '\x10', '\xAC', '\v', '\x10', '\x3', 
		'\x11', '\x3', '\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x2', 
		'\x3', '\x1E', '\x13', '\x2', '\x4', '\x6', '\b', '\n', '\f', '\xE', '\x10', 
		'\x12', '\x14', '\x16', '\x18', '\x1A', '\x1C', '\x1E', ' ', '\"', '\x2', 
		'\x5', '\x3', '\x2', '\x12', '\x13', '\x4', '\x2', '\x10', '\x10', '\x14', 
		'\x14', '\x3', '\x2', '\x15', '\x18', '\x2', '\xB8', '\x2', '&', '\x3', 
		'\x2', '\x2', '\x2', '\x4', '*', '\x3', '\x2', '\x2', '\x2', '\x6', '\x33', 
		'\x3', '\x2', '\x2', '\x2', '\b', ';', '\x3', '\x2', '\x2', '\x2', '\n', 
		'N', '\x3', '\x2', '\x2', '\x2', '\f', 'P', '\x3', '\x2', '\x2', '\x2', 
		'\xE', 'Y', '\x3', '\x2', '\x2', '\x2', '\x10', ']', '\x3', '\x2', '\x2', 
		'\x2', '\x12', '\x66', '\x3', '\x2', '\x2', '\x2', '\x14', 'p', '\x3', 
		'\x2', '\x2', '\x2', '\x16', 's', '\x3', '\x2', '\x2', '\x2', '\x18', 
		'{', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x80', '\x3', '\x2', '\x2', 
		'\x2', '\x1C', '\x84', '\x3', '\x2', '\x2', '\x2', '\x1E', '\x97', '\x3', 
		'\x2', '\x2', '\x2', ' ', '\xAD', '\x3', '\x2', '\x2', '\x2', '\"', '\xAF', 
		'\x3', '\x2', '\x2', '\x2', '$', '\'', '\x5', '\x4', '\x3', '\x2', '%', 
		'\'', '\x5', '\x1A', '\xE', '\x2', '&', '$', '\x3', '\x2', '\x2', '\x2', 
		'&', '%', '\x3', '\x2', '\x2', '\x2', '\'', '(', '\x3', '\x2', '\x2', 
		'\x2', '(', '&', '\x3', '\x2', '\x2', '\x2', '(', ')', '\x3', '\x2', '\x2', 
		'\x2', ')', '\x3', '\x3', '\x2', '\x2', '\x2', '*', '+', '\x5', '\x1C', 
		'\xF', '\x2', '+', ',', '\a', '\x1D', '\x2', '\x2', ',', '.', '\a', '\x3', 
		'\x2', '\x2', '-', '/', '\x5', '\x6', '\x4', '\x2', '.', '-', '\x3', '\x2', 
		'\x2', '\x2', '.', '/', '\x3', '\x2', '\x2', '\x2', '/', '\x30', '\x3', 
		'\x2', '\x2', '\x2', '\x30', '\x31', '\a', '\x4', '\x2', '\x2', '\x31', 
		'\x32', '\x5', '\f', '\a', '\x2', '\x32', '\x5', '\x3', '\x2', '\x2', 
		'\x2', '\x33', '\x38', '\x5', '\b', '\x5', '\x2', '\x34', '\x35', '\a', 
		'\x5', '\x2', '\x2', '\x35', '\x37', '\x5', '\b', '\x5', '\x2', '\x36', 
		'\x34', '\x3', '\x2', '\x2', '\x2', '\x37', ':', '\x3', '\x2', '\x2', 
		'\x2', '\x38', '\x36', '\x3', '\x2', '\x2', '\x2', '\x38', '\x39', '\x3', 
		'\x2', '\x2', '\x2', '\x39', '\a', '\x3', '\x2', '\x2', '\x2', ':', '\x38', 
		'\x3', '\x2', '\x2', '\x2', ';', '<', '\x5', '\x1C', '\xF', '\x2', '<', 
		'=', '\a', '\x1D', '\x2', '\x2', '=', '\t', '\x3', '\x2', '\x2', '\x2', 
		'>', 'O', '\x5', '\f', '\a', '\x2', '?', 'O', '\x5', '\x1A', '\xE', '\x2', 
		'@', 'O', '\x5', '\x10', '\t', '\x2', '\x41', 'O', '\x5', '\x12', '\n', 
		'\x2', '\x42', '\x43', '\x5', '\x14', '\v', '\x2', '\x43', '\x44', '\a', 
		'\x6', '\x2', '\x2', '\x44', 'O', '\x3', '\x2', '\x2', '\x2', '\x45', 
		'\x46', '\x5', '\xE', '\b', '\x2', '\x46', 'G', '\a', '\x6', '\x2', '\x2', 
		'G', 'O', '\x3', '\x2', '\x2', '\x2', 'H', 'I', '\x5', '\x18', '\r', '\x2', 
		'I', 'J', '\a', '\x6', '\x2', '\x2', 'J', 'O', '\x3', '\x2', '\x2', '\x2', 
		'K', 'L', '\x5', '\x1E', '\x10', '\x2', 'L', 'M', '\a', '\x6', '\x2', 
		'\x2', 'M', 'O', '\x3', '\x2', '\x2', '\x2', 'N', '>', '\x3', '\x2', '\x2', 
		'\x2', 'N', '?', '\x3', '\x2', '\x2', '\x2', 'N', '@', '\x3', '\x2', '\x2', 
		'\x2', 'N', '\x41', '\x3', '\x2', '\x2', '\x2', 'N', '\x42', '\x3', '\x2', 
		'\x2', '\x2', 'N', '\x45', '\x3', '\x2', '\x2', '\x2', 'N', 'H', '\x3', 
		'\x2', '\x2', '\x2', 'N', 'K', '\x3', '\x2', '\x2', '\x2', 'O', '\v', 
		'\x3', '\x2', '\x2', '\x2', 'P', 'T', '\a', '\a', '\x2', '\x2', 'Q', 'S', 
		'\x5', '\n', '\x6', '\x2', 'R', 'Q', '\x3', '\x2', '\x2', '\x2', 'S', 
		'V', '\x3', '\x2', '\x2', '\x2', 'T', 'R', '\x3', '\x2', '\x2', '\x2', 
		'T', 'U', '\x3', '\x2', '\x2', '\x2', 'U', 'W', '\x3', '\x2', '\x2', '\x2', 
		'V', 'T', '\x3', '\x2', '\x2', '\x2', 'W', 'X', '\a', '\b', '\x2', '\x2', 
		'X', '\r', '\x3', '\x2', '\x2', '\x2', 'Y', 'Z', '\a', '\x1D', '\x2', 
		'\x2', 'Z', '[', '\a', '\t', '\x2', '\x2', '[', '\\', '\x5', '\x1E', '\x10', 
		'\x2', '\\', '\xF', '\x3', '\x2', '\x2', '\x2', ']', '^', '\a', '\n', 
		'\x2', '\x2', '^', '_', '\a', '\x3', '\x2', '\x2', '_', '`', '\x5', '\x1E', 
		'\x10', '\x2', '`', '\x61', '\a', '\x4', '\x2', '\x2', '\x61', '\x64', 
		'\x5', '\n', '\x6', '\x2', '\x62', '\x63', '\a', '\v', '\x2', '\x2', '\x63', 
		'\x65', '\x5', '\n', '\x6', '\x2', '\x64', '\x62', '\x3', '\x2', '\x2', 
		'\x2', '\x64', '\x65', '\x3', '\x2', '\x2', '\x2', '\x65', '\x11', '\x3', 
		'\x2', '\x2', '\x2', '\x66', 'g', '\a', '\f', '\x2', '\x2', 'g', 'h', 
		'\a', '\x3', '\x2', '\x2', 'h', 'i', '\x5', '\xE', '\b', '\x2', 'i', 'j', 
		'\a', '\x6', '\x2', '\x2', 'j', 'k', '\x5', '\x1E', '\x10', '\x2', 'k', 
		'l', '\a', '\x6', '\x2', '\x2', 'l', 'm', '\x5', '\xE', '\b', '\x2', 'm', 
		'n', '\a', '\x4', '\x2', '\x2', 'n', 'o', '\x5', '\f', '\a', '\x2', 'o', 
		'\x13', '\x3', '\x2', '\x2', '\x2', 'p', 'q', '\a', '\r', '\x2', '\x2', 
		'q', 'r', '\x5', '\x1E', '\x10', '\x2', 'r', '\x15', '\x3', '\x2', '\x2', 
		'\x2', 's', 'x', '\x5', '\x1E', '\x10', '\x2', 't', 'u', '\a', '\x5', 
		'\x2', '\x2', 'u', 'w', '\x5', '\x1E', '\x10', '\x2', 'v', 't', '\x3', 
		'\x2', '\x2', '\x2', 'w', 'z', '\x3', '\x2', '\x2', '\x2', 'x', 'v', '\x3', 
		'\x2', '\x2', '\x2', 'x', 'y', '\x3', '\x2', '\x2', '\x2', 'y', '\x17', 
		'\x3', '\x2', '\x2', '\x2', 'z', 'x', '\x3', '\x2', '\x2', '\x2', '{', 
		'|', '\a', '\xE', '\x2', '\x2', '|', '}', '\a', '\x3', '\x2', '\x2', '}', 
		'~', '\x5', '\x1E', '\x10', '\x2', '~', '\x7F', '\a', '\x4', '\x2', '\x2', 
		'\x7F', '\x19', '\x3', '\x2', '\x2', '\x2', '\x80', '\x81', '\x5', '\x1C', 
		'\xF', '\x2', '\x81', '\x82', '\a', '\x1D', '\x2', '\x2', '\x82', '\x83', 
		'\a', '\x6', '\x2', '\x2', '\x83', '\x1B', '\x3', '\x2', '\x2', '\x2', 
		'\x84', '\x85', '\a', '\xF', '\x2', '\x2', '\x85', '\x1D', '\x3', '\x2', 
		'\x2', '\x2', '\x86', '\x87', '\b', '\x10', '\x1', '\x2', '\x87', '\x88', 
		'\a', '\x10', '\x2', '\x2', '\x88', '\x98', '\x5', '\x1E', '\x10', '\f', 
		'\x89', '\x8A', '\a', '\x11', '\x2', '\x2', '\x8A', '\x98', '\x5', '\x1E', 
		'\x10', '\v', '\x8B', '\x98', '\a', '\x1D', '\x2', '\x2', '\x8C', '\x98', 
		'\a', '\x1E', '\x2', '\x2', '\x8D', '\x8E', '\a', '\x3', '\x2', '\x2', 
		'\x8E', '\x8F', '\x5', '\x1E', '\x10', '\x2', '\x8F', '\x90', '\a', '\x4', 
		'\x2', '\x2', '\x90', '\x98', '\x3', '\x2', '\x2', '\x2', '\x91', '\x92', 
		'\a', '\x1D', '\x2', '\x2', '\x92', '\x94', '\a', '\x3', '\x2', '\x2', 
		'\x93', '\x95', '\x5', '\x16', '\f', '\x2', '\x94', '\x93', '\x3', '\x2', 
		'\x2', '\x2', '\x94', '\x95', '\x3', '\x2', '\x2', '\x2', '\x95', '\x96', 
		'\x3', '\x2', '\x2', '\x2', '\x96', '\x98', '\a', '\x4', '\x2', '\x2', 
		'\x97', '\x86', '\x3', '\x2', '\x2', '\x2', '\x97', '\x89', '\x3', '\x2', 
		'\x2', '\x2', '\x97', '\x8B', '\x3', '\x2', '\x2', '\x2', '\x97', '\x8C', 
		'\x3', '\x2', '\x2', '\x2', '\x97', '\x8D', '\x3', '\x2', '\x2', '\x2', 
		'\x97', '\x91', '\x3', '\x2', '\x2', '\x2', '\x98', '\xAA', '\x3', '\x2', 
		'\x2', '\x2', '\x99', '\x9A', '\f', '\n', '\x2', '\x2', '\x9A', '\x9B', 
		'\t', '\x2', '\x2', '\x2', '\x9B', '\xA9', '\x5', '\x1E', '\x10', '\v', 
		'\x9C', '\x9D', '\f', '\t', '\x2', '\x2', '\x9D', '\x9E', '\t', '\x3', 
		'\x2', '\x2', '\x9E', '\xA9', '\x5', '\x1E', '\x10', '\n', '\x9F', '\xA0', 
		'\f', '\b', '\x2', '\x2', '\xA0', '\xA1', '\t', '\x4', '\x2', '\x2', '\xA1', 
		'\xA9', '\x5', '\x1E', '\x10', '\t', '\xA2', '\xA3', '\f', '\a', '\x2', 
		'\x2', '\xA3', '\xA4', '\a', '\x19', '\x2', '\x2', '\xA4', '\xA5', '\x5', 
		'\x1E', '\x10', '\x2', '\xA5', '\xA6', '\a', '\x1A', '\x2', '\x2', '\xA6', 
		'\xA7', '\x5', '\x1E', '\x10', '\b', '\xA7', '\xA9', '\x3', '\x2', '\x2', 
		'\x2', '\xA8', '\x99', '\x3', '\x2', '\x2', '\x2', '\xA8', '\x9C', '\x3', 
		'\x2', '\x2', '\x2', '\xA8', '\x9F', '\x3', '\x2', '\x2', '\x2', '\xA8', 
		'\xA2', '\x3', '\x2', '\x2', '\x2', '\xA9', '\xAC', '\x3', '\x2', '\x2', 
		'\x2', '\xAA', '\xA8', '\x3', '\x2', '\x2', '\x2', '\xAA', '\xAB', '\x3', 
		'\x2', '\x2', '\x2', '\xAB', '\x1F', '\x3', '\x2', '\x2', '\x2', '\xAC', 
		'\xAA', '\x3', '\x2', '\x2', '\x2', '\xAD', '\xAE', '\a', '\x1D', '\x2', 
		'\x2', '\xAE', '!', '\x3', '\x2', '\x2', '\x2', '\xAF', '\xB0', '\a', 
		'\x1E', '\x2', '\x2', '\xB0', '#', '\x3', '\x2', '\x2', '\x2', '\xE', 
		'&', '(', '.', '\x38', 'N', 'T', '\x64', 'x', '\x94', '\x97', '\xA8', 
		'\xAA',
	};

    /// <summary>
    /// The atn
    /// </summary>
    public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
