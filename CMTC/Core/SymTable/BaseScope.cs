using System.Collections.Generic;
using static CMTC.Core.SymTable.Symbol;

namespace CMTC.Core.SymTable
{
    abstract partial class BaseScope : IScope
    {
        private Dictionary<string, Symbol> _symbols = new Dictionary<string, Symbol>();

        private IScope _enclosing;

        public abstract string GetScopeName();
        public BaseScope(IScope enclosing)
        {
            _enclosing = enclosing;
        }

        public void Define(Symbol symbol)
        {
            _symbols.Add(symbol.Name, symbol);
        }

        public IScope GetEnclosingScope()
        {
            return _enclosing;
        }

        public SymbolType Resolve(string name)
        {
            return _symbols.GetValueOrDefault(name, Symbol.NONE).Type;
        }

        public bool VariableIsInScope(string id)
        {
            bool result = Resolve(id) != Symbol.SymbolType.NONE;
            if (GetEnclosingScope() != null)
            {
                var scopeName = GetEnclosingScope().GetScopeName();
                if (!scopeName.Equals("local") && !scopeName.Equals("global"))
                {
                    if (!result) result = GetEnclosingScope().Resolve(id) != SymbolType.NONE;
                }
            }

            return result;
        }

        public bool VariableIsInScopeNested(string id)
        {
            bool inScope = Resolve(id) != Symbol.SymbolType.NONE;
            return !inScope ? VariableIsInScopeNested(id, GetEnclosingScope()) : inScope;
        }

        private bool VariableIsInScopeNested(string id, IScope scope)
        {
            if (scope == null) return false;

            bool inScope = scope.VariableIsInScope(id);
            return inScope ? true : VariableIsInScopeNested(id, scope.GetEnclosingScope());
        }
    }
}
