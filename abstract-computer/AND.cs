using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    class AND
    {
        public int in1;
        public int in2;
        public int _out;

        public AND(int i1, int i2, int o)
        {
            in1 = i1;
            in2 = i2;
            _out = o;
            int wireOutNand = Board.CreateWire();
            int gateNand = Board.CreateNAND(i1, i2, wireOutNand);
            NOT gateNot = new NOT(wireOutNand, o);
        }
    }
}
