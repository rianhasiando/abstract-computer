namespace abstractcomputer
{
	public class OR
	{
		public int in1;
		public int in2;
		public int _out;

		public OR(int i1, int i2, int o)
		{
			in1 = i1;
			in2 = i2;
			_out = o;

			_ = Board.CreateNAND(
				new NOT(i1, Board.CreateWire())._out,
				new NOT(i2, Board.CreateWire())._out, 
				o
			);
		}
	}
}
