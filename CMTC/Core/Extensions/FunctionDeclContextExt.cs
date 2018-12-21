// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="FunctionDeclContextExt.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CMTC.Core.SymTable;
using static CMTC.Core.SymTable.Symbol;
using static CymbolParser;

/// <summary>
/// The Extensions namespace.
/// </summary>
namespace CMTC.Core.Extensions
{
    /// <summary>
    /// Class FunctionDeclContextExt.
    /// </summary>
    static class FunctionDeclContextExt
    {
        /// <summary>
        /// Determines whether [has valid return statement] [the specified method].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="method">The method.</param>
        /// <param name="scope">The scope.</param>
        /// <returns><c>true</c> if [has valid return statement] [the specified method]; otherwise, <c>false</c>.</returns>
        public static bool HasValidReturnStatement(this FunctionDeclContext context, MethodSymbol method, IScope scope)
        {
            bool result = false;
            bool isVoid = false;

            var stats = context.block().stat();
            if (stats != null)
            {
                foreach (var item in stats)
                {
                    result = item.returnStat() != null;
                }
            }

            if (method.Type != scope.Resolve("void")) isVoid = true;

            return result ^ !isVoid;
        }
    }
}
