using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using abstractcomputer;
namespace UnitTests
{
	[TestClass]
	public class Counter16BitTests
	{
		public string[] wireNames = new string[500];

		public Counter16BitTests()
		{
			Board.Reset();
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

			Counter16Bit c = new Counter16Bit(wStore, wIn, wClock, wOut);

			Debug.WriteLine("{0} NAND gates, {1} wires", Board.currentIdxGates + 1, Board.currentIdxWires + 1);

			Debug.WriteLine("Origin:");
			 // 0

			Board.ChangeWireValue(wClock, true);
			 // 1

			Board.ChangeWireValue(wClock, false);
			 // 1

			Board.ChangeWireValue(wClock, true);
			 // 2

			Board.ChangeWireValue(wClock, false);
			 // 2

			Assert.AreEqual(2, getIntRepresentation(wOut));
			
		}

		[TestMethod]
		public void Counter16Bit_TestAssign()
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

			Board.ChangeWireValue(wStore, true);
			bool[] bVal = getBoolRepresentation(155);
			for (int i = 0; i< 16; i++)
			{
				Board.ChangeWireValue(wIn[i], bVal[i]);
			}
			Assert.AreEqual(0, getIntRepresentation(wOut));
			Board.ChangeWireValue(wClock, true);
			Assert.AreEqual(155, getIntRepresentation(wOut));
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

		// return 16 boolean representation of an int
		private bool[] getBoolRepresentation(int n)
		{
			bool[] result = new bool[16];
			int multiplier = 1;
			for (int i = 0; i < 16; i++)
			{
				result[i] = (multiplier & n) == multiplier;
				multiplier *= 2;
			}
			return result;
		}
	}
}
