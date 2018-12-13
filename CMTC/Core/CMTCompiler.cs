using Antlr4.Runtime;
using System;

namespace CMTC.Core
{
    class CMTCompiler
    {
        private CMTCompiler(string source)
        {
            var input = CharStreams.fromstring(source);
            var lexer = new CymbolLexer(input);

            var tokens = new CommonTokenStream(lexer);
            var parser = new CymbolParser(tokens);

            var tree = parser.file();
            var visitor = new SemanticAnalyser();
            var scope = visitor.Visit(tree);

            Console.ReadKey();
        }

        public static void Execute(string source)
        {
            new CMTCompiler(source);
        }
    }
}
