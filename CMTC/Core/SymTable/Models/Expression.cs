using System;
using System.Collections.Generic;
using System.Text;

namespace CMTC.Core.SymTable.Models
{
    class Expression
    {
        public enum ExprType
        {
            UNDEFINED,
            SYMBOL
        }

        public dynamic Value { get; private set; }

        public ExprType Type { get; private set; }

        private Expression(dynamic value, ExprType type)
        {
            Value = value;
            Type = type;
        }

        private Expression(dynamic value)
        {
            Value = value;
            Type = ExprType.UNDEFINED;
        }

        public bool Is(ExprType type)
        {
            return Type.Equals(type);
        }

        public static Expression Create(dynamic value)
        {
            return new Expression(value);
        }

        public static Expression Create(dynamic value, ExprType type)
        {
            return new Expression(value, type);
        }
    }
}
