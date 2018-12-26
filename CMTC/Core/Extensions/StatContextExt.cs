using System;
using System.Collections.Generic;
using System.Text;
using static CymbolParser;

namespace CMTC.Core.Extensions
{
    static class StatContextExt
    {
        public static bool IsBlock(this StatContext context) => context.GetText().StartsWith("{") && context.GetText().EndsWith("}");
    }
}
