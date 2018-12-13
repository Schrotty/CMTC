namespace CMTC.Core.SymTable
{
    public partial class Symbol
    {
        private class None : Symbol
        {
            public None(string name, SymbolType type) : base(name, type)
            {

            }
        }
    }
}
