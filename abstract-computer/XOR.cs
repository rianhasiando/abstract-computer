using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    class XOR
    {
        public int in1;
        public int in2;
        public int _out;

        public XOR(int i1, int i2, int o)
        {
            in1 = i1;
            in2 = i2;
            _out = o;

            // menggunakan 4 nand gate (paling optimal)
            int wOutNandAB = Board.CreateWire();
            int gateNandAB = Board.CreateNAND(i1, i2, wOutNandAB);

            int wOutNandAAB = Board.CreateWire();
            int gateNandAAB = Board.CreateNAND(i1, wOutNandAB, wOutNandAAB);

            int wOutNandABB = Board.CreateWire();
            int gateNandABB = Board.CreateNAND(wOutNandAB, i2, wOutNandABB);

            int gateNandFinal = Board.CreateNAND(wOutNandAAB, wOutNandABB, o);
        }
    }
}
