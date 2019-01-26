// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="CMTCompiler.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.IO;

/// <summary>
/// The Core namespace.
/// </summary>
namespace CMTC.Core
{
    /// <summary>
    /// Class CMTCompiler.
    /// </summary>
    class CMTCompiler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CMTCompiler" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        private CMTCompiler(string filename, string source)
        {
            var input = CharStreams.fromstring(source);
            var lexer = new CymbolLexer(input);

            var tokens = new CommonTokenStream(lexer);
            var parser = new CymbolParser(tokens);

            var tree = parser.file();
            ParseTreeWalker walker = new ParseTreeWalker();
            walker.Walk(new Preprocessor(), tree);

            var visitor = new SemanticAnalyzer();
            var scope = visitor.Visit(tree);

            var generator = new CodeGenerator(scope);
            var code = generator.Visit(tree);

            File.WriteAllText(string.Format("./{0}.ll", filename), code.Render());
        }

        /// <summary>
        /// Executes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Execute(string filename, string source)
        {
            new CMTCompiler(filename, source);
        }
    }
}
