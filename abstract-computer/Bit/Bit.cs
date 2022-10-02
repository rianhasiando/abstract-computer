namespace abstractcomputer
{

	// Bit is the smallest component 
	// that can hold 1 bit data (true or false)

	// if load is true, and clock is true then
	// _in will be memorized but will still outputted the previous output
	public class Bit
	{
		public int _in; // 1 bit data in
		public int load; // select whether to load or 
		public int _out;

		public Bit(int i, int l, int c, int o)
		{
			_in = i;
			load = l;
			_out = o;

			MUX m = new MUX(o, i, l, Board.CreateWire());
			DFF d = new DFF(m._out, c, o);
		}
	}
}
