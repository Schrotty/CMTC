using static CMTC.Core.SymTable.Symbol;

namespace CMTC.Core.SymTable
{
    public interface IScope
    {
        string GetScopeName();
        string ToString();
        void Define(Symbol symbol);
        IScope GetEnclosingScope();
        SymbolType Resolve(string name);

        bool VariableIsInScope(string id);
        bool VariableIsInScopeNested(string id);
    }
}
