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
			Helper.ChangeWireValues(wIn, 29531);
			Assert.AreEqual(0, Helper.GetIntRepresentation(wOut));

			// false, true, 29531 = 0
			Board.ChangeWireValue(wStore, true);
			Assert.AreEqual(0, Helper.GetIntRepresentation(wOut));

			// true, true, 8342 = 29531
			Board.ChangeWireValue(wClock, true);
			Helper.ChangeWireValues(wIn, 8342);
			Assert.AreEqual(29531, Helper.GetIntRepresentation(wOut));

			Board.ChangeWireValue(wClock, false);
			// after clock set to false, 8342 will be stored
			Board.ChangeWireValue(wStore, false);
			Board.ChangeWireValue(wClock, true);
			// after clock set to true, 8342 will be outputted
			Assert.AreEqual(8342, Helper.GetIntRepresentation(wOut));

		}
	}
}
