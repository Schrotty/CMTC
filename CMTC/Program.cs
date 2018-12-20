using CMTC.Core;
using CMTC.Utilities;

namespace CMTC
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationSettings.AppySettings(args);
            CMTCompiler.Execute(FileUtilities.ReadFile(args[args.Length - 1]));
        }
    }
}
