// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ApplicationSettings.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

/// <summary>
/// The Utilities namespace.
/// </summary>
namespace CMTC.Utilities
{
    /// <summary>
    /// Class ApplicationSettings.
    /// </summary>
    public static class ApplicationSettings
    {
        /// <summary>
        /// The settings
        /// </summary>
        private static List<KeyValuePair<string, string>> _settings = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Appies the settings.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <exception cref="Exception"></exception>
        public static void AppySettings(string[] args)
        {
            if (args.Length >= 1)
            {
                foreach (var argument in args)
                {
                    if (argument.StartsWith("-o"))
                    {
                        Set("output", argument.Substring(2));
                    }
                }

                return;
            }

            throw new Exception(TemplateManager.GetTemplate("NO_PARAMS").Render());
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public static string Get(string key)
        {
            return _settings.Find(s => s.Key.Equals(key)).Value;
        }

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void Set(string key, string value)
        {
            _settings.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}
