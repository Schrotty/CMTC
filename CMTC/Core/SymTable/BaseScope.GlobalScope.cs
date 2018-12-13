namespace CMTC.Core.SymTable
{
    abstract partial class BaseScope
    {
        public class GlobalScope : BaseScope
        {
            public GlobalScope(IScope enclosing) : base(enclosing)
            {
                _symbols.Add("int", new Symbol("int", Symbol.SymbolType.INTEGER));
                _symbols.Add("void", new Symbol("void", Symbol.SymbolType.VOID));
            }

            public override string GetScopeName()
            {
                return "global";
            }
        }
    }
}
