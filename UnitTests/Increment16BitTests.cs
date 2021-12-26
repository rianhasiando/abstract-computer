using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class Increment16BitTests
	{
        public Increment16BitTests()
        {
            Board.Reset();
        }

        [TestMethod]
        public void Increment16Bit_TestIncrement()
        {
            int[] wIn = new int[16];
            int[] wOut = new int[16];

			for (int i = 0; i < 16; i++)
			{
				wIn[i] = Board.CreateWire();
				wOut[i] = Board.CreateWire();
			}

            _ = new Increment16Bit(wIn, wOut);

			Helper.ChangeWireValues(wIn, 9283);
			Assert.AreEqual(9284, Helper.GetIntRepresentation(wOut));

			Helper.ChangeWireValues(wIn, 10000);
			Assert.AreEqual(10001, Helper.GetIntRepresentation(wOut));
		}
	}
}
