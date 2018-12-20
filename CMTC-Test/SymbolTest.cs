using CMTC.Core.SymTable;
using CMTC.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMTC_Test
{
    [TestClass]
    public class SymbolTest
    {
        private readonly Symbol local = new Symbol("i", 0, Symbol.SymbolType.INT);
        private readonly Symbol global = new Symbol("i", 0, Symbol.SymbolType.INT)
        {
            GlobalSymbol = true
        };

        [TestMethod]
        public void LocalSymbol() => Assert.AreEqual("%0",
                TemplateManager.GetTemplate("symbol")
                    .Add("symbol", local).Render());

        [TestMethod]
        public void GlobalSymbol() => Assert.AreEqual("@i",
                TemplateManager.GetTemplate("symbol")
                    .Add("symbol", global).Render());

        [TestMethod]
        public void LocalSymbolDeclaration() => Assert.AreEqual("%0 = alloca i32",
                TemplateManager.GetTemplate("symbolDeclaration")
                    .Add("symbol", local).Render());

        [TestMethod]
        public void GlobalSymbolDeclaration() => Assert.AreEqual("@i = common global i32 0",
                TemplateManager.GetTemplate("symbolDeclaration")
                    .Add("symbol", global).Render());
    }
}