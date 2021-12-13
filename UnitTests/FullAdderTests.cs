using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class FullAdderTests
    {
        public FullAdderTests()
        {
            Board.wires.Clear();
            Board.gates.Clear();
        }

        [TestMethod]
        public void FullAdder_TruthTable()
        {
            int wIn1 = Board.CreateWire();
            int wIn2 = Board.CreateWire();
            int wCarryIn = Board.CreateWire();
            int wSum = Board.CreateWire();
            int wCarryOut = Board.CreateWire();

            _ = new FullAdder(wIn1, wIn2, wCarryIn, wSum, wCarryOut);

            // wIn2    wIn1    wCarryIn    wSum   wCarryOut
            // false + false + false     = false, false
            Assert.IsFalse(Board.wires[wSum].value);
            Assert.IsFalse(Board.wires[wCarryOut].value);

            // false + false + true = true, false
            Board.ChangeWireValue(wIn2, false);
            Board.ChangeWireValue(wIn1, false);
            Board.ChangeWireValue(wCarryIn, true);
            Assert.IsTrue(Board.wires[wSum].value);
            Assert.IsFalse(Board.wires[wCarryOut].value);

            // false + true + false = true, false
            Board.ChangeWireValue(wIn2, false);
            Board.ChangeWireValue(wIn1, true);
            Board.ChangeWireValue(wCarryIn, false);
            Assert.IsTrue(Board.wires[wSum].value);
            Assert.IsFalse(Board.wires[wCarryOut].value);

            // false + true + true = false, true
            Board.ChangeWireValue(wIn2, false);
            Board.ChangeWireValue(wIn1, true);
            Board.ChangeWireValue(wCarryIn, true);
            Assert.IsFalse(Board.wires[wSum].value);
            Assert.IsTrue(Board.wires[wCarryOut].value);

            // true + false + false = true, false
            Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, false);
            Board.ChangeWireValue(wCarryIn, false);
            Assert.IsTrue(Board.wires[wSum].value);
            Assert.IsFalse(Board.wires[wCarryOut].value);

            // true + false + true = false, true
            Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, false);
            Board.ChangeWireValue(wCarryIn, true);
            Assert.IsFalse(Board.wires[wSum].value);
            Assert.IsTrue(Board.wires[wCarryOut].value);

            // true + true + false = false, true
            Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, true);
            Board.ChangeWireValue(wCarryIn, false);
            Assert.IsFalse(Board.wires[wSum].value);
            Assert.IsTrue(Board.wires[wCarryOut].value);

            // true + true + true = true, true
            Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, true);
            Board.ChangeWireValue(wCarryIn, true);
            Assert.IsTrue(Board.wires[wSum].value);
            Assert.IsTrue(Board.wires[wCarryOut].value);
        }
    }
}
