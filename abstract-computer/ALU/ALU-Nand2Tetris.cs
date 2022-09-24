namespace abstractcomputer
{
	public class ALUNand2Tetris
	{
		public int[] in_x;
		public int[] in_y;

		public int flag_zx; // zeroes the x input
		public int flag_nx; // negates the x input

		public int flag_zy; // zeroes the y input
		public int flag_ny; // negates the y input

		public int flag_f; // function flag; false = x AND y; true = x + y
		public int flag_no; // negates the output

		public int[] _out; // ALU output
		public int out_zr; // flag true if _out is all zero; otherwise false
		public int out_ng; // flag true if _out is negative; otherwise false

		public ALUNand2Tetris(int[] x, int[] y, int zx, int nx, int zy, int ny, int f, int no, int[] o, int zr, int ng)
		{
			in_x = x;
			in_y = y;
			
			flag_zx = zx;
			flag_nx = nx;

			flag_zy = zy;
			flag_ny = ny;

			flag_f = f;
			flag_no = no;

			_out = o;
			out_zr = zr;
			out_ng = ng;

			MUX16Bit zeroX = new MUX16Bit(x, Board.CreateWires(16), zx, Board.CreateWires(16));
			NOT16Bit invertX = new NOT16Bit(x, Board.CreateWires(16));
			MUX16Bit zeroInvertX = new MUX16Bit(zeroX._out, invertX._out, nx, Board.CreateWires(16));

			MUX16Bit zeroY = new MUX16Bit(y, Board.CreateWires(16), zy, Board.CreateWires(16));
			NOT16Bit invertY = new NOT16Bit(y, Board.CreateWires(16));
			MUX16Bit zeroInvertY = new MUX16Bit(zeroY._out, invertY._out, ny, Board.CreateWires(16));

			_ = new MUX16Bit(
				new AND16Bit(zeroInvertX._out, zeroInvertY._out, Board.CreateWires(16))._out,
				new Adder16Bit(zeroInvertX._out, zeroInvertY._out, Board.CreateWires(16)).sum,
				f,
				o
			);

			_ = new NOT(
				new OR16Way(o, Board.CreateWire())._out,
				zr
			);

			_ = new OR(
				o[15],
				Board.CreateWire(),
				ng
			);
		}
	}
}
