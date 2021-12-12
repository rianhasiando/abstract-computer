using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace abstractcomputer
{
    class Counter
    {
        public int store;
        public int[] _in;
        public int[] _out;

        public Counter(int s, int[] i, int cl, int[] o)
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

            Register16Bit r = new Register16Bit(
                new Selector16Bit(
                    i,
                    new Increment16Bit(
                        o,
                        wOutInc
                    )._out,
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
