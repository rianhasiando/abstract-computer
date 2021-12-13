using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class LatchTests
	{
        public LatchTests()
        {
            Board.wires.Clear();
            Board.gates.Clear();
        }

        [TestMethod]
        public void Latch_TruthTable()
        {
            int wStore = Board.CreateWire();
            int wData = Board.CreateWire();
            int wOut = Board.CreateWire();
            _ = new Latch(wStore, wData, wOut);

			// first time is false, because the wStore and wData is false
            Assert.IsFalse(Board.wires[wOut].value);

            Board.ChangeWireValue(wStore, true);
			// still false, because wData is false
            Assert.IsFalse(Board.wires[wOut].value);

			// true, because wStore is true and wData is true
            Board.ChangeWireValue(wData, true);
            Assert.IsTrue(Board.wires[wOut].value);

			// Nothing changed
            Board.ChangeWireValue(wStore, false);
            Assert.IsTrue(Board.wires[wOut].value);
        }
    }
}
