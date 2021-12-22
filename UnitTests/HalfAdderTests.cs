using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class HalfAdderTests
    {
        public HalfAdderTests()
        {
            Board.Reset();
        }

        [TestMethod]
        public void HalfAdder_TruthTable()
        {
            int wIn1 = Board.CreateWire();
            int wIn2 = Board.CreateWire();
            int wSum = Board.CreateWire();
            int wCarry = Board.CreateWire();

            _ = new HalfAdder(wIn1, wIn2, wSum, wCarry);

            // win2    win1    wSum   wCarry
            // false + false = false, false
            Assert.IsFalse(Board.wVal[wSum]);
            Assert.IsFalse(Board.wVal[wCarry]);

            // false + true = true, false
            Board.ChangeWireValue(wIn1, true);
			Assert.IsTrue(Board.wVal[wSum]);
			Assert.IsFalse(Board.wVal[wCarry]);

			// true + false = true, false
			Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, false);
			Assert.IsTrue(Board.wVal[wSum]);
			Assert.IsFalse(Board.wVal[wCarry]);

			// true + true = false, true
			Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, true);
			Assert.IsFalse(Board.wVal[wSum]);
			Assert.IsTrue(Board.wVal[wCarry]);
		}
    }
}
