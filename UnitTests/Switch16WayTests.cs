using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
	[TestClass]
	public class Switch16WayTests
	{
		public Switch16WayTests()
		{
			Board.Reset();
		}

		[TestMethod]
		public void Switch16Way_TruthTable()
		{
			int[] wSelect = Helper.CreateWires(4);
			int wData = Board.CreateWire();
			int[] wOut = Helper.CreateWires(16);

			_ = new Switch16Way(wData, wSelect, wOut);
			
			// select (in hex)  data    Out (in hex)
			// 0x0            , false = 0x0
			Assert.AreEqual(0x0, Helper.GetIntRepresentation(wOut));

			Board.ChangeWireValue(wData, true);

			for (int i = 0; i < 16; i++)
			{
				Helper.ChangeWireValues(wSelect, i);
				Assert.AreEqual(Math.Pow(2, i), Helper.GetIntRepresentation(wOut));
			}
		}
	}
}
