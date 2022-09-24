namespace abstractcomputer
{
	public class DEMUX4Way
	{
		public int input;
		public int[] selector; // 2 wire selector
		public int out1;
		public int out2;
		public int out3;
		public int out4;

		public DEMUX4Way(int i, int[] s, int o1, int o2, int o3, int o4)
		{
			input = i;
			selector = s;
			out1 = o1;
			out2 = o2;
			out3 = o3;
			out4 = o4;

			DEMUX d = new DEMUX(i, s[1], Board.CreateWire(), Board.CreateWire());

			_ = new DEMUX(d.out1, s[0], o1, o2);
			_ = new DEMUX(d.out2, s[0], o3, o4);
		}
	}
}
