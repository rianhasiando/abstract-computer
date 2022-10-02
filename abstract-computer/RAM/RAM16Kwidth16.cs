namespace abstractcomputer
{
	// RAM16Kwidth16 is RAM that contains 4 banks (4 RAM4Kwidth16 )
	public class RAM16Kwidth16
	{
		// 16 bit wide data
		public int[] _in;

		// load wire, indicating
		// whether to store _in or not
		public int load;

		// 14 bits address
		// from index 0 (LSB) ... 13(MSB)
		public int[] address;

		// 16 bit wide RAM output
		public int[] _out;

		public RAM16Kwidth16(int[] i, int l, int[] a,  int clock, int[] o)
		{
			_in = i;
			load = l;
			address = a;
			_out = o;

			// we use index 12..13 to select the correct RAM4Kwidth16
			// then we use index 0..11 to select the correct register
			// inside that RAM4Kwidth16

			int[] selectBank = new int[2] { a[12], a[13] };
			int[] selectRegister = new int[12] { a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11] };

			DEMUX4Way d = new DEMUX4Way(l, selectBank,
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire(),
				Board.CreateWire()
			);

			RAM4Kwidth16 ram1 = new RAM4Kwidth16(i, d.out1, selectRegister, clock, Board.CreateWires(16));
			RAM4Kwidth16 ram2 = new RAM4Kwidth16(i, d.out2, selectRegister, clock, Board.CreateWires(16));
			RAM4Kwidth16 ram3 = new RAM4Kwidth16(i, d.out3, selectRegister, clock, Board.CreateWires(16));
			RAM4Kwidth16 ram4 = new RAM4Kwidth16(i, d.out4, selectRegister, clock, Board.CreateWires(16));

			_ = new MUX4Way16Bit(
				ram1._out,
				ram2._out,
				ram3._out,
				ram4._out,
				selectBank,
				o
			);
		}
	}
}
