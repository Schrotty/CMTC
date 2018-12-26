// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="IScope.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using static CMTC.Core.SymTable.Symbol;

/// <summary>
/// The SymTable namespace.
/// </summary>
namespace CMTC.Core.SymTable
{
    /// <summary>
    /// Interface IScope
    /// </summary>
    public interface IScope
    {
        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetScopeName();

        /// <summary>
        /// Defines the specified symbol.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        void Define(Symbol symbol);

        /// <summary>
        /// Gets the enclosing scope.
        /// </summary>
        /// <returns>IScope.</returns>
        IScope GetEnclosingScope();

        /// <summary>
        /// Resolves the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>SymbolType.</returns>
        SymbolType Resolve(string name);

        /// <summary>
        /// Variables the is in scope.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool VariableIsInScope(string id);

        /// <summary>
        /// Variables the is in scope nested.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool VariableIsInScopeNested(string id);

        Symbol GetSymbol(int identifier);

        /// <summary>
        /// Gets the symbol.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Symbol.</returns>
        Symbol GetSymbol(string name);

        /// <summary>
        /// Gets the symbol global.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Symbol.</returns>
        Symbol GetSymbolGlobal(string name);

        /// <summary>
        /// Gets the symbol local.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Symbol.</returns>
        Symbol GetSymbolLocal(string name);

        /// <summary>
        /// Gets the method.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IScope.</returns>
        IScope GetMethod(string name);

        /// <summary>
        /// Gets the child.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>IScope.</returns>
        IScope GetChild(int index);

        /// <summary>
        /// Adds the child.
        /// </summary>
        /// <param name="child">The child.</param>
        /// <returns>IScope.</returns>
        IScope AddChild(IScope child);

        /// <summary>
        /// Increases the index.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int IncreasedIndex();

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int GetIndex();
    }
}
