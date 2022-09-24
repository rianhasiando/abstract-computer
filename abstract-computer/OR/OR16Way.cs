namespace abstractcomputer
{
	// OR16Way is like OR, but has 16 input wire
	// OR16Way = in1 || in2 || ... || in16
	public class OR16Way
	{
		public int[] input;
		public int _out;

		public OR16Way(int[] i, int o)
		{
			input = i;
			_out = o;

			OR8Way or1 = new OR8Way(
				new int[]
				{
					i[0],i[1], i[2], i[3], i[4], i[5], i[6], i[7]
				},
				Board.CreateWire()
			);

			OR8Way or2 = new OR8Way(
				new int[]
				{
					i[8],i[9], i[10], i[11], i[12], i[13], i[14], i[15]
				},
				Board.CreateWire()
			);

			_ = new OR(or1._out, or2._out, o);
		}
	}
}
