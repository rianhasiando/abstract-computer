using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class Selector16BitTests
	{
        public Selector16BitTests()
        {
            Board.Reset();
        }

        [TestMethod]
        public void Selector16Bit_TestSelect()
        {
            int[] wIn1 = new int[16];
            int[] wIn0 = new int[16];
            int[] wOut = new int[16];
			int wSelect = Board.CreateWire();

			for (int i = 0; i < 16; i++)
			{
				wIn1[i] = Board.CreateWire();
				wIn0[i] = Board.CreateWire();
				wOut[i] = Board.CreateWire();
			}

            _ = new Selector16Bit(wIn1, wIn0, wSelect, wOut);

			// select w1    w0     wOut
			// false, 1283, 3048 = 3048
			Helper.ChangeWireValues(wIn1, 1283);
			Helper.ChangeWireValues(wIn0, 3048);
			Assert.AreEqual(3048, Helper.GetIntRepresentation(wOut));

			// true, 1283, 3048 = 1283
			Board.ChangeWireValue(wSelect, true);
			Assert.AreEqual(1283, Helper.GetIntRepresentation(wOut));
		}
	}
}
