namespace CMTC.Core.SymTable
{
    public partial class Symbol
    {
        public static readonly Symbol NONE = new None("NONE", SymbolType.NONE);

        public enum SymbolType
        {
            NONE,
            VOID,
            INT
        }

        public string Name { get; private set; }
        public SymbolType Type { get; private set; }
        public int Position { get; set; }
        public bool GlobalSymbol { get; set; }

        public Symbol(string name, int pos)
        {
            Name = name;
            Position = pos;
            GlobalSymbol = false;
        }

        public Symbol(string name, int pos, SymbolType type) : this(name, pos)
        {
            Type = type;
        }

        public override string ToString()
        {
            return Type != SymbolType.NONE ? string.Format("<{0}:{1}>", Name, Type) : Name;
        }
    }
}
