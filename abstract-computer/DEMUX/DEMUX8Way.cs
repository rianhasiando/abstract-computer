namespace abstractcomputer
{
	public class DEMUX8Way
	{
		public int input;
		public int[] selector; // 3 wire selector (index 0 = LSB up to 2 = MSB)
		public int out1;
		public int out2;
		public int out3;
		public int out4;
		public int out5;
		public int out6;
		public int out7;
		public int out8;

		public DEMUX8Way(int i, int[] s, int o1, int o2, int o3, int o4, int o5, int o6, int o7, int o8)
		{
			input = i;
			selector = s;
			out1 = o1;
			out2 = o2;
			out3 = o3;
			out4 = o4;
			out5 = o5;
			out6 = o6;
			out7 = o7;
			out8 = o8;

			DEMUX d = new DEMUX(i, s[1], Board.CreateWire(), Board.CreateWire());

			_ = new DEMUX(d.out1, s[0], o1, o2);
			_ = new DEMUX(d.out2, s[0], o3, o4);
		}
	}
}
