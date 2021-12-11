using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    class Selector
    {
        public int a;
        public int b;
        public int selector;
        public int _out;

        // s = 0 => i2
        // s = 1 => i1
        public Selector(int i1, int i2, int s, int o)
        {
            a = i1;
            b = i2;
            selector = s;
            _out = o;

            int x = Board.CreateNAND(
                Board.gates[
                    Board.CreateNAND(
                        new NOT(s, Board.CreateWire())._out,
                        b,
                        Board.CreateWire()
                    )
                ].output,
                Board.gates[
                    Board.CreateNAND(s, a, Board.CreateWire())
                ].output,
                _out
            );
        }
    }
}
