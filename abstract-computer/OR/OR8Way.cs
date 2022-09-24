namespace abstractcomputer
{
	// OR8Way is like OR, but has 8 input wire
	// OR8Way = in1 || in2 || ... || in8
	public class OR8Way
	{
		public int[] input;
		public int _out;

		public OR8Way(int[] i, int o)
		{
			input = i;
			_out = o;

			int o1 = new OR(i[0], i[1], Board.CreateWire())._out;
			int o2 = new OR(i[2], o1, Board.CreateWire())._out;
			int o3 = new OR(i[3], o2, Board.CreateWire())._out;
			int o4 = new OR(i[4], o3, Board.CreateWire())._out;
			int o5 = new OR(i[5], o4, Board.CreateWire())._out;
			int o6 = new OR(i[6], o5, Board.CreateWire())._out;
			_ = new OR(i[7], o6, o);
		}
	}
}
