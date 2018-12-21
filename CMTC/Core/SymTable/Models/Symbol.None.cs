// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Symbol.None.cs" company="CMTC">
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
    /// Class Symbol.
    /// </summary>
    public partial class Symbol
    {
        /// <summary>
        /// Class None.
        /// Implements the <see cref="CMTC.Core.SymTable.Symbol" />
        /// </summary>
        /// <seealso cref="CMTC.Core.SymTable.Symbol" />
        private class None : Symbol
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="None" /> class.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <param name="type">The type.</param>
            public None(string name, SymbolType type) : base(name, 0, type)
            {

            }
        }
    }
}
