namespace abstractcomputer
{
	// DEMUX is the inverse of MUX.
	// that is, DEMUX "distributes" input wire to 
	// one of many output wires based on select wire
	// select false will send input to output wire 1,
	// select true will send input to output wire 2
	public class DEMUX
	{
		public int input;
		public int selector;
		public int out1;
		public int out2;

		public DEMUX(int i, int s, int o1, int o2)
		{
			input = i;
			selector = s;
			out1 = o1;
			out2 = o2;

			_ = new AND(
				i,
				new NOT(s, Board.CreateWire())._out,
				o1
			);

			_ = new AND(i, s, o2);
		}
	}
}
