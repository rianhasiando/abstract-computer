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
			Board.Reset();
		}

        [TestMethod]
        public void Board_CreateNAND()
        {
            _ = Board.CreateNAND(Board.CreateWire(), Board.CreateWire(), Board.CreateWire());
            if (Board.currentIdxWires+1 != 3)
                Assert.Fail("Wire count should equal to 3, got {0}", Board.currentIdxWires + 1);
            if (Board.currentIdxGates+1 != 1)
                Assert.Fail("Gate count should equal to 1, got {0}", Board.currentIdxGates + 1);
        }

        [TestMethod]
        public void Board_UpdateWire()
        {
            int wIn1 = Board.CreateWire();
            int wIn2 = Board.CreateWire();
            _ = Board.CreateNAND(wIn1, wIn2, Board.CreateWire());

            Board.ChangeWireValue(wIn1, true);
            Assert.IsTrue(Board.wVal[wIn1]);
            Assert.IsFalse(Board.wVal[wIn2]);

            Board.ChangeWireValue(wIn1, false);
            Assert.IsFalse(Board.wVal[wIn1]);
            Assert.IsFalse(Board.wVal[wIn2]);

            Board.ChangeWireValue(wIn2, true);
            Assert.IsFalse(Board.wVal[wIn1]);
            Assert.IsTrue(Board.wVal[wIn2]);

            Board.ChangeWireValue(wIn2, false);
            Assert.IsFalse(Board.wVal[wIn1]);
            Assert.IsFalse(Board.wVal[wIn2]);
        }

        [TestMethod]
        public void Board_TestNANDTruth()
        {
            int wIn1 = Board.CreateWire();
            int wIn2 = Board.CreateWire();
            int wOut = Board.CreateWire();
            _ = Board.CreateNAND(wIn1, wIn2, wOut);

            // false NAND false = true
            Assert.IsTrue(Board.wVal[wOut]);

            // false NAND true  = true
            Board.ChangeWireValue(wIn1, true);
            Assert.IsTrue(Board.wVal[wOut]);

            // true NAND false  = true
            Board.ChangeWireValue(wIn1, false);
            Board.ChangeWireValue(wIn2, true);
			Assert.IsTrue(Board.wVal[wOut]);

			// true NAND true   = false
			Board.ChangeWireValue(wIn1, true);
			Assert.IsFalse(Board.wVal[wOut]);
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
            Assert.IsTrue(Board.wVal[wOut1]);
            // true NAND false = true
            Assert.IsTrue(Board.wVal[wOut2]);

            Board.ChangeWireValue(wIn1, true);
            // true NAND false = true
            Assert.IsTrue(Board.wVal[wOut1]);
            Assert.IsTrue(Board.wVal[wOut2]);

            Board.ChangeWireValue(wIn2, true);
            Assert.IsFalse(Board.wVal[wOut1]);

            Board.ChangeWireValue(wIn1, false);
            Board.ChangeWireValue(wIn2, false);
            Board.ChangeWireValue(wIn3, true);
            Assert.IsTrue(Board.wVal[wOut1]);
            Assert.IsFalse(Board.wVal[wOut2]);
        }
    }
}
