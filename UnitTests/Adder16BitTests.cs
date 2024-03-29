﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abstractcomputer;
namespace UnitTests
{
    [TestClass]
    public class Adder16BitTests
	{
        public Adder16BitTests()
        {
            Board.Reset();
        }

        [TestMethod]
        public void Adder16Bit_TestAdd()
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

            _ = new Adder16Bit(wIn1, wIn2, wOut);

			// 1 + 1 = 2
			Assert.IsTrue(add2Values(1, 1, wIn1, wIn2, wOut) == 2);

			// 100 + 10 = 110
			Assert.IsTrue(add2Values(100, 10, wIn1, wIn2, wOut) == 110);

			// 8341 + 238 = 8579
			Assert.IsTrue(add2Values(8341, 238, wIn1, wIn2, wOut) == 8579);

		}

		private int add2Values(int val1, int val2, int[] wIn1, int[] wIn2, int[] wOut)
		{
			bool[] representation1 = Helper.GetBoolRepresentation(val1);
			bool[] representation2 = Helper.GetBoolRepresentation(val2);
			for (int i = 0; i < 16; i++)
			{
				Board.ChangeWireValue(wIn1[i], representation1[i]);
				Board.ChangeWireValue(wIn2[i], representation2[i]);
			}

			int multiplier = 1;
			int result = 0;
			for (int i = 0; i < 16; i++)
			{
				if (Board.wVal[wOut[i]])
					result += multiplier;
				multiplier *= 2;
			}
			return result;
		}
    }
}
