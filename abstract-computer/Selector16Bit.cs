namespace abstractcomputer
{
    // this is selector for two 16bit wires
    class Selector16Bit
    {
        public int[] i_1;
        public int[] i_0;
        public int selector;
        public int[] _out;

        // if s'value is false, then all i0's values will be selected
        // otherwise i1's values will be selected
        public Selector16Bit(int[] i1, int[] i0, int s, int[] o)
        {
            i_1 = i1;
            i_0 = i0;
            selector = s;
            _out = o;

            for(int x=0; x<16; x++)
            {
                Selector sel = new Selector(i1[x], i0[x], s, o[x]);
            }
        }
    }
}
