using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;

namespace UnitTests
{
    [TestClass]
    public class BoardTests
    {
        public BoardTests()
        {
            Board.wires.Clear();
            Board.gates.Clear();
        }

        [TestMethod]
        public void Board_CreateNAND()
        {
            _ = Board.CreateNAND(Board.CreateWire(), Board.CreateWire(), Board.CreateWire());
            if (Board.wires.Count != 3)
                Assert.Fail("Wire count should equal to 3, got {0}", Board.wires.Count);
            if (Board.gates.Count != 1)
                Assert.Fail("Gate count should equal to 1, got {0}", Board.gates.Count);
        }

        [TestMethod]
        public void Board_UpdateWire()
        {
            int wIn1 = Board.CreateWire();
            int wIn2 = Board.CreateWire();
            _ = Board.CreateNAND(wIn1, wIn2, Board.CreateWire());

            Board.ChangeWireValue(wIn1, true);
            Assert.IsTrue(Board.wires[wIn1].value);
            Assert.IsFalse(Board.wires[wIn2].value);

            Board.ChangeWireValue(wIn1, false);
            Assert.IsFalse(Board.wires[wIn1].value);
            Assert.IsFalse(Board.wires[wIn2].value);

            Board.ChangeWireValue(wIn2, true);
            Assert.IsFalse(Board.wires[wIn1].value);
            Assert.IsTrue(Board.wires[wIn2].value);

            Board.ChangeWireValue(wIn2, false);
            Assert.IsFalse(Board.wires[wIn1].value);
            Assert.IsFalse(Board.wires[wIn2].value);
        }

        [TestMethod]
        public void Board_TestNANDTruth()
        {
            int wIn1 = Board.CreateWire();
            int wIn2 = Board.CreateWire();
            int wOut = Board.CreateWire();
            _ = Board.CreateNAND(wIn1, wIn2, wOut);

            // false NAND false = true
            Assert.IsTrue(Board.wires[wOut].value);

            // false NAND true  = true
            Board.ChangeWireValue(wIn1, true);
            Assert.IsTrue(Board.wires[wOut].value);

            // true NAND false  = true
            Board.ChangeWireValue(wIn1, false);
            Board.ChangeWireValue(wIn2, true);
            Assert.IsTrue(Board.wires[wOut].value);

            // true NAND true   = false
            Board.ChangeWireValue(wIn1, true);
            Assert.IsFalse(Board.wires[wOut].value);
        }

        [TestMethod]
        public void Board_OutputWireMultipleNANDs_ShouldUpdateAll()
        {
            int wIn1 = Board.CreateWire();
            int wIn2 = Board.CreateWire();
            int wIn3 = Board.CreateWire();
            int wOut1 = Board.CreateWire();
            int wOut2 = Board.CreateWire();
            _ = Board.CreateNAND(wIn1, wIn2, wOut1);
            _ = Board.CreateNAND(wOut1, wIn3, wOut2);

            // false NAND false = true
            Assert.IsTrue(Board.wires[wOut1].value);
            // true NAND false = true
            Assert.IsTrue(Board.wires[wOut2].value);

            Board.ChangeWireValue(wIn1, true);
            // true NAND false = true
            Assert.IsTrue(Board.wires[wOut1].value);
            Assert.IsTrue(Board.wires[wOut2].value);

            Board.ChangeWireValue(wIn2, true);
            Assert.IsFalse(Board.wires[wOut1].value);

            Board.ChangeWireValue(wIn1, false);
            Board.ChangeWireValue(wIn2, false);
            Board.ChangeWireValue(wIn3, true);
            Assert.IsTrue(Board.wires[wOut1].value);
            Assert.IsFalse(Board.wires[wOut2].value);
        }
    }
}
