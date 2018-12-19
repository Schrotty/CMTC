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
        void SetNextIndex(int index);

        bool VariableIsInScope(string id);
        bool VariableIsInScopeNested(string id);

        Symbol GetSymbol(string name);
        Symbol GetSymbolGlobal(string name);
        Symbol GetSymbolLocal(string name);

        IScope GetMethod(string name);
        IScope GetChild(int index);
        IScope AddChild(IScope child);
    }
}
