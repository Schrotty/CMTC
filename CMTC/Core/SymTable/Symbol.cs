namespace CMTC.Core.SymTable
{
    public partial class Symbol
    {
        public static readonly Symbol NONE = new None("NONE", SymbolType.NONE);

        public enum SymbolType
        {
            NONE,
            VOID,
            INTEGER
        }

        internal string Name { get; private set; }
        internal SymbolType Type { get; private set; }

        public Symbol(string name)
        {
            Name = name;
        }

        public Symbol(string name, SymbolType type) : this(name)
        {
            Type = type;
        }

        public override string ToString()
        {
            return Type != SymbolType.NONE ? string.Format("<{0}:{1}>", Name, Type) : Name;
        }
    }
}
