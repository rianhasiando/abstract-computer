using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
	[TestClass]
	public class NOT16BitTests
	{
		public NOT16BitTests()
		{
			Board.Reset();
		}

		[TestMethod]
		public void NOT16Bit_Test()
		{
			int[] wIn = new int[16];
			int[] wOut = new int[16];

			for (int i = 0; i < 16; i++)
			{
				wIn[i] = Board.CreateWire();
				wOut[i] = Board.CreateWire();
			}

			_ = new NOT16Bit(wIn, wOut);

			Helper.ChangeWireValues(wIn, 0);
			Assert.AreEqual(0xFFFF, Helper.GetIntRepresentation(wOut));

			Helper.ChangeWireValues(wIn, 111);
			Assert.AreEqual(0xFF90, Helper.GetIntRepresentation(wOut));

			Helper.ChangeWireValues(wIn, 0x5675);
			Assert.AreEqual(0xA98A, Helper.GetIntRepresentation(wOut));

			Helper.ChangeWireValues(wIn, 0xFFFF);
			Assert.AreEqual(0x0000, Helper.GetIntRepresentation(wOut));
		}
	}
}
