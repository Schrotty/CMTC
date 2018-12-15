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

        internal string Name { get; private set; }
        internal SymbolType Type { get; private set; }
        internal int Position { get; set; }

        public Symbol(string name, int pos)
        {
            Name = name;
            Position = pos;
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
