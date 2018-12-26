using System;
using System.Collections.Generic;
using System.Text;

namespace CMTC.Core.SymTable.Models
{
    class Expression
    {
        public dynamic Value { get; private set; }

        private Expression(dynamic value)
        {
            Value = value;
        }

        public static Expression Create(dynamic value)
        {
            return new Expression(value);
        }
    }
}
