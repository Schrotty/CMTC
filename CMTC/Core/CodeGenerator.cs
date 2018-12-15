using Antlr4.Runtime.Misc;
using Antlr4.StringTemplate;
using CMTC.Core.SymTable;
using CMTC.Utilities;
using System.Collections.Generic;
using static CMTC.Core.SymTable.Symbol;

namespace CMTC.Core
{
    class CodeGenerator : CymbolBaseVisitor<Template>
    {
        private bool _global = true;
        private string _localScopeName;
        private int _localScopeVarIndex;

        private readonly Stack<Template> _templates = new Stack<Template>();
        private readonly IScope global;

        public CodeGenerator(IScope global)
        {
            this.global = global;
        }

        public override Template VisitFile([NotNull] CymbolParser.FileContext context)
        {
            _templates.Push(TemplateManager.GetTemplate("file"));
            foreach (var c in context.varDecl())
            {
                _templates.Peek().Add("variableDecls", Visit(c));
            }

            _global = false;
            foreach (var c in context.functionDecl())
            {              
                _templates.Peek().Add("functionDecls", Visit(c));                
            }

            return _templates.Pop();
        }

        public override Template VisitVarDecl([NotNull] CymbolParser.VarDeclContext context)
        {
            return _global == false 
                ? TemplateManager.GetTemplate("varDecl")
                    .Add("id", global.GetMethod(_localScopeName).GetChild(0).GetSymbol(context.ID().GetText()).Position)
                    .Add("type", context.type().GetText()) 
                : TemplateManager.GetTemplate("globalVarDecl")
                    .Add("type", context.type().GetText())
                    .Add("id", context.ID().GetText());
        }

        public override Template VisitFunctionDecl([NotNull] CymbolParser.FunctionDeclContext context)
        {
            _localScopeName = context.ID().GetText();

            Template function = TemplateManager.GetTemplate("functionDecl");
            function.Add("returnType", context.type().GetText());
            function.Add("identifier", context.ID().GetText());
            function.Add("block", VisitBlock(context.block()));

            _templates.Push(function);
            if (context.formalParameters() != null)
            {
                _templates.Peek().Add("parameter", Visit(context.formalParameters()));
            }

            Visit(context.block());

            _localScopeVarIndex = 0;
            return _templates.Pop();
        }

        public override Template VisitFormalParameters([NotNull] CymbolParser.FormalParametersContext context)
        {
            _templates.Push(TemplateManager.GetTemplate("formalParameters"));

            List<string> parameter = new List<string>();
            foreach (var c in context.formalParameter())
            {
                _localScopeVarIndex++;
                parameter.Add(c.type().GetText());
            }

            _templates.Peek().Add("parameter", parameter);
            return _templates.Pop();
        }

        public override Template VisitBlock([NotNull] CymbolParser.BlockContext context)
        {
            _templates.Push(TemplateManager.GetTemplate("block"));
            if (context.stat() != null)
            {
                foreach (var c in context.stat())
                {
                    _templates.Peek().Add("statement", Visit(c));
                }
            }

            return _templates.Pop();
        }

        public override Template VisitStat([NotNull] CymbolParser.StatContext context)
        {
            _templates.Push(TemplateManager.GetTemplate("statement"));
            foreach (var c in context.children)
            {
                _templates.Peek().Add("statement", Visit(c));
            }

            return _templates.Pop();
        }

        public override Template VisitReturnStat([NotNull] CymbolParser.ReturnStatContext context)
        {
            var method = (MethodSymbol)global.GetMethod(_localScopeName);

            _templates.Push(TemplateManager.GetTemplate("returnStatement")
                .Add("type", method.Type.ToString().ToLower())
                .Add("expression", Visit(context.expr()))
                .Add("result", method.Position - 1));

            return _templates.Pop();
        }

        /* EXPRESSIONS */
        public override Template VisitMethodCallExpr([NotNull] CymbolParser.MethodCallExprContext context)
        {
            var method = (MethodSymbol) global.GetMethod(_localScopeName);

            _templates.Push(TemplateManager.GetTemplate("methodCallExpr")
                .Add("index", method.Position++)
                .Add("id", context.ID().GetText())
                .Add("type", method.Type.ToString().ToLower()));

            return _templates.Pop();
        }

        public override Template VisitAddSubExpr([NotNull] CymbolParser.AddSubExprContext context)
        {
            var method = (MethodSymbol)global.GetMethod(_localScopeName);

            _templates.Push(TemplateManager.GetTemplate("addSubExpr")
                .Add("expression", Visit(context.GetChild(0)))
                .Add("expression", Visit(context.GetChild(2))));

            _templates.Peek()
                .Add("index", method.Position++)
                .Add("type", "int")
                .Add("op", context.GetChild(1));

            return _templates.Pop();
        }

        public override Template VisitAssignStat([NotNull] CymbolParser.AssignStatContext context)
        {
            var method = (MethodSymbol)global.GetMethod(_localScopeName);

            _templates.Push(TemplateManager.GetTemplate("storeValue")
                .Add("type", "int")
                .Add("target", method.Position++)
                .Add("source", Visit(context.GetChild(2))));

            return _templates.Pop();
        }

        public override Template VisitInt([NotNull] CymbolParser.IntContext context)
        {
            return TemplateManager.GetTemplate("int").Add("value", context.GetText());
        }
    }
}
