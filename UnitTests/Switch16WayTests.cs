using System;
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
			int[] wSelect = new int[4];
			int wData = Board.CreateWire();
			int[] wOut = new int[16];
			for (int i = 0; i<4; i++)
			{
				wSelect[i] = Board.CreateWire();
			}
			for (int i = 0; i < 16; i++)
			{
				wOut[i] = Board.CreateWire();
			}

			_ = new Switch16Way(wData, wSelect, wOut);

			// select (in hex)  data    Out (in hex)
			// 0x0            , false = 0x0
			Assert.AreEqual(0x0, Helper.GetIntRepresentation(wOut));

			Board.ChangeWireValue(wData, true);
			
			// 0x0            , true = 0x0001
			Assert.AreEqual(0x0001, Helper.GetIntRepresentation(wOut));

			// 0x1            , true = 0x0002
			Helper.ChangeWireValues(wSelect, 0x1);
			Assert.AreEqual(0x0002, Helper.GetIntRepresentation(wOut));
		
		}
	}
}
