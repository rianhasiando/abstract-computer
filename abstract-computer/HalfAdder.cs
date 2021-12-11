using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    // HalfAdder hanya menambahkan 2 bit, dan
    // outputnya ada sum dan carry
    class HalfAdder
    {
        public int in1;
        public int in2;
        public int sum;
        public int carry;

        public HalfAdder(int i1, int i2, int s, int c)
        {
            in1 = i1;
            in2 = i2;
            sum = s;
            carry = c;

            AND andCarry = new AND(in1, in2, c);
            XOR xorSum = new XOR(in1, in2, s);
        }
    }
}
