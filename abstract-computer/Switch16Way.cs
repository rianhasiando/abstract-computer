namespace abstractcomputer
{
	// Switch16Way works like Switch, but the selector is 4 wire,
	// and there are 16 output
	public class Switch16Way
	{
		// the data wire
		public int data;

		// 4 wire selector
		public int[] selector;

		// 16 output wire. array is used for simplicity
		public int[] _out;

		public Switch16Way(int d, int[] s, int[]o)
		{
			data = d;
			selector = s;
			_out = o;

			Switch[] sw_level_1 = new Switch[8]
			{
				new Switch(Board.CreateWire(), s[0], o[1], o[0]),
				new Switch(Board.CreateWire(), s[0], o[3], o[2]),
				new Switch(Board.CreateWire(), s[0], o[5], o[4]),
				new Switch(Board.CreateWire(), s[0], o[7], o[6]),
				new Switch(Board.CreateWire(), s[0], o[9], o[8]),
				new Switch(Board.CreateWire(), s[0], o[11], o[10]),
				new Switch(Board.CreateWire(), s[0], o[13], o[12]),
				new Switch(Board.CreateWire(), s[0], o[15], o[14])
			};

			Switch[] sw_level_2 = new Switch[4]
			{
				new Switch(Board.CreateWire(), s[1], sw_level_1[1].data, sw_level_1[0].data),
				new Switch(Board.CreateWire(), s[1], sw_level_1[3].data, sw_level_1[2].data),
				new Switch(Board.CreateWire(), s[1], sw_level_1[5].data, sw_level_1[4].data),
				new Switch(Board.CreateWire(), s[1], sw_level_1[7].data, sw_level_1[6].data),
			};

			Switch[] sw_level_3 = new Switch[2]
			{
				new Switch(Board.CreateWire(), s[2], sw_level_2[1].data, sw_level_2[0].data),
				new Switch(Board.CreateWire(), s[2], sw_level_2[3].data, sw_level_2[2].data)
			};

			Switch sw_level_4 = new Switch(d, s[3], sw_level_3[1].data, sw_level_3[0].data);

		}
	}
}
