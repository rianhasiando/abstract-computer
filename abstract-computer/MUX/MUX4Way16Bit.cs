namespace abstractcomputer
{
	public class MUX4Way16Bit
	{
		public int[] in1;
		public int[] in2;
		public int[] in3;
		public int[] in4;
		public int[] selector; // selector is now 2 wire, to select 4 input
		public int[] _out;

		public MUX4Way16Bit(int[] i1, int[] i2, int[] i3, int[] i4, int[] s, int[] o)
		{
			in1 = i1;
			in2 = i2;
			in3 = i3;
			in4 = i4;
			selector = s;
			_out = o;

			int[] out12 = new MUX16Bit(i1, i2, s[0], Board.CreateWires(16))._out;
			int[] out34 = new MUX16Bit(i3, i4, s[0], Board.CreateWires(16))._out;

			_ = new MUX16Bit(out12, out34, s[1], o);
		}
	}
}
