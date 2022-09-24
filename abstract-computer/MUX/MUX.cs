namespace abstractcomputer
{
	// MUX is a gate that is used to
	// "channel" input wire to output wire.
	// select false will output whatever input wire 1 is,
	// and select true will output whatever input wire 2 is
	public class MUX
	{
		public int in1;
		public int in2;
		public int selector; // one bit to select input
		public int _out;

		public MUX(int i1, int i2, int s, int o)
		{
			in1 = i1;
			in2 = i2;
			selector = s;
			_out = o;

			_ = new OR(
				new AND(i1, new NOT(s, Board.CreateWire())._out, Board.CreateWire())._out,
				new AND(i2, s, Board.CreateWire())._out,
				o
			);
		}
	}
}
