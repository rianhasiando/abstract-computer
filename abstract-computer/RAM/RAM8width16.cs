namespace abstractcomputer
{
	// RAM8width16 is RAM that contains 8 Registers16Bit
	public class RAM8width16
	{
		// 16 bit wide data
		public int[] _in;

		// load wire, indicating
		// whether to store _in or not
		public int load;

		// 3 bits address
		// from index 0 (LSB) ... 2(MSB)
		public int[] address;

		// 16 bit wide RAM output
		public int[] _out;

		public RAM8width16(int[] i, int l, int[] a,  int clock, int[] o)
		{
			_in = i;
			load = l;
			address = a;
			_out = o;

			DEMUX8Way d = new DEMUX8Way(l, a, 
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire()
			);

			Register16Bit r1 = new Register16Bit(i, d.out1, clock, Board.CreateWires(16));
			Register16Bit r2 = new Register16Bit(i, d.out2, clock, Board.CreateWires(16));
			Register16Bit r3 = new Register16Bit(i, d.out3, clock, Board.CreateWires(16));
			Register16Bit r4 = new Register16Bit(i, d.out4, clock, Board.CreateWires(16));
			Register16Bit r5 = new Register16Bit(i, d.out5, clock, Board.CreateWires(16));
			Register16Bit r6 = new Register16Bit(i, d.out6, clock, Board.CreateWires(16));
			Register16Bit r7 = new Register16Bit(i, d.out7, clock, Board.CreateWires(16));
			Register16Bit r8 = new Register16Bit(i, d.out8, clock, Board.CreateWires(16));

			_ = new MUX8Way16Bit(
				r1._out,
				r2._out,
				r3._out,
				r4._out,
				r5._out,
				r6._out,
				r7._out,
				r8._out,
				address,
				o
			);
		}
	}
}
