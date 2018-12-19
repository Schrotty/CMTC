using System.Collections.Generic;
using static CMTC.Core.SymTable.Symbol;

namespace CMTC.Core.SymTable
{
    abstract partial class BaseScope : IScope
    {
        private Dictionary<string, Symbol> _symbols = new Dictionary<string, Symbol>();
        private IScope _enclosing;

        public List<IScope> Children { get; private set; }

        public abstract string GetScopeName();
        public BaseScope(IScope enclosing)
        {
            _enclosing = enclosing;
            Children = new List<IScope>();
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

        public Symbol GetChild(string name)
        {
            Symbol symbol = new Symbol(name, 0);
            _symbols.TryGetValue(name, out symbol);

            return symbol;
        }

        public Symbol GetSymbol(string name)
        {
            Symbol symbol;
            var b = _symbols.TryGetValue(name, out symbol);

            if (symbol == null)
            {
                foreach (var child in Children)
                {
                    symbol = child.GetSymbol(name);
                    if (symbol != null)
                    {
                        return symbol;
                    }
                }

                return GetSymbolGlobal(name);
            }

            return b ? symbol : null;
        }

        public Symbol GetSymbolGlobal(string name)
        {
            var tmp = GetScopeName().Equals("global") ? this : _enclosing;
            while (!tmp.GetScopeName().Equals("global"))
            {
                tmp = tmp.GetEnclosingScope();
                if (tmp.GetScopeName().Equals("global"))
                {
                    return tmp.GetSymbol(name);
                }
            }
            
            return null;
        }

        public Symbol GetSymbolLocal(string name)
        {
            _symbols.TryGetValue(name, out var val);

            return val;
        }

        public IScope GetChild(int index)
        {
            return Children[index];
        }

        public IScope AddChild(IScope child)
        {
            Children.Add(child);

            return child;
        }

        public IScope GetMethod(string name)
        {
            return Children.Find(c => c.GetScopeName().Equals(name));
        }

        public void SetNextIndex(int index)
        {
            //nothing
        }
    }
}
