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

			Selector16Bit select_level_1;
			Selector16Bit[] select_level_2 = new Selector16Bit[2];
			Selector16Bit[] select_level_3 = new Selector16Bit[4];
			Selector16Bit[] select_level_4 = new Selector16Bit[8];

			select_level_1 = new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[3], o);

			select_level_2[1] = new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[2], select_level_1.i_1);
			select_level_2[0] = new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[2], select_level_1.i_0);

			for (int j = 0; j < 2; j++)
			{
				select_level_3[2 * j + 1] = new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[1], select_level_2[j].i_1);
				select_level_3[2 * j] = new Selector16Bit(Board.CreateWires(16), Board.CreateWires(16), s[1], select_level_2[j].i_0);
			}

			int idx_odd, idx_even;
			for (int j = 0; j < 4; j++)
			{
				idx_odd = 2 * j + 1;
				idx_even = 2 * j;
				select_level_4[idx_odd] = new Selector16Bit(i[2 * idx_odd + 1], i[2 * idx_odd], s[0], select_level_3[j].i_1);
				select_level_4[idx_even] = new Selector16Bit(i[2 * idx_even + 1], i[2 * idx_even], s[0], select_level_3[j].i_0);
			}
		}
	}
}
