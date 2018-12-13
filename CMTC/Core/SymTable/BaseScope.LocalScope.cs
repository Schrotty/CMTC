namespace CMTC.Core.SymTable
{
    abstract partial class BaseScope
    {
        public class LocalScope : BaseScope
        {
            public LocalScope(IScope enclosing) : base(enclosing)
            {
            }

            public override string GetScopeName()
            {
                return "local";
            }
        }
    }
}
