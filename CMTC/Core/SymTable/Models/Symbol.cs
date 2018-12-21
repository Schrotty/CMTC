// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Symbol.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>
// / Enum SymbolType
// /</summary>
// Last Modified On : 12-20-2018
// ***********************************************************************
// /<summary>
// /The none
// /
// </summary>
// ***********************************************************************
/// The void
/// </summary>
//     Copyright (c) . All rights reserved.
/// <summary>
/// The int
/// </summary>
// </copyright>
// <summary>
// / Enum SymbolType
// /
// </summary>
// ***********************************************************************
/// <summary>
/// The SymTable namespace.
/// </summary>
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CMTC.Core.SymTable
{
    /// <summary>
    /// Class Symbol.
    /// </summary>
    /// <summary>
    /// The none
    /// </summary>
    public partial class Symbol
    {
        /// <summary>
        /// The none
        /// <summary>
        /// The void
        /// </summary>
        /// </summary>
        public static readonly Symbol NONE = new None("NONE", SymbolType.NONE);

        /// <summary>
        /// <summary>
        /// The int
        /// </summary>
        /// Enum SymbolType
        /// </summary>
        public enum SymbolType
        {
            /// <summary>
            /// The none
            /// </summary>
            /// <summary>
            /// The none
            /// </summary>
            /// <summary>
            /// The none
            /// </summary>
            NONE,
            /// <summary>
            /// The void
            /// </summary>
            /// <summary>
            /// The void
            /// </summary>
            /// <summary>
            /// The void
            /// </summary>
            VOID,
            /// <summary>
            /// The int
            /// </summary>
            /// <summary>
            /// The int
            /// </summary>
            /// <summary>
            /// The int
            /// </summary>
            INT
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public SymbolType Type { get; private set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public int Position { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [global symbol].
        /// </summary>
        /// <value><c>true</c> if [global symbol]; otherwise, <c>false</c>.</value>
        public bool GlobalSymbol { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Symbol" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pos">The position.</param>
        public Symbol(string name, int pos)
        {
            Name = name;
            Position = pos;
            GlobalSymbol = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Symbol" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pos">The position.</param>
        /// <param name="type">The type.</param>
        public Symbol(string name, int pos, SymbolType type) : this(name, pos)
        {
            Type = type;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Type != SymbolType.NONE ? string.Format("<{0}:{1}>", Name, Type) : Name;
        }
    }
}
