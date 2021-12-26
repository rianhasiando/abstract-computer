namespace abstractcomputer
{
	// 65536 registers, each register holds 16 bits
	// so the total size is 1Mibibytes
	// normally in real world, each register holds 8 bits (1 byte)
	class RAM64K
	{
		// because there are 65535 registers (2^16), so we need
		// 16 bit to specify the address
		// addr holds the list of 16 wire indexes
		public int[] addr;
		
		// index wire to specify whether to store data into
		// the addressed register or not
		public int store;

		// the data that would be stored
		// (ignored if store.value is false)
		public int[] data;
		
		// _out ouputs the CURRENT value of
		// the addressed register
		public int[] _out;

		
		public RAM64K(int[] a, int s, int[] d, int[] o)
		{
			addr = a;
			store = s;
			data = d;
			_out = o;

			// ex: address = 1010 0101 1010 0101
			// because every Selector16Bit selects 1 of 2 registers
			// then we need 65535 Selector16Bit, organized in hierarchycal way
			// (1 - 2 - 4 - 8 ... )

			for(int x=0; x<16; x++)
			{
			}
		}
	}
}
