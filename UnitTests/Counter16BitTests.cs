using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class Counter16BitTests
	{
        public Counter16BitTests()
        {
            Board.wires.Clear();
            Board.gates.Clear();
        }

        [TestMethod]
        public void Counter16Bit_TestIncrement()
        {
            int[] wIn = new int[16];
            int wStore = Board.CreateWire();
            int[] wOut = new int[16];
			int wClock = Board.CreateWire();

			for (int i = 0; i < 16; i++)
			{
				wIn[i] = Board.CreateWire();
				wOut[i] = Board.CreateWire();
			}

            _ = new Counter16Bit(wStore, wIn, wClock, wOut);

			Debug.WriteLine("{0} gates, {1} wires", Board.gates.Count, Board.wires.Count);

			for (int i = 0; i < 100000; i++)
			{
				Board.ChangeWireValue(wClock, true);
				Board.ChangeWireValue(wClock, false);
			}
			Assert.AreEqual(1, getIntRepresentation(wOut));
			

		}

		// return the integer representation of 16 wire
		private int getIntRepresentation(int[] w)
		{
			int result = 0;
			int multiplier = 1;
			for (int i = 0; i < 16; i++)
			{
				if (Board.wires[w[i]].value) result += multiplier;
				multiplier *= 2;
			}
			return result;
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
