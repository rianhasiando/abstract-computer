using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
	[TestClass]
	public class SwitchTests
	{
		public SwitchTests()
		{
			Board.Reset();
		}

		[TestMethod]
		public void Switch_Test()
		{
			int wSelect = Board.CreateWire();
			int wData = Board.CreateWire();
			int wOut1 = Board.CreateWire();
			int wOut0 = Board.CreateWire();
			
			_ = new Switch(wData, wSelect, wOut1, wOut0);
			
			// select data    o1     o0
			// false, false = false, false
			Assert.IsFalse(Board.wVal[wOut1]);
			Assert.IsFalse(Board.wVal[wOut0]);

			// false, true = false, true
			Board.ChangeWireValue(wData, true);
			Assert.IsFalse(Board.wVal[wOut1]);
			Assert.IsTrue(Board.wVal[wOut0]);

			// true, false = false, false
			Board.ChangeWireValue(wSelect, true);
			Board.ChangeWireValue(wData, false);
			Assert.IsFalse(Board.wVal[wOut1]);
			Assert.IsFalse(Board.wVal[wOut0]);

			// true, true = true, false
			Board.ChangeWireValue(wSelect, true);
			Board.ChangeWireValue(wData, true);
			Assert.IsTrue(Board.wVal[wOut1]);
			Assert.IsFalse(Board.wVal[wOut0]);
		}
	}
}
