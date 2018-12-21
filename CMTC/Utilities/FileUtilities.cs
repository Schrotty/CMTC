// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="FileUtilities.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;

/// <summary>
/// The Utilities namespace.
/// </summary>
namespace CMTC.Utilities
{
    /// <summary>
    /// Class FileUtilities.
    /// </summary>
    public static class FileUtilities
    {
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string ReadFile(string file)
        {
            if (File.Exists(file))
            {
                return File.ReadAllText(file);
            }

            throw new FileNotFoundException(TemplateManager.GetTemplate("FILE_NOT_FOUND").Render(), file);
        }

        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="content">The content.</param>
        public static void WriteFile(string file, string content)
        {
            File.CreateText(file).WriteLine(content);
        }
    }
}
