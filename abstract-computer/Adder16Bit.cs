﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    class Adder16Bit
    {
        public int[] a;
        public int[] b;
        public int[] sum;

        public Adder16Bit(int[] i1, int[] i2, int[] s)
        {
            a = i1;
            b = i2;
            sum = s;

            HalfAdder ha = new HalfAdder(a[0], b[0], s[0], Board.CreateWire());
            int carryBefore = ha.carry;
            for (int i = 1; i<16; i++)
            {
                carryBefore = new FullAdder(a[i], b[i], carryBefore, s[i], Board.CreateWire()).carry;
            }
        }
    }
}
