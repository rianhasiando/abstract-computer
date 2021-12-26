using abstractcomputer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
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

			Board.ChangeWireValue(wClock, true);
			Board.ChangeWireValue(wClock, false);
			Board.ChangeWireValue(wClock, true);
			Board.ChangeWireValue(wClock, false);

			Assert.AreEqual(2, Helper.GetIntRepresentation(wOut));
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
			bool[] bVal = Helper.GetBoolRepresentation(155);
			for (int i = 0; i < 16; i++)
			{
				Board.ChangeWireValue(wIn[i], bVal[i]);
			}
			Assert.AreEqual(0, Helper.GetIntRepresentation(wOut));
			Board.ChangeWireValue(wClock, true);
			Assert.AreEqual(155, Helper.GetIntRepresentation(wOut));
		}
	}
}
