using static CymbolParser;

namespace CMTC.Core.Extensions
{
    internal static class ExprContextExt
    {
        #region valid-extensions

        public static bool IsValidMinus(this ExprContext context)
        {
            if (context.IsMinus())
            {
                return true;
            }

            return false;
        }

        public static bool IsValidNegation(this ExprContext context)
        {
            if (context.IsNegation())
            {
                return true;
            }

            return false;
        }

        #endregion

        #region is-extensions

        public static bool IsArrayAccess(this ExprContext context)
        {
            if (context.ChildCount == 4)
            {
                return context.GetChild(1).GetText().Equals("[") && context.GetChild(3).GetText().Equals("]");
            }

            return false;
        }

        public static bool IsMinus(this ExprContext context)
        {
            if (context.ChildCount == 2)
            {
                return context.GetChild(0).GetText().Equals("-");
            }

            return false;
        }

        public static bool IsNegation(this ExprContext context)
        {
            if (context.ChildCount == 2)
            {
                return context.GetChild(0).GetText().Equals("!");
            }

            return false;
        }

        public static bool IsBracketExpr(this ExprContext context)
        {
            if (context.ChildCount == 3)
            {
                return context.GetChild(0).GetText().Equals("(") && context.GetChild(2).GetText().Equals(")");
            }

            return false;
        }

        public static bool IsShortIf(this ExprContext context)
        {
            if (context.ChildCount == 5)
            {
                return context.GetChild(1).GetText().Equals("?") && context.GetChild(3).GetText().Equals(":");
            }

            return false;
        }

        public static bool IsMethodCall(this ExprContext context)
        {
            var childCount = context.ChildCount;
            if (childCount == 3 || childCount == 4)
            {
                int first = 1;
                int second = 0;

                if (childCount == 3)
                {
                    second = 2;
                }

                if (childCount == 4)
                {
                    second = 3;
                }

                return context.GetChild(first).GetText().Equals("(") && context.GetChild(second).GetText().Equals(")");
            }

            return false;
        }

        public static bool IsBooleanComparison(this ExprContext context)
        {
            if (context.ChildCount == 3)
            {
                var str = context.GetChild(1).GetText();
                return str.Equals("==") || str.Equals("!=") || str.Equals(">") || str.Equals("<");
            }

            return false;
        }

        public static bool IsCalc(this ExprContext context)
        {
            if (context.ChildCount == 3)
            {
                var str = context.GetChild(1).GetText();
                return str.Equals("+") || str.Equals("-") || str.Equals("*") || str.Equals("/");
            }

            return false;
        }

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

        #endregion
    }
}
