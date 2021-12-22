using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class FlipFlopTests
	{
        public FlipFlopTests()
        {
			Board.Reset();
		}

        [TestMethod]
        public void FlipFlop_TruthTable()
        {
            int wStore = Board.CreateWire();
            int wData = Board.CreateWire();
			int wClock = Board.CreateWire();
            int wOut = Board.CreateWire();
            _ = new FlipFlop(wStore, wData, wClock, wOut);

            Assert.IsFalse(Board.wVal[wOut]);

            Board.ChangeWireValue(wStore, true);
			Assert.IsFalse(Board.wVal[wOut]);

			Board.ChangeWireValue(wData, true);
			Assert.IsFalse(Board.wVal[wOut]);

			Board.ChangeWireValue(wClock, true);
			Assert.IsTrue(Board.wVal[wOut]);

			Board.ChangeWireValue(wClock, false);
			Board.ChangeWireValue(wStore, false);
			Board.ChangeWireValue(wData, true);
			Assert.IsTrue(Board.wVal[wOut]);

		}
    }
}
