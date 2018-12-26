// ***********************************************************************
// Assembly         : CMTC
// Author           : ruben
// Created          : 12-20-2018
//
// Last Modified By : ruben
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="TemplateManager.cs" company="CMTC">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Antlr4.StringTemplate;
using CMTC.Core.SymTable;
using System.IO;
using System.Reflection;
using static CMTC.Core.SymTable.Symbol;

/// <summary>
/// The Utilities namespace.
/// </summary>
namespace CMTC.Utilities
{
    /// <summary>
    /// Class TemplateManager.
    /// </summary>
    public class TemplateManager
    {
        /// <summary>
        /// The templates
        /// </summary>
        private TemplateGroup _templates;

        /// <summary>
        /// The instance
        /// </summary>
        private static TemplateManager _instance = new TemplateManager();

        /// <summary>
        /// Gets the template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <returns>Template.</returns>
        public static Template GetTemplate(string template) => _instance._templates.GetInstanceOf(template);

        /// <summary>
        /// Prevents a default instance of the <see cref="TemplateManager" /> class from being created.
        /// </summary>
        private TemplateManager()
        {
            var assembly = typeof(Core.CMTCompiler).GetTypeInfo().Assembly;

            string content = string.Empty;
            foreach (string file in Properties.Resources.Templates.Split(";"))
            {
                using (var stream = assembly.GetManifestResourceStream(string.Format("{0}{1}", Properties.Resources.TemplateNamespace, file)))
                {
                    if (stream == null) continue;
                    using (var reader = new StreamReader(stream))
                    {
                        content += reader.ReadToEnd();
                    }
                }
            }

            _templates = new TemplateGroupString(content);
        }

        /// <summary>
        /// Symbols the declaration.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>Template.</returns>
        public static Template SymbolDeclaration(Symbol symbol) => GetTemplate("symbolDeclaration").Add("symbol", symbol);

        /// <summary>
        /// Functions the declaration.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>Template.</returns>
        public static Template FunctionDeclaration(MethodSymbol method) => GetTemplate("function").Add("function", method);

        /// <summary>
        /// Assigns the statement.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        /// <returns>Template.</returns>
        public static Template AssignStatement(Symbol target, Symbol source) => GetTemplate("assignStat").Add("target", target).Add("source", source);

        public static Template StoreStatement(Symbol target, string value) => GetTemplate("storeStat").Add("target", target).Add("source", value);
    }
}
