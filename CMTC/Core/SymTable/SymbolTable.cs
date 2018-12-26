// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="SymbolTable.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using static CMTC.Core.SymTable.BaseScope;

/// <summary>
/// The SymTable namespace.
/// </summary>
namespace CMTC.Core.SymTable
{
    /// <summary>
    /// Class SymbolTable.
    /// </summary>
    class SymbolTable
    {
        /// <summary>
        /// Gets the global.
        /// </summary>
        /// <value>The global.</value>
        public GlobalScope Global { get; private set; }

        /// <summary>
        /// Gets the scopes.
        /// </summary>
        /// <value>The scopes.</value>
        public Stack<IScope> Scopes { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolTable" /> class.
        /// </summary>
        public SymbolTable()
        {
            Scopes = new Stack<IScope>();
            Global = new GlobalScope(null);
        }
    }
}
