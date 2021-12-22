namespace abstractcomputer
{
	// FlipFlop (Data flip-flop) stores and remembers one bit data

	// store     data     clock     out
	// false     Any      false     out (nothing changed)
	// true      Any      false     out (but data has changed)
	// Any       Any      true      new output (following the stored data)

    public class FlipFlop
    {
        public int data;
        public int store;
        public int _out;

        public FlipFlop(int s, int d, int cl, int o)
        {
            data = d;
            store = s;
            _out = o;

            Latch l = new Latch(
                cl,
                new Latch(
                    new AND(
                        s,
                        new NOT(cl, Board.CreateWire())._out,
                        Board.CreateWire()
                    )._out,
                    d,
                    Board.CreateWire()
                )._out, 
                o
            );
        }
    }
}
