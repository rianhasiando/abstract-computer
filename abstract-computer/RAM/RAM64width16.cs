namespace abstractcomputer
{
	// RAM64width16 is RAM that contains 8 banks (8 RAM8width16)
	public class RAM64width16
	{
		// 16 bit wide data
		public int[] _in;

		// load wire, indicating
		// whether to store _in or not
		public int load;

		// 6 bits address
		// from index 0 (LSB) ... 5(MSB)
		public int[] address;

		// 16 bit wide RAM output
		public int[] _out;

		public RAM64width16(int[] i, int l, int[] a,  int clock, int[] o)
		{
			_in = i;
			load = l;
			address = a;
			_out = o;

			// we use index 3..5 to select the correct RAM8
			// then we use index 0..2 to select the correct register
			// inside that RAM8

			int[] selectBank = new int[3] { a[3], a[4], a[5] };
			int[] selectRegister = new int[3] { a[0], a[1], a[2] };

			DEMUX8Way d = new DEMUX8Way(l, selectBank,
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire()
			);

			RAM8width16 ram1 = new RAM8width16(i, d.out1, selectRegister, clock, Board.CreateWires(16));
			RAM8width16 ram2 = new RAM8width16(i, d.out2, selectRegister, clock, Board.CreateWires(16));
			RAM8width16 ram3 = new RAM8width16(i, d.out3, selectRegister, clock, Board.CreateWires(16));
			RAM8width16 ram4 = new RAM8width16(i, d.out4, selectRegister, clock, Board.CreateWires(16));
			RAM8width16 ram5 = new RAM8width16(i, d.out5, selectRegister, clock, Board.CreateWires(16));
			RAM8width16 ram6 = new RAM8width16(i, d.out6, selectRegister, clock, Board.CreateWires(16));
			RAM8width16 ram7 = new RAM8width16(i, d.out7, selectRegister, clock, Board.CreateWires(16));
			RAM8width16 ram8 = new RAM8width16(i, d.out8, selectRegister, clock, Board.CreateWires(16));


			_ = new MUX8Way16Bit(
				ram1._out,
				ram2._out,
				ram3._out,
				ram4._out,
				ram5._out,
				ram6._out,
				ram7._out,
				ram8._out,
				selectBank,
				o
			);
		}
	}
}
