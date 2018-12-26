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
using System;

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
        private CMTCompiler(string source)
        {
            var input = CharStreams.fromstring(source);
            var lexer = new CymbolLexer(input);

            var tokens = new CommonTokenStream(lexer);
            var parser = new CymbolParser(tokens);

            var tree = parser.file();
            var visitor = new SemanticAnalyzer();
            var scope = visitor.Visit(tree);

            var generator = new CodeGenerator(scope);
            var code = generator.Visit(tree);

            Console.WriteLine(code.Render());
            Console.ReadKey();
        }

        /// <summary>
        /// Executes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        public static void Execute(string source)
        {
            new CMTCompiler(source);
        }
    }
}
