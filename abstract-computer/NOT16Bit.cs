﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    class NOT16Bit
    {
        public int[] _in;
        public int[] _out;

        public NOT16Bit(int[] i, int[] o)
        {
            _in = i;
            _out = o;
            for(int j=0; j<16; j++)
            {
                NOT n = new NOT(i[j], o[j]);
            }
        }
    }
}