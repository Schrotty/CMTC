// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="Program.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CMTC.Core;
using CMTC.Utilities;

/// <summary>
/// The CMTC namespace.
/// </summary>
namespace CMTC
{
    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            ApplicationSettings.AppySettings(args);
            CMTCompiler.Execute(FileUtilities.ReadFile(args[args.Length - 1]));
        }
    }
}
