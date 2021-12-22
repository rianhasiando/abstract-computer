using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class XORTests
    {
        public XORTests()
        {
            Board.Reset();
        }

        [TestMethod]
        public void XOR_TruthTable()
        {
            int wIn1 = Board.CreateWire();
            int wIn2 = Board.CreateWire();
            int wOut = Board.CreateWire();
            _ = new XOR(wIn1, wIn2, wOut);
            Assert.IsFalse(Board.wVal[wOut]);

            Board.ChangeWireValue(wIn1, true);
			Assert.IsTrue(Board.wVal[wOut]);

			Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, false);
			Assert.IsTrue(Board.wVal[wOut]);

			Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, true);
			Assert.IsFalse(Board.wVal[wOut]);
		}
    }
}
