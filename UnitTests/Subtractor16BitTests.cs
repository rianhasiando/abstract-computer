using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class Subtractor16BitTests
	{
        public Subtractor16BitTests()
        {
            Board.Reset();
        }

        [TestMethod]
        public void Subtractor16Bit_TestSubtract()
        {
            int[] wIn1 = new int[16];
            int[] wIn2 = new int[16];
            int[] wOut = new int[16];

			for (int i = 0; i < 16; i++)
			{
				wIn1[i] = Board.CreateWire();
				wIn2[i] = Board.CreateWire();
				wOut[i] = Board.CreateWire();
			}

            _ = new Subtractor16Bit(wIn1, wIn2, wOut);

			Helper.ChangeWireValues(wIn1, 0x1BF6);  // 7158
			Helper.ChangeWireValues(wIn2, 0x149); // 329
			Assert.AreEqual(0x1AAD, Helper.GetIntRepresentation(wOut)); // 6829

			Helper.ChangeWireValues(wIn1, 0x5C20);  // 23584
			Helper.ChangeWireValues(wIn2, 0x7D00); // 32000
			Assert.AreEqual(0xDF20, Helper.GetIntRepresentation(wOut)); // -8416

			Helper.ChangeWireValues(wIn1, 0x1A);  // 26
			Helper.ChangeWireValues(wIn2, 0x7FFF); // 32767
			Assert.AreEqual(0x801B, Helper.GetIntRepresentation(wOut)); // -32741

		}
	}
}
