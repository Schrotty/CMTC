// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="BaseScope.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using static CMTC.Core.SymTable.Symbol;

/// <summary>
/// The SymTable namespace.
/// </summary>
namespace CMTC.Core.SymTable
{
    /// <summary>
    /// Class BaseScope.
    /// Implements the <see cref="CMTC.Core.SymTable.IScope" />
    /// </summary>
    /// <seealso cref="CMTC.Core.SymTable.IScope" />
    abstract partial class BaseScope : IScope
    {
        /// <summary>
        /// The symbols
        /// </summary>
        private Dictionary<string, Symbol> _symbols = new Dictionary<string, Symbol>();

        /// <summary>
        /// The enclosing
        /// </summary>
        private IScope _enclosing;

        private int _localMaxIndex = 0;

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        public List<IScope> Children { get; private set; }

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        /// <returns>System.String.</returns>
        public abstract string GetScopeName();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseScope" /> class.
        /// </summary>
        /// <param name="enclosing">The enclosing.</param>
        public BaseScope(IScope enclosing)
        {
            _enclosing = enclosing;
            Children = new List<IScope>();
        }

        /// <summary>
        /// Defines the specified symbol.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        public void Define(Symbol symbol)
        {
            if (_symbols.TryGetValue(symbol.Name, out var o))
            {
                _symbols.Remove(symbol.Name);
            }

            _symbols.Add(symbol.Name, symbol);
            _localMaxIndex = symbol.Position;
        }

        /// <summary>
        /// Gets the enclosing scope.
        /// </summary>
        /// <returns>IScope.</returns>
        public IScope GetEnclosingScope()
        {
            return _enclosing;
        }

        /// <summary>
        /// Resolves the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>SymbolType.</returns>
        public SymbolType Resolve(string name)
        {
            return _symbols.GetValueOrDefault(name, Symbol.NONE).Type;
        }

        /// <summary>
        /// Variables the is in scope.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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

        /// <summary>
        /// Variables the is in scope nested.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool VariableIsInScopeNested(string id)
        {
            bool inScope = Resolve(id) != Symbol.SymbolType.NONE;
            return !inScope ? VariableIsInScopeNested(id, GetEnclosingScope()) : inScope;
        }

        /// <summary>
        /// Variables the is in scope nested.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="scope">The scope.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool VariableIsInScopeNested(string id, IScope scope)
        {
            if (scope == null) return false;

            bool inScope = scope.VariableIsInScope(id);
            return inScope ? true : VariableIsInScopeNested(id, scope.GetEnclosingScope());
        }

        /// <summary>
        /// Gets the child.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Symbol.</returns>
        public Symbol GetChild(string name)
        {
            Symbol symbol = new Symbol(name, 0);
            _symbols.TryGetValue(name, out symbol);

            return symbol;
        }

        /// <summary>
        /// Gets the symbol.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Symbol.</returns>
        public Symbol GetSymbol(string name)
        {
            Symbol symbol;
            var b = _symbols.TryGetValue(name, out symbol);

            if (symbol == null)
            {
                symbol = _enclosing.GetSymbolLocal(name);
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

                return symbol;
            }

            return b ? symbol : null;
        }

        /// <summary>
        /// Gets the symbol global.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Symbol.</returns>
        public Symbol GetSymbolGlobal(string name)
        {
            var tmp = GetScopeName().Equals("global") ? this : _enclosing;
            while (!tmp.GetScopeName().Equals("global"))
            {
                tmp = tmp.GetEnclosingScope();
                if (tmp.GetScopeName().Equals("global"))
                {
                    _symbols.TryGetValue(name, out var symbol);
                    return symbol;
                }
            }
            
            return null;
        }

        /// <summary>
        /// Gets the symbol local.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Symbol.</returns>
        public Symbol GetSymbolLocal(string name)
        {
            _symbols.TryGetValue(name, out var val);

            return val;
        }

        /// <summary>
        /// Gets the child.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>IScope.</returns>
        public IScope GetChild(int index)
        {
            return Children[index];
        }

        /// <summary>
        /// Adds the child.
        /// </summary>
        /// <param name="child">The child.</param>
        /// <returns>IScope.</returns>
        public IScope AddChild(IScope child)
        {
            Children.Add(child);

            return child;
        }

        /// <summary>
        /// Gets the method.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IScope.</returns>
        public IScope GetMethod(string name)
        {
            if (name == null) return this;
            return Children.Find(c => c.GetScopeName().Equals(name));
        }

        /// <summary>
        /// Increases the index.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int IncreasedIndex()
        {
            return GetIndex() + 1;
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int GetIndex()
        {
            if (_symbols.Count <= 0) return _localMaxIndex;
            var pos = _symbols.Max(pair =>
            {
                return pair.Value.Position;
            });

            return pos > _localMaxIndex ? pos : _localMaxIndex;
        }

        public Symbol GetSymbol(int identifier)
        {
            return _symbols.Where(pair => pair.Value.Position == identifier).First().Value;
        }
    }
}
