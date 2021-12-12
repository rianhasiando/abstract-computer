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
            Board.wires.Clear();
            Board.gates.Clear();
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
            Assert.IsFalse(Board.wires[wSum].value);
            Assert.IsFalse(Board.wires[wCarry].value);

            // false + true = true, false
            Board.ChangeWireValue(wIn1, true);
            Assert.IsTrue(Board.wires[wSum].value);
            Assert.IsFalse(Board.wires[wCarry].value);

            // true + false = true, false
            Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, false);
            Assert.IsTrue(Board.wires[wSum].value);
            Assert.IsFalse(Board.wires[wCarry].value);

            // true + true = false, true
            Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, true);
            Assert.IsFalse(Board.wires[wSum].value);
            Assert.IsTrue(Board.wires[wCarry].value);
        }
    }
}
