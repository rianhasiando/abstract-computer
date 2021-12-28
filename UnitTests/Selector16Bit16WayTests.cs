using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
	[TestClass]
	public class Selector16Bit16WayTests
	{
		public Selector16Bit16WayTests()
		{
			Board.Reset();
		}

		[TestMethod]
		public void Selector16Bit16Way_TruthTable()
		{
			int[][] wInput = new int[16][];
			int[] wSelect = new int[4];
			int[] wOut = new int[16];

			wSelect = Helper.CreateWires(4);
			wOut = Helper.CreateWires(16);

			for (int i = 0; i < 16; i++)
			{
				wInput[i] = Helper.CreateWires(16);
				Helper.ChangeWireValues(wInput[i], 2*(i + 1));
			}

			_ = new Selector16Bit16Way(wInput, wSelect, wOut);

			for (int i = 0; i < 16; i++)
			{
				Helper.ChangeWireValues(wSelect, i);
				Assert.AreEqual(2*(i+1), Helper.GetIntRepresentation(wOut));
			}
		}
	}
}
