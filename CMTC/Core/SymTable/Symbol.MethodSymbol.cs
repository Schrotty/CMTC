using System.Collections.Generic;

namespace CMTC.Core.SymTable
{
    public partial class Symbol
    {
        public class MethodSymbol : Symbol, IScope
        {
            private Dictionary<string, Symbol> _symbols = new Dictionary<string, Symbol>();

            private IScope _enclosing;
            public IScope Child { get; private set; }

            public MethodSymbol(string name) : base(name, 0)
            {
            }

            public MethodSymbol(string name, SymbolType type) : base(name, 0, type)
            {
            }

            public MethodSymbol(string name, SymbolType returnType, IScope enclosing) : base(name, 0, returnType)
            {
                _enclosing = enclosing;
            }

            public void Define(Symbol symbol)
            {
                _symbols.Add(symbol.Name, symbol);
            }

            public Symbol GetChild(string name)
            {
                Symbol symbol;
                _symbols.TryGetValue(name, out symbol);

                return symbol;
            }

            public IScope GetChild(int index = 0)
            {
                return Child;
            }

            public IScope GetEnclosingScope()
            {
                return _enclosing;
            }

            public string GetScopeName()
            {
                return Name;
            }

            public Symbol GetSymbol(string name)
            {
                Symbol symbol;
                _symbols.TryGetValue(name, out symbol);

                if (symbol == null)
                {
                    symbol = Child.GetSymbol(name);
                    if (symbol != null)
                    {
                        return symbol;
                    }
                }

                return symbol;
            }

            public Symbol GetSymbolGlobal(string name)
            {
                return _enclosing.GetSymbol(name);
            }

            public SymbolType Resolve(string name)
            {
                Symbol symbol = GetSymbol(name);
                return symbol == null ? SymbolType.NONE : symbol.Type;
            }

            public bool VariableIsInScope(string id)
            {
                return Resolve(id) != Symbol.SymbolType.NONE;
            }

            public bool VariableIsInScopeNested(string id)
            {
                return VariableIsInScope(id);
            }

            public IScope AddChild(IScope child)
            {
                Child = child;
                return Child;
            }

            public IScope GetMethod(string name)
            {
                return Child;
            }

            public void SetNextIndex(int index)
            {
                Position = index;
            }

            public Symbol GetSymbolLocal(string name)
            {
                _symbols.TryGetValue(name, out var val);

                return val;
            }
        }
    }
}
