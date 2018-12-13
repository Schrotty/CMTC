using CMTC.Core.SymTable;
using static CMTC.Core.SymTable.Symbol;
using static CymbolParser;

namespace CMTC.Core.Extensions
{
    static class FunctionDeclContextExt
    {
        public static bool HasValidReturnStatement(this FunctionDeclContext context, MethodSymbol method, IScope scope)
        {
            bool result = false;
            bool isVoid = false;

            var stats = context.block().stat();
            if (stats != null)
            {
                foreach (var item in stats)
                {
                    result = item.returnStat() != null;
                }
            }

            if (method.Type != scope.Resolve("void")) isVoid = true;

            return result ^ !isVoid;
        }
    }
}
