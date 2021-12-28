using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
using System.Diagnostics;
namespace UnitTests
{
    [TestClass]
    public class RAM64KTests
	{
        public RAM64KTests()
        {
            Board.Reset();
        }

        [TestMethod]
        public void RAM64K_TestRegister()
        {
            int[] wAddress = Helper.CreateWires(16);
			int wStore = Board.CreateWire();
			int[] wData = Helper.CreateWires(16);
			int wClock = Board.CreateWire();
			int[] wOut = Helper.CreateWires(16);

            _ = new RAM64K(wAddress, wStore, wData, wClock, wOut);
			Debug.WriteLine("Total {0} NAND gates, {1} wires", Board.currentIdxGates + 1, Board.currentIdxWires + 1);

			// wClock   wStore   wData    wAddress   wOut
			// false    false    0xF525   0x0315     0x0000
			Board.ChangeWireValue(wClock, false);
			Board.ChangeWireValue(wStore, false);
			Helper.ChangeWireValues(wData, 0xF525);
			Helper.ChangeWireValues(wAddress, 0x0315);
			Assert.AreEqual(0x0000, Helper.GetIntRepresentation(wOut));


			// false    true    0x4284   0xA049     0x0000
			Board.ChangeWireValue(wClock, false);
			Board.ChangeWireValue(wStore, true);
			Helper.ChangeWireValues(wData, 0x4284);
			Helper.ChangeWireValues(wAddress, 0xA049);
			Assert.AreEqual(0x0000, Helper.GetIntRepresentation(wOut));

			// true    false    0x4284   0xA049     0x0000
			Board.ChangeWireValue(wClock, true);
			Board.ChangeWireValue(wStore, false);
			Helper.ChangeWireValues(wData, 0x4284);
			Helper.ChangeWireValues(wAddress, 0xA049);
			Assert.AreEqual(0x4284, Helper.GetIntRepresentation(wOut));
		}
	}
}
