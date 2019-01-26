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
using System.Collections.Generic;
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
            var files = new List<string>
            {
                "system",
                ApplicationSettings.Get("target")
            };

            foreach (string file in files)
            {
                using (var stream = assembly.GetManifestResourceStream(string.Format("{0}{1}.stg", Properties.Resources.TemplateNamespace, file)))
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
        public static Template SymbolDeclaration(Symbol symbol) => 
            GetTemplate("symbolDeclaration").Add("symbol", symbol);

        /// <summary>
        /// Functions the declaration.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>Template.</returns>
        public static Template FunctionDeclaration(MethodSymbol method) => 
            GetTemplate("function").Add("function", method);

        /// <summary>
        /// Assigns the statement.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        /// <returns>Template.</returns>
        public static Template AssignStatement(Symbol target, dynamic source) => 
            GetTemplate("assignStat").Add("target", target).Add("source", source);

        public static Template StoreStatement(Symbol target, string value) => 
            GetTemplate("storeStat").Add("target", target).Add("source", value);

        public static Template StoreStatement(Symbol target, Symbol source) => 
            GetTemplate("storeStat").Add("target", target).Add("source", source);

        public static Template CalcExpression(Symbol target, string op, dynamic op1, dynamic op2) =>
            GetTemplate("addSubExpr").Add("target", target).Add("op", op).Add("op1", op1).Add("op2", op2);

        public static Template CompareExpression(Symbol target, string op, dynamic op1, dynamic op2) => 
            GetTemplate("compareExpr").Add("target", target).Add("op", op).Add("op1", op1).Add("op2", op2);

        public static Template BoolCast(Symbol target, Symbol caster) =>
            GetTemplate("boolCast").Add("target", target).Add("caster", caster);

        public static Template Printf(Symbol target, dynamic integer) =>
            GetTemplate("printf").Add("target", target).Add("value", integer);

        public static Template Label(dynamic label) =>
            GetTemplate("label").Add("label", label);

        public static Template Branch(dynamic expr, dynamic first, dynamic second) =>
            GetTemplate("branch").Add("expr", expr).Add("first", first).Add("second", second);
        
        public static Template BranchToLabel(Symbol target) =>
            GetTemplate("branchToLabel").Add("target", target);

        public static Template Block(List<Template> stats) =>
            GetTemplate("block").Add("stats", stats);

        public static Template ReturnStatement(Symbol symbol) =>
            GetTemplate("returnStatement").Add("symbol", symbol);

        public static Template PlainReturnStatement(int integer) =>
            GetTemplate("plainReturnStatement").Add("integer", integer);

        public static Template Statement() =>
            GetTemplate("statement");

        public static Template Condition(bool ifElseCondition) =>
            ifElseCondition ? GetTemplate("conditionElse") : GetTemplate("conditionPlain");

        public static Template MethodCall(Symbol target, MethodSymbol method, List<KeyValuePair<dynamic, dynamic>> parameter) =>
            GetTemplate("methodCallExpr").Add("symbol", target).Add("method", method).Add("parameter", parameter);

        public static Template ForLoop() =>
            GetTemplate("forLoop");

        public static Template GetElementPtr(Symbol target, Symbol source, int index) =>
            GetTemplate("getElementPtr").Add("target", target).Add("source", source).Add("index", index + 1);
    }
}
