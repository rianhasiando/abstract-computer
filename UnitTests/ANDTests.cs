using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class ANDTests
    {
        public ANDTests()
        {
            Board.wires.Clear();
            Board.gates.Clear();
        }

        [TestMethod]
        public void AND_TruthTable()
        {
            int wIn1 = Board.CreateWire();
            int wIn2 = Board.CreateWire();
            int wOut = Board.CreateWire();
            _ = new AND(wIn1, wIn2, wOut);
            Assert.IsFalse(Board.wires[wOut].value);

            Board.ChangeWireValue(wIn1, true);
            Assert.IsFalse(Board.wires[wOut].value);

            Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, false);
            Assert.IsFalse(Board.wires[wOut].value);

            Board.ChangeWireValue(wIn2, true);
            Board.ChangeWireValue(wIn1, true);
            Assert.IsTrue(Board.wires[wOut].value);
        }
    }
}
