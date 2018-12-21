// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="BaseScope.LocalScope.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
        /// Class LocalScope.
        /// Implements the <see cref="CMTC.Core.SymTable.BaseScope" />
        /// </summary>
        /// <seealso cref="CMTC.Core.SymTable.BaseScope" />
        public class LocalScope : BaseScope
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="LocalScope" /> class.
            /// </summary>
            /// <param name="enclosing">The enclosing.</param>
            public LocalScope(IScope enclosing) : base(enclosing)
            {
                _enclosing = enclosing;
            }

            /// <summary>
            /// Gets the name of the scope.
            /// </summary>
            /// <returns>System.String.</returns>
            public override string GetScopeName()
            {
                return "local";
            }
        }
    }
}
