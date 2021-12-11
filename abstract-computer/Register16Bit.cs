using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace abstractcomputer
{
    class Register16Bit
    {
        public int store;
        public int[] _in;
        public int[] _out;

        public Register16Bit(int[] i, int s, int cl, int[] o)
        {
            store = s;
            _in = i;
            _out = o;
            for(int a=0;a<16;a++)
            {
                FlipFlop f = new FlipFlop(s, i[a], cl, o[a]);
            }
        }
    }
}
