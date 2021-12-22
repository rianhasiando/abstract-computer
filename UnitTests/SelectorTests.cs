using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class SelectorTests
	{
		private int wSelect;
		private int wD1;
		private int wD0;
		private int wOut;

		public SelectorTests()
        {
            Board.Reset();
		}

        [TestMethod]
        public void Selector_TruthTable()
        {
			wSelect = Board.CreateWire();
			wD1 = Board.CreateWire();
			wD0 = Board.CreateWire();
			wOut = Board.CreateWire();

			_ = new Selector(wD1, wD0, wSelect, wOut);
			
			// select d1     d0      0
			// false, false, false = false
            Assert.IsFalse(Board.wVal[wOut]);

			// false, false, true  = true
			changeInputWireValue(false, false, true);
			Assert.IsTrue(Board.wVal[wOut]);

			// false, true, false  = false
			changeInputWireValue(false, true, false);
			Assert.IsFalse(Board.wVal[wOut]);

			// false, true, true  = true
			changeInputWireValue(false, true, true);
			Assert.IsTrue(Board.wVal[wOut]);

			// true, false, false  = false
			changeInputWireValue(true, false, false);
			Assert.IsFalse(Board.wVal[wOut]);

			// true, false, true  = false
			changeInputWireValue(true, false, true);
			Assert.IsFalse(Board.wVal[wOut]);

			// true, true, false  = true
			changeInputWireValue(true, true, false);
			Assert.IsTrue(Board.wVal[wOut]);

			// true, true, true  = true
			changeInputWireValue(true, true, true);
			Assert.IsTrue(Board.wVal[wOut]);
		}

		private void changeInputWireValue(bool vWireSelect, bool vWireD1, bool vWireD0)
		{
			Board.ChangeWireValue(wD1, vWireD1);
			Board.ChangeWireValue(wD0, vWireD0);
			Board.ChangeWireValue(wSelect, vWireSelect);
		}
    }
}
