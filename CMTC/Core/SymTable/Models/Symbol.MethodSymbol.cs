// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Symbol.MethodSymbol.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The SymTable namespace.
/// </summary>
namespace CMTC.Core.SymTable
{
    /// <summary>
    /// Class Symbol.
    /// </summary>
    public partial class Symbol
    {
        /// <summary>
        /// Class MethodSymbol.
        /// Implements the <see cref="CMTC.Core.SymTable.Symbol" />
        /// Implements the <see cref="CMTC.Core.SymTable.IScope" />
        /// </summary>
        /// <seealso cref="CMTC.Core.SymTable.Symbol" />
        /// <seealso cref="CMTC.Core.SymTable.IScope" />
        public class MethodSymbol : Symbol, IScope
        {
            /// <summary>
            /// The symbols
            /// </summary>
            private Dictionary<string, Symbol> _symbols = new Dictionary<string, Symbol>();

            /// <summary>
            /// The enclosing
            /// </summary>
            private IScope _enclosing;
            /// <summary>
            /// Gets the child.
            /// </summary>
            /// <value>The child.</value>
            public IScope Child { get; private set; }

            /// <summary>
            /// Parameters this instance.
            /// </summary>
            /// <returns>List&lt;System.String&gt;.</returns>
            public List<string> Parameter
            {
                get => _symbols.Select(selector: entry => entry.Value).ToList()
                        .ConvertAll(entry => entry.Type.ToString()
                );
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="MethodSymbol" /> class.
            /// </summary>
            /// <param name="name">The name.</param>
            public MethodSymbol(string name) : base(name, 0)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="MethodSymbol" /> class.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <param name="type">The type.</param>
            public MethodSymbol(string name, SymbolType type) : base(name, 0, type)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="MethodSymbol" /> class.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <param name="returnType">Type of the return.</param>
            /// <param name="enclosing">The enclosing.</param>
            public MethodSymbol(string name, SymbolType returnType, IScope enclosing) : base(name, 0, returnType)
            {
                _enclosing = enclosing;
            }

            /// <summary>
            /// Defines the specified symbol.
            /// </summary>
            /// <param name="symbol">The symbol.</param>
            public void Define(Symbol symbol)
            {
                _symbols.Add(symbol.Name, symbol);
            }

            /// <summary>
            /// Gets the child.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <returns>Symbol.</returns>
            public Symbol GetChild(string name)
            {
                Symbol symbol;
                _symbols.TryGetValue(name, out symbol);

                return symbol;
            }

            /// <summary>
            /// Gets the child.
            /// </summary>
            /// <param name="index">The index.</param>
            /// <returns>IScope.</returns>
            public IScope GetChild(int index = 0)
            {
                return Child;
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
            /// Gets the name of the scope.
            /// </summary>
            /// <returns>System.String.</returns>
            public string GetScopeName()
            {
                return Name;
            }

            /// <summary>
            /// Gets the symbol.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <returns>Symbol.</returns>
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

            /// <summary>
            /// Gets the symbol global.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <returns>Symbol.</returns>
            public Symbol GetSymbolGlobal(string name)
            {
                return _enclosing.GetSymbol(name);
            }

            /// <summary>
            /// Resolves the specified name.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <returns>SymbolType.</returns>
            public SymbolType Resolve(string name)
            {
                Symbol symbol = GetSymbol(name);
                return symbol == null ? SymbolType.NONE : symbol.Type;
            }

            /// <summary>
            /// Variables the is in scope.
            /// </summary>
            /// <param name="id">The identifier.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            public bool VariableIsInScope(string id)
            {
                return Resolve(id) != Symbol.SymbolType.NONE;
            }

            /// <summary>
            /// Variables the is in scope nested.
            /// </summary>
            /// <param name="id">The identifier.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            public bool VariableIsInScopeNested(string id)
            {
                return VariableIsInScope(id);
            }

            /// <summary>
            /// Adds the child.
            /// </summary>
            /// <param name="child">The child.</param>
            /// <returns>IScope.</returns>
            public IScope AddChild(IScope child)
            {
                Child = child;
                return Child;
            }

            /// <summary>
            /// Gets the method.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <returns>IScope.</returns>
            public IScope GetMethod(string name)
            {
                return Child;
            }

            /// <summary>
            /// Sets the index of the next.
            /// </summary>
            /// <param name="index">The index.</param>
            public void SetNextIndex(int index)
            {
                Position = index;
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
        }
    }
}
