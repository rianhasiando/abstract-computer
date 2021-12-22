using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class Increment16BitTests
	{
        public Increment16BitTests()
        {
            Board.Reset();
        }

        [TestMethod]
        public void Increment16Bit_TestIncrement()
        {
            int[] wIn = new int[16];
            int[] wOut = new int[16];

			for (int i = 0; i < 16; i++)
			{
				wIn[i] = Board.CreateWire();
				wOut[i] = Board.CreateWire();
			}

            _ = new Increment16Bit(wIn, wOut);

			changeWireValues(wIn, 9283);
			Assert.AreEqual(9284, getIntRepresentation(wOut));

			changeWireValues(wIn, 10000);
			Assert.AreEqual(10001, getIntRepresentation(wOut));
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
			for (int i = 0; i < 16; i++)
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
