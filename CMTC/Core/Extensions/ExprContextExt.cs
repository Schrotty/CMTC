using System;
using System.Collections.Generic;
using System.Text;
using static CymbolParser;

namespace CMTC.Core.Extensions
{
    internal static class ExprContextExt
    {
        public static bool IsInteger(this ExprContext context)
        {
            if (context.ChildCount == 1)
            {
                return context.INT() != null;
            }

            return false;
        }

        public static bool IsIdentifier(this ExprContext context)
        {
            if (context.ChildCount == 1)
            {
                return context.ID() != null;
            }

            return false;
        }
    }
}
