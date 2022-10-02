namespace abstractcomputer
{
	// A 16-bit counter with load and reset control bits.
	// if      (reset[t] == 1) out[t+1] = 0
	// else if (load[t] == 1)  out[t+1] = in[t]
	// else if (inc[t] == 1)   out[t+1] = out[t] + 1  (integer addition)
	// else                    out[t+1] = out[t]
	public class Counter16Bit
	{
		// 16 bit input
		public int[] _in;

		public int load;      // if true, then store value in _in
		public int increment; // if true, then increment the current value by 1
		public int reset;     // if true, sets the current value to 0

		// 16 bit output
		public int[] _out;

		public Counter16Bit(int[] i, int l, int inc, int r, int clock, int[] o)
		{
			_in = i;
			load = l;
			increment = inc;
			reset = r;
			_out = o;

			Increment16Bit inc16 = new Increment16Bit(o, Board.CreateWires(16));

			// The next 3 lines are a combinational logic layer to figure 
			// out what gets fed to the register. Either the program counter,
			// the incremented pc, the input, or zeros on a reset
			MUX16Bit mIncrement = new MUX16Bit(o, inc16._out, inc, Board.CreateWires(16));
			MUX16Bit mLoad = new MUX16Bit(mIncrement._out, i, l, Board.CreateWires(16));
			MUX16Bit mReset = new MUX16Bit(mLoad._out, Board.CreateWires(16), r, Board.CreateWires(16));

			int wAlwaysLoad = Board.CreateWire();
			Board.ChangeWireValue(wAlwaysLoad, true);

			_ = new Register16Bit(mReset._out, wAlwaysLoad, clock, o);
		}
	}
}
