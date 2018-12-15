using System.Collections.Generic;
using static CMTC.Core.SymTable.BaseScope;

namespace CMTC.Core.SymTable
{
    class SymbolTable
    {
        public GlobalScope Global { get; private set; }
        public Stack<IScope> Scopes { get; private set; }
        public int Position { get; set; }

        public SymbolTable()
        {
            Scopes = new Stack<IScope>();
            Global = new GlobalScope(null);
            Position = 0;
        }
    }
}
