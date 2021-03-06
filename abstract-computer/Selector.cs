namespace abstractcomputer
{
	// Selector/Multiplexor choose the output value based on the select value
	// Selector will choose i0's value if select is false
	// if the select is true, then i1 will be choosed
	public class Selector
	{
		public int i1;
		public int i0;
		public int selector;
		public int _out;
		
		public Selector(int i_1, int i_0, int s, int o)
		{
			i1 = i_1;
			i0 = i_0;
			selector = s;
			_out = o;

			_ = Board.CreateNAND(
				Board.gOutputWire[
					Board.CreateNAND(
						new NOT(s, Board.CreateWire())._out,
						i0,
						Board.CreateWire()
					)
				],
				Board.gOutputWire[
					Board.CreateNAND(
						s, 
						i1, 
						Board.CreateWire()
					)
				],
				_out
			);
		}
	}
}
