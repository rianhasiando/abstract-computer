using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class NOTTests
    {
        public NOTTests()
        {
            Board.Reset();
        }

        [TestMethod]
        public void NOT_InputFalse_OutputTrue()
        {
            int wIn = Board.CreateWire();
            int wOut = Board.CreateWire();
            NOT _ = new NOT(wIn, wOut);

            Assert.IsTrue(Board.wVal[wOut]);
        }
        [TestMethod]
        public void NOT_InputTrue_OutputFalse()
        {
            int wIn = Board.CreateWire();
            int wOut = Board.CreateWire();
            NOT _ = new NOT(wIn, wOut);

            Board.ChangeWireValue(wIn, true);
            Assert.IsFalse(Board.wVal[wOut]);
        }
    }
}
