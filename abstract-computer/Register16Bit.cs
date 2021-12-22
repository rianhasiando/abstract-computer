namespace abstractcomputer
{
    // This is the main component to store data
    // Each register remember 16 bit of data
    public class Register16Bit
    {
        // if store wire value is true, then 
        // all the value in _in wires will be stored
        public int store;

        // the 16 input wires containing the data
        public int[] _in;

        // the 16 output wire, reflecting the data value
        public int[] _out;

        public Register16Bit(int[] i, int s, int cl, int[] o)
        {
            store = s;
            _in = i;
            _out = o;

            for(int a=0;a<16;a++)
            {
                _ = new FlipFlop(s, i[a], cl, o[a]);
            }
        }
    }
}
