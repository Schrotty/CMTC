using System.Collections.Generic;

namespace CMTC.Core.SymTable
{
    public partial class Symbol
    {
        public class MethodSymbol : Symbol, IScope
        {
            private Dictionary<string, Symbol> _symbols = new Dictionary<string, Symbol>();

            private List<Symbol> _arguments = new List<Symbol>();

            private IScope _enclosing;

            public MethodSymbol(string name) : base(name)
            {
            }

            public MethodSymbol(string name, SymbolType type) : base(name, type)
            {
            }

            public MethodSymbol(string name, SymbolType returnType, IScope enclosing) : base(name, returnType)
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

            public string GetScopeName()
            {
                return Name;
            }

            public SymbolType Resolve(string name)
            {
                Symbol symbol = _arguments.Find(s => s.Name.Equals(name));
                return symbol == null ? SymbolType.NONE : symbol.Type;
            }

            public bool VariableIsInScope(string id)
            {
                return false;
            }

            public bool VariableIsInScopeNested(string id)
            {
                return false;
            }
        }
    }
}
