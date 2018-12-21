// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="CymbolLexer.cs" company="CMTC">
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

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

/// <summary>
/// Class CymbolLexer.
/// Implements the <see cref="Antlr4.Runtime.Lexer" />
/// </summary>
/// <seealso cref="Antlr4.Runtime.Lexer" />
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class CymbolLexer : Lexer {
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
    /// The channel names
    /// </summary>
    public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

    /// <summary>
    /// The mode names
    /// </summary>
    public static string[] modeNames = {
		"DEFAULT_MODE"
	};

    /// <summary>
    /// The rule names
    /// </summary>
    public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "T__23", "STRING", 
		"BOOL", "ID", "INT", "LETTER", "DIGIT", "WS", "COMMENT"
	};


    /// <summary>
    /// Initializes a new instance of the <see cref="CymbolLexer" /> class.
    /// </summary>
    /// <param name="input">The input.</param>
    public CymbolLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CymbolLexer" /> class.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="output">The output.</param>
    /// <param name="errorOutput">The error output.</param>
    public CymbolLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

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
    /// Gets the channel names.
    /// </summary>
    /// <value>The channel names.</value>
    public override string[] ChannelNames { get { return channelNames; } }

    /// <summary>
    /// Gets the mode names.
    /// </summary>
    /// <value>The mode names.</value>
    public override string[] ModeNames { get { return modeNames; } }

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
    /// Initializes static members of the <see cref="CymbolLexer" /> class.
    /// </summary>
    static CymbolLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
    /// <summary>
    /// The serialized atn
    /// </summary>
    private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', ' ', '\xBB', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', 
		'\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', 
		'\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', 
		'\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', 
		'\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', 
		'\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x3', 
		'\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', 
		'\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', 
		'\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', 
		'\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\a', 
		'\x1A', '\x8A', '\n', '\x1A', '\f', '\x1A', '\xE', '\x1A', '\x8D', '\v', 
		'\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', '\x3', '\x1B', '\x3', 
		'\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', 
		'\x1B', '\x3', '\x1B', '\x5', '\x1B', '\x9A', '\n', '\x1B', '\x3', '\x1C', 
		'\x3', '\x1C', '\x3', '\x1C', '\a', '\x1C', '\x9F', '\n', '\x1C', '\f', 
		'\x1C', '\xE', '\x1C', '\xA2', '\v', '\x1C', '\x3', '\x1D', '\x6', '\x1D', 
		'\xA5', '\n', '\x1D', '\r', '\x1D', '\xE', '\x1D', '\xA6', '\x3', '\x1E', 
		'\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', 
		' ', '\x3', ' ', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '!', '\a', 
		'!', '\xB5', '\n', '!', '\f', '!', '\xE', '!', '\xB8', '\v', '!', '\x3', 
		'!', '\x3', '!', '\x3', '\x8B', '\x2', '\"', '\x3', '\x3', '\x5', '\x4', 
		'\a', '\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', 
		'\n', '\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', 
		'\xF', '\x1D', '\x10', '\x1F', '\x11', '!', '\x12', '#', '\x13', '%', 
		'\x14', '\'', '\x15', ')', '\x16', '+', '\x17', '-', '\x18', '/', '\x19', 
		'\x31', '\x1A', '\x33', '\x1B', '\x35', '\x1C', '\x37', '\x1D', '\x39', 
		'\x1E', ';', '\x2', '=', '\x2', '?', '\x1F', '\x41', ' ', '\x3', '\x2', 
		'\x6', '\x4', '\x2', '\x43', '\\', '\x63', '|', '\x3', '\x2', '\x32', 
		';', '\x5', '\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', '\x4', '\x2', 
		'\f', '\f', '\xF', '\xF', '\x2', '\xBE', '\x2', '\x3', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', '\'', 
		'\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x33', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x39', '\x3', '\x2', '\x2', '\x2', '\x2', '?', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x41', '\x3', '\x2', '\x2', '\x2', '\x3', '\x43', '\x3', '\x2', 
		'\x2', '\x2', '\x5', '\x45', '\x3', '\x2', '\x2', '\x2', '\a', 'G', '\x3', 
		'\x2', '\x2', '\x2', '\t', 'I', '\x3', '\x2', '\x2', '\x2', '\v', 'K', 
		'\x3', '\x2', '\x2', '\x2', '\r', 'M', '\x3', '\x2', '\x2', '\x2', '\xF', 
		'O', '\x3', '\x2', '\x2', '\x2', '\x11', 'Q', '\x3', '\x2', '\x2', '\x2', 
		'\x13', 'T', '\x3', '\x2', '\x2', '\x2', '\x15', 'Y', '\x3', '\x2', '\x2', 
		'\x2', '\x17', ']', '\x3', '\x2', '\x2', '\x2', '\x19', '\x64', '\x3', 
		'\x2', '\x2', '\x2', '\x1B', 'k', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'o', '\x3', '\x2', '\x2', '\x2', '\x1F', 'q', '\x3', '\x2', '\x2', '\x2', 
		'!', 's', '\x3', '\x2', '\x2', '\x2', '#', 'u', '\x3', '\x2', '\x2', '\x2', 
		'%', 'w', '\x3', '\x2', '\x2', '\x2', '\'', 'y', '\x3', '\x2', '\x2', 
		'\x2', ')', '|', '\x3', '\x2', '\x2', '\x2', '+', '\x7F', '\x3', '\x2', 
		'\x2', '\x2', '-', '\x81', '\x3', '\x2', '\x2', '\x2', '/', '\x83', '\x3', 
		'\x2', '\x2', '\x2', '\x31', '\x85', '\x3', '\x2', '\x2', '\x2', '\x33', 
		'\x87', '\x3', '\x2', '\x2', '\x2', '\x35', '\x99', '\x3', '\x2', '\x2', 
		'\x2', '\x37', '\x9B', '\x3', '\x2', '\x2', '\x2', '\x39', '\xA4', '\x3', 
		'\x2', '\x2', '\x2', ';', '\xA8', '\x3', '\x2', '\x2', '\x2', '=', '\xAA', 
		'\x3', '\x2', '\x2', '\x2', '?', '\xAC', '\x3', '\x2', '\x2', '\x2', '\x41', 
		'\xB0', '\x3', '\x2', '\x2', '\x2', '\x43', '\x44', '\a', '*', '\x2', 
		'\x2', '\x44', '\x4', '\x3', '\x2', '\x2', '\x2', '\x45', '\x46', '\a', 
		'+', '\x2', '\x2', '\x46', '\x6', '\x3', '\x2', '\x2', '\x2', 'G', 'H', 
		'\a', '.', '\x2', '\x2', 'H', '\b', '\x3', '\x2', '\x2', '\x2', 'I', 'J', 
		'\a', '=', '\x2', '\x2', 'J', '\n', '\x3', '\x2', '\x2', '\x2', 'K', 'L', 
		'\a', '}', '\x2', '\x2', 'L', '\f', '\x3', '\x2', '\x2', '\x2', 'M', 'N', 
		'\a', '\x7F', '\x2', '\x2', 'N', '\xE', '\x3', '\x2', '\x2', '\x2', 'O', 
		'P', '\a', '?', '\x2', '\x2', 'P', '\x10', '\x3', '\x2', '\x2', '\x2', 
		'Q', 'R', '\a', 'k', '\x2', '\x2', 'R', 'S', '\a', 'h', '\x2', '\x2', 
		'S', '\x12', '\x3', '\x2', '\x2', '\x2', 'T', 'U', '\a', 'g', '\x2', '\x2', 
		'U', 'V', '\a', 'n', '\x2', '\x2', 'V', 'W', '\a', 'u', '\x2', '\x2', 
		'W', 'X', '\a', 'g', '\x2', '\x2', 'X', '\x14', '\x3', '\x2', '\x2', '\x2', 
		'Y', 'Z', '\a', 'h', '\x2', '\x2', 'Z', '[', '\a', 'q', '\x2', '\x2', 
		'[', '\\', '\a', 't', '\x2', '\x2', '\\', '\x16', '\x3', '\x2', '\x2', 
		'\x2', ']', '^', '\a', 't', '\x2', '\x2', '^', '_', '\a', 'g', '\x2', 
		'\x2', '_', '`', '\a', 'v', '\x2', '\x2', '`', '\x61', '\a', 'w', '\x2', 
		'\x2', '\x61', '\x62', '\a', 't', '\x2', '\x2', '\x62', '\x63', '\a', 
		'p', '\x2', '\x2', '\x63', '\x18', '\x3', '\x2', '\x2', '\x2', '\x64', 
		'\x65', '\a', 'r', '\x2', '\x2', '\x65', '\x66', '\a', 't', '\x2', '\x2', 
		'\x66', 'g', '\a', 'k', '\x2', '\x2', 'g', 'h', '\a', 'p', '\x2', '\x2', 
		'h', 'i', '\a', 'v', '\x2', '\x2', 'i', 'j', '\a', 'h', '\x2', '\x2', 
		'j', '\x1A', '\x3', '\x2', '\x2', '\x2', 'k', 'l', '\a', 'k', '\x2', '\x2', 
		'l', 'm', '\a', 'p', '\x2', '\x2', 'm', 'n', '\a', 'v', '\x2', '\x2', 
		'n', '\x1C', '\x3', '\x2', '\x2', '\x2', 'o', 'p', '\a', '/', '\x2', '\x2', 
		'p', '\x1E', '\x3', '\x2', '\x2', '\x2', 'q', 'r', '\a', '#', '\x2', '\x2', 
		'r', ' ', '\x3', '\x2', '\x2', '\x2', 's', 't', '\a', ',', '\x2', '\x2', 
		't', '\"', '\x3', '\x2', '\x2', '\x2', 'u', 'v', '\a', '\x31', '\x2', 
		'\x2', 'v', '$', '\x3', '\x2', '\x2', '\x2', 'w', 'x', '\a', '-', '\x2', 
		'\x2', 'x', '&', '\x3', '\x2', '\x2', '\x2', 'y', 'z', '\a', '?', '\x2', 
		'\x2', 'z', '{', '\a', '?', '\x2', '\x2', '{', '(', '\x3', '\x2', '\x2', 
		'\x2', '|', '}', '\a', '#', '\x2', '\x2', '}', '~', '\a', '?', '\x2', 
		'\x2', '~', '*', '\x3', '\x2', '\x2', '\x2', '\x7F', '\x80', '\a', '>', 
		'\x2', '\x2', '\x80', ',', '\x3', '\x2', '\x2', '\x2', '\x81', '\x82', 
		'\a', '@', '\x2', '\x2', '\x82', '.', '\x3', '\x2', '\x2', '\x2', '\x83', 
		'\x84', '\a', '\x41', '\x2', '\x2', '\x84', '\x30', '\x3', '\x2', '\x2', 
		'\x2', '\x85', '\x86', '\a', '<', '\x2', '\x2', '\x86', '\x32', '\x3', 
		'\x2', '\x2', '\x2', '\x87', '\x8B', '\a', '$', '\x2', '\x2', '\x88', 
		'\x8A', '\v', '\x2', '\x2', '\x2', '\x89', '\x88', '\x3', '\x2', '\x2', 
		'\x2', '\x8A', '\x8D', '\x3', '\x2', '\x2', '\x2', '\x8B', '\x8C', '\x3', 
		'\x2', '\x2', '\x2', '\x8B', '\x89', '\x3', '\x2', '\x2', '\x2', '\x8C', 
		'\x8E', '\x3', '\x2', '\x2', '\x2', '\x8D', '\x8B', '\x3', '\x2', '\x2', 
		'\x2', '\x8E', '\x8F', '\a', '$', '\x2', '\x2', '\x8F', '\x34', '\x3', 
		'\x2', '\x2', '\x2', '\x90', '\x91', '\a', 'v', '\x2', '\x2', '\x91', 
		'\x92', '\a', 't', '\x2', '\x2', '\x92', '\x93', '\a', 'w', '\x2', '\x2', 
		'\x93', '\x9A', '\a', 'g', '\x2', '\x2', '\x94', '\x95', '\a', 'h', '\x2', 
		'\x2', '\x95', '\x96', '\a', '\x63', '\x2', '\x2', '\x96', '\x97', '\a', 
		'n', '\x2', '\x2', '\x97', '\x98', '\a', 'u', '\x2', '\x2', '\x98', '\x9A', 
		'\a', 'g', '\x2', '\x2', '\x99', '\x90', '\x3', '\x2', '\x2', '\x2', '\x99', 
		'\x94', '\x3', '\x2', '\x2', '\x2', '\x9A', '\x36', '\x3', '\x2', '\x2', 
		'\x2', '\x9B', '\xA0', '\x5', ';', '\x1E', '\x2', '\x9C', '\x9F', '\x5', 
		';', '\x1E', '\x2', '\x9D', '\x9F', '\x5', '=', '\x1F', '\x2', '\x9E', 
		'\x9C', '\x3', '\x2', '\x2', '\x2', '\x9E', '\x9D', '\x3', '\x2', '\x2', 
		'\x2', '\x9F', '\xA2', '\x3', '\x2', '\x2', '\x2', '\xA0', '\x9E', '\x3', 
		'\x2', '\x2', '\x2', '\xA0', '\xA1', '\x3', '\x2', '\x2', '\x2', '\xA1', 
		'\x38', '\x3', '\x2', '\x2', '\x2', '\xA2', '\xA0', '\x3', '\x2', '\x2', 
		'\x2', '\xA3', '\xA5', '\x5', '=', '\x1F', '\x2', '\xA4', '\xA3', '\x3', 
		'\x2', '\x2', '\x2', '\xA5', '\xA6', '\x3', '\x2', '\x2', '\x2', '\xA6', 
		'\xA4', '\x3', '\x2', '\x2', '\x2', '\xA6', '\xA7', '\x3', '\x2', '\x2', 
		'\x2', '\xA7', ':', '\x3', '\x2', '\x2', '\x2', '\xA8', '\xA9', '\t', 
		'\x2', '\x2', '\x2', '\xA9', '<', '\x3', '\x2', '\x2', '\x2', '\xAA', 
		'\xAB', '\t', '\x3', '\x2', '\x2', '\xAB', '>', '\x3', '\x2', '\x2', '\x2', 
		'\xAC', '\xAD', '\t', '\x4', '\x2', '\x2', '\xAD', '\xAE', '\x3', '\x2', 
		'\x2', '\x2', '\xAE', '\xAF', '\b', ' ', '\x2', '\x2', '\xAF', '@', '\x3', 
		'\x2', '\x2', '\x2', '\xB0', '\xB1', '\a', '\x31', '\x2', '\x2', '\xB1', 
		'\xB2', '\a', '\x31', '\x2', '\x2', '\xB2', '\xB6', '\x3', '\x2', '\x2', 
		'\x2', '\xB3', '\xB5', '\n', '\x5', '\x2', '\x2', '\xB4', '\xB3', '\x3', 
		'\x2', '\x2', '\x2', '\xB5', '\xB8', '\x3', '\x2', '\x2', '\x2', '\xB6', 
		'\xB4', '\x3', '\x2', '\x2', '\x2', '\xB6', '\xB7', '\x3', '\x2', '\x2', 
		'\x2', '\xB7', '\xB9', '\x3', '\x2', '\x2', '\x2', '\xB8', '\xB6', '\x3', 
		'\x2', '\x2', '\x2', '\xB9', '\xBA', '\b', '!', '\x2', '\x2', '\xBA', 
		'\x42', '\x3', '\x2', '\x2', '\x2', '\t', '\x2', '\x8B', '\x99', '\x9E', 
		'\xA0', '\xA6', '\xB6', '\x3', '\b', '\x2', '\x2',
	};

    /// <summary>
    /// The atn
    /// </summary>
    public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
