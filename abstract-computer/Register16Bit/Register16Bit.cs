namespace abstractcomputer
{
	// This is the main component to store data
	// Each register remember 16 bit of data
	public class Register16Bit
	{
		// false = do not store _in wire values
		// true = store
		public int load;

		// the 16 input wires containing the data
		public int[] _in;

		// the 16 output wire, reflecting the data value
		public int[] _out;

		public Register16Bit(int[] i, int l, int cl, int[] o)
		{
			load = l;
			_in = i;
			_out = o;

			for(int a=0;a<16;a++)
			{
				_ = new Bit(i[a], l, cl, o[a]);
			}
		}
	}
}
