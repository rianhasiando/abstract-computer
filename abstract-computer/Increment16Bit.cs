using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    class Increment16Bit
    {
        public int[] _in;
        public int[] _out;

        public Increment16Bit(int[] i, int[] o)
        {
            _in = i;
            _out = o;

            int[] i2 = new int[16];
            for (int ii = 0; ii<16; ii++)
            {
                i2[ii] = Board.CreateWire();
            }
            Board.wires[i2[0]].value = true;

            Adder16Bit a = new Adder16Bit(i, i2, o);
        }
    }
}
