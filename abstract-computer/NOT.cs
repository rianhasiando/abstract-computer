using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    public class NOT
    {
        public int _in;
        public int _out;

        public NOT(int i1, int o)
        {
            _in = i1;
            _out = o;
            int gate = Board.CreateNAND(i1, i1, o);
        }
    }
}
