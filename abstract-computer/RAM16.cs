namespace abstractcomputer
{
	// 16 registers, each register holds 16 bits
	// so the total size is 256 bits
	// normally in real world, each register holds 8 bits (1 byte)
	public class RAM16
	{
		// because there are 16 registers (2^4), so we need
		// 4 bit to specify the address
		// addr holds the list of 4 wire indexes
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

		public RAM16(int[] a, int s, int[] d, int cl, int[] o)
		{
			addr = a;
			store = s;
			data = d;
			_out = o;

			// ex: address = 1010
			// because every Selector16Bit selects 1 of 2 registers
			// then we need 15 Selector16Bit, organized in hierarchycal way
			// (1 - 2 - 4 - 8 ... )

			int[] inwire = Board.CreateWires(16);

			int[][] outwire = new int[16][];
			for (int i = 0; i < 16; i++)
			{
				outwire[i] = Board.CreateWires(16);
			}

			_ = new Register16Bit[16]
			{
				new Register16Bit( d, inwire[0], cl, outwire[0]),
				new Register16Bit( d, inwire[1], cl, outwire[1]),
				new Register16Bit( d, inwire[2], cl, outwire[2]),
				new Register16Bit( d, inwire[3], cl, outwire[3]),
				new Register16Bit( d, inwire[4], cl, outwire[4]),
				new Register16Bit( d, inwire[5], cl, outwire[5]),
				new Register16Bit( d, inwire[6], cl, outwire[6]),
				new Register16Bit( d, inwire[7], cl, outwire[7]),
				new Register16Bit( d, inwire[8], cl, outwire[8]),
				new Register16Bit( d, inwire[9], cl, outwire[9]),
				new Register16Bit( d, inwire[10], cl, outwire[10]),
				new Register16Bit( d, inwire[11], cl, outwire[11]),
				new Register16Bit( d, inwire[12], cl, outwire[12]),
				new Register16Bit( d, inwire[13], cl, outwire[13]),
				new Register16Bit( d, inwire[14], cl, outwire[14]),
				new Register16Bit( d, inwire[15], cl, outwire[15])
			};
			
			_ = new Switch16Way(s, a, inwire);
			
			_ = new Selector16Bit16Way(outwire, a, o);			
		}
	}
}
