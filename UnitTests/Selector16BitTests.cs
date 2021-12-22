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
			changeWireValues(wIn1, 1283);
			changeWireValues(wIn0, 3048);
			Assert.AreEqual(3048, getIntRepresentation(wOut));

			// true, 1283, 3048 = 1283
			Board.ChangeWireValue(wSelect, true);
			Assert.AreEqual(1283, getIntRepresentation(wOut));
		}

		// return the integer representation of 16 wire
		private int getIntRepresentation(int[] w)
		{
			int result = 0;
			int multiplier = 1;
			for (int i = 0; i < 16; i++)
			{
				if (Board.wVal[w[i]]) result += multiplier;
				multiplier *= 2;
			}
			return result;
		}

		private void changeWireValues(int[] wires, int n)
		{
			bool[] bValues = getBoolRepresentation(n);
			for(int i = 0; i < 16; i++)
			{
				Board.ChangeWireValue(wires[i], bValues[i]);
			}
		}

		// return 16 boolean representation of an int
		private bool[] getBoolRepresentation(int n)
		{
			bool[] result = new bool[16];
			int multiplier = 1;
			for (int i = 0; i < 15; i++)
			{
				result[i] = (multiplier & n) == multiplier;
				multiplier *= 2;
			}
			return result;
		}
	}
}
