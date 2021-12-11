using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    class OR
    {
        public int in1;
        public int in2;
        public int _out;

        public OR(int i1, int i2, int o)
        {
            in1 = i1;
            in2 = i2;
            _out = o;
            NOT gateNot1 = new NOT(i1, Board.CreateWire());
            
            NOT gateNot2 = new NOT(i2, Board.CreateWire());

            int gateNand = Board.CreateNAND(gateNot1._out, gateNot2._out, o);
        }
    }
}
