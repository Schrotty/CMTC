using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CMTC.Core.Extensions;
using CMTC.Core.SymTable;
using static CMTC.Core.SymTable.BaseScope;
using static CMTC.Core.SymTable.Symbol;

namespace CMTC.Core
{
    class SemanticAnalyser : CymbolBaseVisitor<IScope>
    {
        private SymbolTable _symbolTable = new SymbolTable();

        public override IScope VisitFile([NotNull] CymbolParser.FileContext context)
        {
            _symbolTable.Scopes.Push(_symbolTable.Global);

            foreach (var c in context.varDecl())
            {
                Visit(c);
            }

            foreach (var c in context.functionDecl())
            {
                Visit(c);
            }

            return _symbolTable.Scopes.Pop();
        }

        public override IScope VisitVarDecl([NotNull] CymbolParser.VarDeclContext context)
        {
            if (_symbolTable.Scopes.Peek().VariableIsInScope(context.ID().GetText()))
            {
                throw new System.Exception("Nope");
            }

            _symbolTable.Scopes.Peek().Define(new Symbol(context.ID().ToString(), 
                _symbolTable.Global.Resolve(context.type().Start.Text)));

            return _symbolTable.Scopes.Peek();
        }

        public override IScope VisitFunctionDecl([NotNull] CymbolParser.FunctionDeclContext context)
        {
            if (!_symbolTable.Global.VariableIsInScope(context.ID().GetText()))
            {
                MethodSymbol method = new MethodSymbol(context.ID().ToString(),
                    _symbolTable.Global.Resolve(context.type().Start.Text), _symbolTable.Global);

                if (context.HasValidReturnStatement(method, _symbolTable.Global))
                {
                    _symbolTable.Global.Define(method);
                    if (context.formalParameters() != null)
                    {
                        foreach (var c in context.formalParameters().formalParameter())
                        {
                            method.Define(new Symbol(c.ID().ToString(),
                                _symbolTable.Global.Resolve(c.type().Start.Text)));
                        }
                    }

                    _symbolTable.Scopes.Push(method);
                    Visit(context.block());

                    return _symbolTable.Scopes.Pop();
                }

                throw new System.Exception("");
            }

            throw new System.Exception("");
        }

        public override IScope VisitBlock([NotNull] CymbolParser.BlockContext context)
        {
            LocalScope local = new LocalScope(_symbolTable.Scopes.Peek());
            _symbolTable.Scopes.Push(local);

            if (context.stat() != null)
            {
                foreach (var c in context.stat())
                {
                    Visit(c);
                }
            }

            return _symbolTable.Scopes.Pop();
        }

        public override IScope VisitExpr([NotNull] CymbolParser.ExprContext context)
        {
            if (context.expr() != null)
            {
                foreach (var c in context.expr())
                {
                    Visit(c);
                }
            }

            return _symbolTable.Scopes.Peek();
        }

        public override IScope VisitTerminal(ITerminalNode node)
        {
            if (node.Symbol.Type == CymbolLexer.ID)
            {
                if (!_symbolTable.Scopes.Peek().VariableIsInScopeNested(node.GetText()))
                {
                    throw new System.Exception("");
                }
            }

            return _symbolTable.Scopes.Peek();
        }

        public override IScope VisitIfStat([NotNull] CymbolParser.IfStatContext context)
        {
            Visit(context.expr());
            foreach (var c in context.stat())
            {
                Visit(c);
            }

            return _symbolTable.Scopes.Peek();
        }

        public override IScope VisitForStat([NotNull] CymbolParser.ForStatContext context)
        {
            foreach (var c in context.assignStat())
            {
                Visit(c);
            }

            Visit(context.expr());
            Visit(context.block());

            return _symbolTable.Scopes.Peek();
        }

        public override IScope VisitReturnStat([NotNull] CymbolParser.ReturnStatContext context)
        {
            Visit(context.expr());

            return _symbolTable.Scopes.Peek();
        }

        public override IScope VisitPrintStat([NotNull] CymbolParser.PrintStatContext context)
        {
            Visit(context.expr());

            return _symbolTable.Scopes.Peek();
        }
    }
}
