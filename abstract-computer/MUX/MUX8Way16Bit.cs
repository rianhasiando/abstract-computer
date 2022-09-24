namespace abstractcomputer
{
	public class MUX8Way16Bit
	{
		public int[] in1;
		public int[] in2;
		public int[] in3;
		public int[] in4;
		public int[] in5;
		public int[] in6;
		public int[] in7;
		public int[] in8;
		public int[] selector; // selector is now 2 wire, to select 4 input
		public int[] _out;

		public MUX8Way16Bit(int[] i1, int[] i2, int[] i3, int[] i4, int[] i5, int[] i6, int[] i7, int[] i8, int[] s, int[] o)
		{
			in1 = i1;
			in2 = i2;
			in3 = i3;
			in4 = i4;
			in5 = i5;
			in6 = i6;
			in7 = i7;
			in8 = i8;
			selector = s;
			_out = o;

			int[] out12 = new MUX16Bit(i1, i2, s[0], Board.CreateWires(16))._out;
			int[] out34 = new MUX16Bit(i3, i4, s[0], Board.CreateWires(16))._out;
			int[] out56 = new MUX16Bit(i5, i6, s[0], Board.CreateWires(16))._out;
			int[] out78 = new MUX16Bit(i7, i8, s[0], Board.CreateWires(16))._out;

			int[] out1234 = new MUX16Bit(out12, out34, s[1], Board.CreateWires(16))._out;
			int[] out5678 = new MUX16Bit(out56, out78, s[1], Board.CreateWires(16))._out;

			_ = new MUX16Bit(out1234, out5678, s[2], o);
		}
	}
}
