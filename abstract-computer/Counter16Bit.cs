namespace abstractcomputer
{
	// Counter increments data by 1, or sets the data
	// if clock and store is false, then Counter increments the data
	// if clock is false and store is one, then Counter sets the data to the input
	// if clock is true, then Counter sets out to data
    public class Counter16Bit
    {
        public int store;
        public int[] _in;
        public int[] _out;

        public Counter16Bit(int s, int[] i, int cl, int[] o)
        {
            store = s;
            _in = i;
            _out = o;

            int[] wOutInc = new int[16], 
                  wOutSelector = new int[16];

            for(int x=0;x<16;x++)
            {
                wOutInc[x] = Board.CreateWire();
                wOutSelector[x] = Board.CreateWire();
            }

            _ = new Register16Bit(
                new Selector16Bit(
                    i,
                    new Increment16Bit(o, wOutInc)._out,
                    s,
                    wOutSelector
                )._out,
                new NOT(cl, Board.CreateWire())._out,
                cl,
                o
            );
        }
    }
}
