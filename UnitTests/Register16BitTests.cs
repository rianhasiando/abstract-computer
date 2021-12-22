using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class Register16BitTests
	{
        public Register16BitTests()
        {
            Board.Reset();
        }

        [TestMethod]
        public void Register16Bit_TestRegister()
        {
            int[] wIn = new int[16];
            int[] wOut = new int[16];
			int wStore = Board.CreateWire();
			int wClock = Board.CreateWire();

			for (int i = 0; i < 16; i++)
			{
				wIn[i] = Board.CreateWire();
				wOut[i] = Board.CreateWire();
			}

            _ = new Register16Bit(wIn, wStore, wClock, wOut);

			// wClock store  wIn     wOut
			// false, false, 29531 = 0
			changeWireValues(wIn, 29531);
			Assert.AreEqual(0, getIntRepresentation(wOut));

			// false, true, 29531 = 0
			Board.ChangeWireValue(wStore, true);
			Assert.AreEqual(0, getIntRepresentation(wOut));

			// true, true, 8342 = 29531
			Board.ChangeWireValue(wClock, true);
			changeWireValues(wIn, 8342);
			Assert.AreEqual(29531, getIntRepresentation(wOut));

			Board.ChangeWireValue(wClock, false);
			// after clock set to false, 8342 will be stored
			Board.ChangeWireValue(wStore, false);
			Board.ChangeWireValue(wClock, true);
			// after clock set to true, 8342 will be outputted
			Assert.AreEqual(8342, getIntRepresentation(wOut));

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
