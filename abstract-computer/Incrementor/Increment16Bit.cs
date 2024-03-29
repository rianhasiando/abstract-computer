﻿namespace abstractcomputer
{
	public class Increment16Bit
	{
		public int[] _in;
		public int[] _out;

		public Increment16Bit(int[] i, int[] o)
		{
			_in = i;
			_out = o;

			// list of intermediate wires
			int[] i2 = Board.CreateWires(16);

			// set the value to 0000 0000 0000 0001
			Board.wVal[i2[0]] = true;

			Adder16Bit a = new Adder16Bit(i, i2, o);
		}
	}
}
