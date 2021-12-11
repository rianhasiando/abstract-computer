using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
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
            AND c2 = new AND(
                new NOT(selector, Board.CreateWire())._out,
                data,
                out_0
            );
        }
    }
}
