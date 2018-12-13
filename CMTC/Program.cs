using CMTC.Core;
using System.IO;

namespace CMTC
{
    class Program
    {
        static void Main(string[] args)
        {
            CMTCompiler.Execute(File.ReadAllText(args[0]));
        }
    }
}
