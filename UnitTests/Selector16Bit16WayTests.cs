using System;
using System.Diagnostics;
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

			int[] randomData = new int[16]
			{
				11211, 26412, 47913, 54240,
				43408, 63288, 47264, 23676,
				56252, 42567, 61301, 48752,
				37276, 15943, 33643, 35664
			};

			for (int i = 0; i < 16; i++)
			{
				wInput[i] = Helper.CreateWires(16);
			}

			_ = new Selector16Bit16Way(wInput, wSelect, wOut);

			for (int i = 0; i < 16; i++)
			{
				Helper.ChangeWireValues(wInput[i], randomData[i]);
			}

			for (int i = 0; i < 16; i++)
			{
				Helper.ChangeWireValues(wSelect, i);
				Assert.AreEqual(randomData[i], Helper.GetIntRepresentation(wOut));
			}
		}
	}
}
