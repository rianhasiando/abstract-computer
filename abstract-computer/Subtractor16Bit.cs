using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    class Subtractor16Bit
    {
        public int[] a;
        public int[] b;
        public int[] result;

        public Subtractor16Bit(int[] i1, int[] i2, int[] r)
        {
            a = i1;
            b = i2;
            result = r;

            int[] wOutNotB = new int[16];
            int[] wOutFirstAdd = new int[16];
            for (int i = 0; i < 16; i++)
            {
                wOutNotB[i] = Board.CreateWire();
                wOutFirstAdd[i] = Board.CreateWire();
            }
            
            Increment16Bit n = new Increment16Bit(
                new Adder16Bit(
                    i1,
                    new NOT16Bit(i2, wOutNotB)._out,
                    wOutFirstAdd
                ).sum,
                r
            );
        }
    }
}
