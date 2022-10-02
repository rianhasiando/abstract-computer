namespace abstractcomputer
{

	// DFF (Data Flip-Flop) is a
	// 1 bit memory that is set when data is true and clock is true
	public class DFF
	{
		public int data;
		public int _out;

		public DFF(int d, int c, int o)
		{
			data = d;
			_out = o;

			// this is basically SR Flip-Flop,
			// but the S and R is just wire D instead
			// S = D, R = NOT(D)

			// the NAND gate receiving "S"
			int nandS = Board.CreateNAND(d, c, Board.CreateWire());

			// the NAND gate receiving "R"
			int nandR = Board.CreateNAND(c, new NOT(d, Board.CreateWire())._out, Board.CreateWire());


			// the NAND gate that the output is Q
			int positiveNAND = Board.CreateNAND(
				Board.gOutputWire[nandS],
				Board.CreateWire(),
				o
			);

			int negativeNAND = Board.CreateNAND(
				o, 
				Board.gOutputWire[nandR],
				Board.gInputWire2[positiveNAND]
			);

		}
	}
}
