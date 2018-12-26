using static CymbolParser;

namespace CMTC.Core.Extensions
{
    static class StatContextExt
    {
        /// <summary>
        /// Determines whether the specified context is block.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if the specified context is block; otherwise, <c>false</c>.</returns>
        public static bool IsBlock(this StatContext context) => context.GetText().StartsWith("{") && context.GetText().EndsWith("}");
    }
}
