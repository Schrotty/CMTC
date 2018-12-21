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
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public int Position { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is global.
        /// </summary>
        /// <value><c>true</c> if this instance is global; otherwise, <c>false</c>.</value>
        public bool IsGlobal { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolTable" /> class.
        /// </summary>
        public SymbolTable()
        {
            Scopes = new Stack<IScope>();
            Global = new GlobalScope(null);
            Position = 0;
            IsGlobal = true;
        }
    }
}
