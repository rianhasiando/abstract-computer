using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstractcomputer
{
    // Switch16Way works like Switch, but the selector is 4 wire,
    // and there are 16 output
    class Switch16Way
    {
        // the data wire
        public int data;

        // 4 wire selector
        public int[] selector;

        // 16 output wire. array is used for simplicity
        public int[] _out;

        public Switch16Way(int d, int[] s, int[]o)
        {
            data = d;
            selector = s;
            _out = o;

            // first, create two internal wires and switch to determine the routes based on
            // the first selector value,
            // then continue add switch as a branch until it stops at the output wire
            Switch sw_ah_ip = new Switch(d              , s[0], Board.CreateWire(), Board.CreateWire());

            Switch sw_ad_eh = new Switch(sw_ah_ip.out_0, s[1], Board.CreateWire(), Board.CreateWire());

            Switch sw_ab_cd = new Switch(sw_ad_eh.out_0, s[2], Board.CreateWire(), Board.CreateWire());
            Switch sw_a_b   = new Switch(sw_ab_cd.out_0, s[3], o[1], o[0]);
            Switch sw_c_d   = new Switch(sw_ab_cd.out_1, s[3], o[3], o[2]);

            Switch sw_ef_gh = new Switch(sw_ad_eh.out_1, s[2], Board.CreateWire(), Board.CreateWire());
            Switch sw_e_f   = new Switch(sw_ef_gh.out_0, s[3], o[5], o[4]);
            Switch sw_g_h   = new Switch(sw_ef_gh.out_1, s[3], o[7], o[6]);

            Switch sw_il_mp = new Switch(sw_ah_ip.out_1, s[1], Board.CreateWire(), Board.CreateWire());

            Switch sw_ij_kl = new Switch(sw_il_mp.out_0, s[2], Board.CreateWire(), Board.CreateWire());
            Switch sw_i_j   = new Switch(sw_ij_kl.out_0, s[3], o[9], o[8]);
            Switch sw_k_l   = new Switch(sw_ij_kl.out_1, s[3], o[11], o[10]);

            Switch sw_mn_op = new Switch(sw_il_mp.out_1, s[2], Board.CreateWire(), Board.CreateWire());
            Switch sw_m_n   = new Switch(sw_mn_op.out_0, s[3], o[13], o[12]);
            Switch sw_o_p   = new Switch(sw_mn_op.out_1, s[3], o[15], o[14]);
        }
    }
}
