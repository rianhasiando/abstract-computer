using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace abstractcomputer
{
    class Latch
    {
        public int data;
        public int store;
        public int _out;

        public Latch(int s, int d, int o)
        {
            data = d;
            store = s;
            _out = o;

            int nand1 = Board.CreateNAND(s, d, Board.CreateWire());
            int nand2 = Board.CreateNAND(
                s,
                new NOT(d, Board.CreateWire())._out,
                Board.CreateWire()
            );
            int nandRight = Board.CreateNAND(
                o,
                Board.gates[nand2].output,
                Board.CreateWire()
            );
            int nandLeft = Board.CreateNAND(
                Board.gates[nand1].output,
                Board.gates[nandRight].output,
                o
            );
        }
    }
}
