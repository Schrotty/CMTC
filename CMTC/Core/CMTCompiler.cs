using Antlr4.Runtime;

namespace CMTC.Core
{
    class CMTCompiler
    {
        private CMTCompiler(string source)
        {
            var input = CharStreams.fromstring(source);
        }

        public static void Execute(string source)
        {
            new CMTCompiler(source);
        }
    }
}
