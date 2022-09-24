namespace abstractcomputer
{
	// MUX16Bit (16 bit size input and output)
	// is a gate that is used to
	// "channel" input wire to output wire.
	// select false will output whatever input wire 1 is,
	// and select true will output whatever input wire 2 is
	public class MUX16Bit
	{
		public int[] in1;
		public int[] in2;
		public int selector; // one bit to select input
		public int[] _out;

		public MUX16Bit(int[] i1, int[] i2, int s, int[] o)
		{
			in1 = i1;
			in2 = i2;
			selector = s;
			_out = o;

			for (int a = 0; a<16;a++)
			{
				_ = new MUX(i1[a], i2[a], s, o[a]);
			}
		}
	}
}
