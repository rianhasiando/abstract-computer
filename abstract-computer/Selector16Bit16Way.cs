namespace abstractcomputer
{
	// this is selector for 16 16bit wires
	public class Selector16Bit16Way
	{
		// input [index wire (0 to 15)][input data (0 to 15)]
		public int[][] _in;

		// 4 bit selector
		public int[] selector;

		// 16 bit output
		public int[] _out;

		// if s'value is false, then all i0's values will be selected
		// otherwise i1's values will be selected
		public Selector16Bit16Way(int[][] i, int[] s, int[] o)
		{
			_in = i;
			selector = s;
			_out = o;

			Selector16Bit select_level_1 = new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[3], o);
			Selector16Bit[] select_level_2 = new Selector16Bit[2]
			{
				new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[2], select_level_1.i_0),
				new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[2], select_level_1.i_1)
			};
			Selector16Bit[] select_level_3 = new Selector16Bit[4]
			{
				new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[1], select_level_2[0].i_0),
				new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[1], select_level_2[0].i_1),
				new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[1], select_level_2[1].i_0),
				new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[1], select_level_2[1].i_1)
			};
			Selector16Bit[] select_level_4 = new Selector16Bit[8]
			{
				new Selector16Bit(i[1], i[0], s[0], select_level_3[0].i_0),
				new Selector16Bit(i[3], i[2], s[0], select_level_3[0].i_1),
				new Selector16Bit(i[5], i[4], s[0], select_level_3[1].i_0),
				new Selector16Bit(i[7], i[6], s[0], select_level_3[1].i_1),
				new Selector16Bit(i[9], i[8], s[0], select_level_3[2].i_0),
				new Selector16Bit(i[11], i[10], s[0], select_level_3[2].i_1),
				new Selector16Bit(i[13], i[12], s[0], select_level_3[3].i_0),
				new Selector16Bit(i[15], i[14], s[0], select_level_3[3].i_1),
			};
		}
	}
}
