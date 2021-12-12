using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    // Switch / Demultiplexor determines if the data is outputted to 
    // out_1 or out_0
    // if selector is false, then data is outputted to out_0
    // otherwise to out_1
    class Switch
    {
        public int data;
        public int selector;
        public int out_1;
        public int out_0;

        public Switch(int d, int s, int o1, int o0)
        {
            data = d;
            selector = s;
            out_1 = o1;
            out_0 = o0;

            AND c1 = new AND(selector, data, out_1);
            AND c0 = new AND(
                new NOT(selector, Board.CreateWire())._out,
                data,
                out_0
            );
        }
    }
}
