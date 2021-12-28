namespace abstractcomputer
{
	// 65536 registers, each register holds 16 bits
	// so the total size is 1Mibibytes
	// normally in real world, each register holds 8 bits (1 byte)
	public class RAM64K
	{
		// because there are 65535 registers (2^16), so we need
		// 16 bit to specify the address
		// addr holds the list of 16 wire indexes
		public int[] addr;
		
		// index wire to specify whether to store data into
		// the addressed register or not
		public int store;

		// the 16 bit data that would be stored
		// (ignored if store.value is false)
		public int[] data;
		
		// _out ouputs the CURRENT 16bit data of
		// the addressed register
		public int[] _out;

		
		public RAM64K(int[] a, int s, int[] d, int cl, int[] o)
		{
			addr = a;
			store = s;
			data = d;
			_out = o;

			// ex: address = 1010 0101 1010 0101
			// because every Selector16Bit selects 1 of 2 registers
			// then we need 65535 Selector16Bit, organized in hierarchycal way
			// (1 - 2 - 4 - 8 ... )
			Register16Bit[] listRegister = new Register16Bit[0x10000];
			for (int i = 0x0; i < 0x10000; i++)
			{
				listRegister[i] = new Register16Bit( d, Board.CreateWire(), cl, Board.CreateWires(16));
			}


			// connect the address wire and store wire to the register
			// using switch16way, in hierarchycal
			Switch16Way[] sw_level_1 = new Switch16Way[0x1000];
			Switch16Way[] sw_level_2 = new Switch16Way[0x100];
			Switch16Way[] sw_level_3 = new Switch16Way[0x10];
			Switch16Way sw_level_4;

			int[] outwire = new int[16];
			for (int idx_switch = 0x0; idx_switch < 0x1000; idx_switch++)
			{
				outwire = new int[16];
				for (int j = 15; j >=0; j--)
				{
					outwire[15 - j] = listRegister[0x10 * idx_switch + j].store; 
				}
				sw_level_1[idx_switch] = new Switch16Way(
					s,
					new int[4]{ a[3], a[2], a[1], a[0] },
					outwire
				);
			}

			for (int idx_switch = 0x0; idx_switch < 0x100; idx_switch++)
			{
				outwire = new int[16];
				for (int j = 15; j >= 0; j--)
				{
					outwire[15 - j] = sw_level_1[0x10 * idx_switch + j].data;
				}
				sw_level_2[idx_switch] = new Switch16Way(
					s,
					new int[4] { a[7], a[6], a[5], a[4] },
					outwire
				);
			}

			for (int idx_switch = 0x0; idx_switch < 0x10; idx_switch++)
			{
				outwire = new int[16];
				for (int j = 15; j >= 0; j--)
				{
					outwire[15 - j] = sw_level_2[0x10 * idx_switch + j].data;
				}
				sw_level_3[idx_switch] = new Switch16Way(
					s,
					new int[4] { a[11], a[10], a[9], a[8] },
					outwire
				);
			}

			outwire = new int[16];
			for (int j = 15; j >= 0; j--)
			{
				outwire[15 - j] = sw_level_3[j].data;
			}
			sw_level_4 = new Switch16Way(
				s, 
				new int[4]
				{
					a[15], a[14], a[13], a[12]
				}, 
				outwire
			);

			// connect the address wire and register value to output
			// using Selector16Bit16Way
			Selector16Bit16Way sel_level_1;
			Selector16Bit16Way[] sel_level_2 = new Selector16Bit16Way[0x10];
			Selector16Bit16Way[] sel_level_3 = new Selector16Bit16Way[0x100];
			Selector16Bit16Way[] sel_level_4 = new Selector16Bit16Way[0x1000];

			sel_level_1 = new Selector16Bit16Way(
				Create16Wire16Bit(), 
				new int[4] {a[15], a[14], a[13], a[12]},
				o
			);

			for (int idx_sel_2 = 0x0; idx_sel_2 < 0x10; idx_sel_2++)
			{
				sel_level_2[idx_sel_2] = new Selector16Bit16Way(
					Create16Wire16Bit(),
					new int[4] { a[11], a[10], a[9], a[8] },
					sel_level_1._in[idx_sel_2]
				);
			}

			for (int idx_sel_3 = 0x0; idx_sel_3 < 0x10; idx_sel_3++)
			{
				for (int subindex_to_sel_2 = 0; subindex_to_sel_2 < 0x10; subindex_to_sel_2++)
				{
					sel_level_3[0x10*idx_sel_3+subindex_to_sel_2] = new Selector16Bit16Way(
						Create16Wire16Bit(),
						new int[4] { a[7], a[6], a[5], a[4] },
						sel_level_2[idx_sel_3]._in[subindex_to_sel_2]
					);
				}
				
			}

			int[][] inwire = new int[16][];
			for (int idx_sel_4 = 0x0; idx_sel_4 < 0x100; idx_sel_4++)
			{
				for (int subindex_to_sel_3 = 0x0; subindex_to_sel_3 < 0x10; subindex_to_sel_3++)
				{
					inwire = new int[16][];
					for (int subindex_to_listRegister = 0; subindex_to_listRegister < 0x10; subindex_to_listRegister++)
					{
						inwire[subindex_to_listRegister] = listRegister[0x10 * idx_sel_4 + (15-subindex_to_listRegister)]._out;
					}
					sel_level_4[0x10 * idx_sel_4 + subindex_to_sel_3] = new Selector16Bit16Way(
						inwire,
						new int[4] { a[3], a[2], a[1], a[0] },
						sel_level_3[idx_sel_4]._in[subindex_to_sel_3]
					);
				}
			}
			
		}

		private int[][] Create16Wire16Bit()
		{
			int[][] result = new int[16][];
			for (int i = 0; i < 16; i++)
			{
				result[i] = Board.CreateWires(16);
			}
			return result;
		}
	}
}
