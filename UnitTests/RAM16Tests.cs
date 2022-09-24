using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
using System.Diagnostics;
namespace UnitTests
{
	[TestClass]
	public class RAM16Tests
	{
		public RAM16Tests()
		{
			Board.Reset();
		}

		[TestMethod]
		public void RAM16_Test()
		{
			int[] wAddress = Helper.CreateWires(4);
			int wStore = Board.CreateWire();
			int[] wData = Helper.CreateWires(16);
			int wClock = Board.CreateWire();
			int[] wOut = Helper.CreateWires(16);

			RAM16 r = new RAM16(wAddress, wStore, wData, wClock, wOut);

			Console.WriteLine("Total {0} NAND gates, {1} wires", Board.currentIdxGates + 1, Board.currentIdxWires + 1);

			int[] randomData = new int[16]
			{
				55150, 12573, 15328, 37793,
				22669, 3509, 40413, 37918,
				19563, 33345, 37855, 24707,
				3155, 31218, 36841, 9542
			};

			// because this is the first time, there is no data stored
			// wClock   wStore   wData    wAddress   wOut
			// false    false    X        X          0x0
			for (int i = 0; i < 16; i++)
			{
				Board.ChangeWireValue(wClock, false);
				Board.ChangeWireValue(wStore, false);
				Helper.ChangeWireValues(wAddress, i);
				Helper.ChangeWireValues(wData, randomData[i]);
				Assert.AreEqual(0x0, Helper.GetIntRepresentation(wOut));
			}

			// false    true     X        X          0x0
			for (int i = 0; i < 16; i++)
			{
				// wStore should be set to false first before changing wAddress to another one,
				// because if not, then data will also be set into previous address that wAddress is pointing to
				Board.ChangeWireValue(wClock, false);
				Board.ChangeWireValue(wStore, false);
				Helper.ChangeWireValues(wAddress, i);
				Board.ChangeWireValue(wStore, true);
				Helper.ChangeWireValues(wData, randomData[i]);
				Assert.AreEqual(0x0, Helper.GetIntRepresentation(wOut));
			}
			
			// true    false     X        X          current_wData
			for (int i = 0; i < 16; i++)
			{
				Board.ChangeWireValue(wClock, true);
				Board.ChangeWireValue(wStore, false);
				Helper.ChangeWireValues(wData, 0);
				Helper.ChangeWireValues(wAddress, i);
				Assert.AreEqual(randomData[i], Helper.GetIntRepresentation(wOut));
			}
		}
	}
}
