// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="BaseScope.GlobalScope.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
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
    abstract partial class BaseScope
    {
        /// <summary>
        /// Class GlobalScope.
        /// Implements the <see cref="CMTC.Core.SymTable.BaseScope" />
        /// </summary>
        /// <seealso cref="CMTC.Core.SymTable.BaseScope" />
        public class GlobalScope : BaseScope
        {
            /// <summary>
            /// The variables
            /// </summary>
            public readonly List<Symbol> Variables = new List<Symbol>();

            /// <summary>
            /// The methods
            /// </summary>
            public readonly List<MethodSymbol> Methods = new List<MethodSymbol>();

            /// <summary>
            /// Initializes a new instance of the <see cref="GlobalScope" /> class.
            /// </summary>
            /// <param name="enclosing">The enclosing.</param>
            public GlobalScope(IScope enclosing) : base(enclosing)
            {
                _symbols.Add("int", new Symbol("int", 0, Symbol.SymbolType.INT));
                _symbols.Add("void", new Symbol("void", 0, Symbol.SymbolType.VOID));
            }

            /// <summary>
            /// Defines the method.
            /// </summary>
            /// <param name="method">The method.</param>
            public void DefineMethod(MethodSymbol method)
            {
                Define(method);
                Methods.Add(method);
            }

            /// <summary>
            /// Defines the variable.
            /// </summary>
            /// <param name="symbol">The symbol.</param>
            public void DefineVariable(Symbol symbol)
            {
                Define(symbol);
                Variables.Add(symbol);
            }

            /// <summary>
            /// Gets the name of the scope.
            /// </summary>
            /// <returns>System.String.</returns>
            public override string GetScopeName()
            {
                return "global";
            }
        }
    }
}
