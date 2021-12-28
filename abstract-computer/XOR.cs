namespace abstractcomputer
{
	public class XOR
	{
		public int in1;
		public int in2;
		public int _out;

		public XOR(int i1, int i2, int o)
		{
			in1 = i1;
			in2 = i2;
			_out = o;

			// use 4 NAND gates (most optimal)
			int wOutNandAB = Board.CreateWire();
			_ = Board.CreateNAND(i1, i2, wOutNandAB);

			int wOutNandAAB = Board.CreateWire();
			_ = Board.CreateNAND(i1, wOutNandAB, wOutNandAAB);

			int wOutNandABB = Board.CreateWire();
			_ = Board.CreateNAND(wOutNandAB, i2, wOutNandABB);

			_ = Board.CreateNAND(wOutNandAAB, wOutNandABB, o);
		}
	}
}
