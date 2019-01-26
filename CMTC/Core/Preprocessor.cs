using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Antlr4.StringTemplate;
using CMTC.Core.Extensions;
using CMTC.Core.SymTable;
using CMTC.Core.SymTable.Models;
using CMTC.Utilities;
using System.Collections.Generic;
using static CMTC.Core.SymTable.Models.Expression;
using static CMTC.Core.SymTable.Symbol;
using static CymbolParser;

namespace CMTC.Core
{
    internal class Preprocessor : CymbolBaseListener
    {
        public override void EnterFunctionDecl([NotNull] FunctionDeclContext context)
        {
            if (context.ID().GetText().Equals("main"))
            {
                var formalParams = context.formalParameters();
                if (formalParams != null)
                {
                    var paras = new List<KeyValuePair<int, string>>();
                    var index = 0;

                    // create new block
                    var block = new BlockContext(context, 0);
                    block.AddChild(new TerminalNodeImpl(new CommonToken(0, "{")));
                    foreach (var parameter in formalParams.formalParameter())
                    {
                        // statement for varDecl
                        var stat = new StatContext(block, 0);
                        var varDecl = new VarDeclContext(stat, 0);

                        var type = new TypeContext(varDecl, 0);
                        type.AddChild(new TerminalNodeImpl(new CommonToken(0, parameter.type().GetText())));

                        varDecl.AddChild(type);
                        varDecl.AddChild(new TerminalNodeImpl(new CommonToken(ID, parameter.ID().GetText())));
                        varDecl.AddChild(new TerminalNodeImpl(new CommonToken(0, ";")));
                        stat.AddChild(varDecl);
                        block.AddChild(stat);

                        paras.Add(new KeyValuePair<int, string>(index++, parameter.ID().GetText()));
                    }

                    paras.ForEach(pair =>
                    {
                        block.AddChild(CreateArrayGet(block, pair.Value, "argv", pair.Key));
                    });

                    // add existing stats to new block
                    foreach (var item in context.block().stat())
                    {
                        block.AddChild(item);
                    }

                    block.AddChild(new TerminalNodeImpl(new CommonToken(0, "}")));

                    // remove old block and add new one
                    context.children.RemoveAt(context.ChildCount - 1);
                    context.AddChild(block);

                    // delete formalParameters
                    context.formalParameters().children.Clear();

                    context.formalParameters().AddChild(CreateParameter(context, "argc", "int"));
                    context.formalParameters().AddChild(CreateParameter(context, "*argv[]", "char", true));
                }
            }
        }

        private FormalParameterContext CreateParameter(ParserRuleContext parent, string identifier, string type, bool last = false)
        {
            var parameter = new FormalParameterContext(parent, 0);
            var typ = new TypeContext(parameter, 0);
            typ.AddChild(new TerminalNodeImpl(new CommonToken(0, type)));

            var id = new TerminalNodeImpl(new CommonToken(ID, identifier));

            parameter.AddChild(typ);
            parameter.AddChild(id);

            if (!last)
            {
                parameter.AddChild(new TerminalNodeImpl(new CommonToken(0, ",")));
            }
            
            return parameter;
        }

        private StatContext CreateArrayGet(ParserRuleContext parent, string identifier, string array, int index)
        {
            var stat = new StatContext(parent, 0);
            var assign = new AssignStatContext(stat, 0);
            var semi = new TerminalNodeImpl(new CommonToken(0, ";"));
            assign.AddChild(new TerminalNodeImpl(new CommonToken(ID, identifier)));
            assign.AddChild(new TerminalNodeImpl(new CommonToken(0, "=")));

            var expr = new ExprContext(assign, 0);
            expr.AddChild(new TerminalNodeImpl(new CommonToken(ID, array)));
            expr.AddChild(new TerminalNodeImpl(new CommonToken(0, "[")));
            expr.AddChild(new TerminalNodeImpl(new CommonToken(INT, index.ToString())));
            expr.AddChild(new TerminalNodeImpl(new CommonToken(0, "]")));

            assign.AddChild(expr);
            assign.AddChild(semi);
            stat.AddChild(assign);

            return stat;
        }
    }
}
