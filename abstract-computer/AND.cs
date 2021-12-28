namespace abstractcomputer
{
	public class AND
	{
		public int in1;
		public int in2;
		public int _out;

		public AND(int i1, int i2, int o)
		{
			in1 = i1;
			in2 = i2;
			_out = o;
			int wireOutNand = Board.CreateWire();
			_ = Board.CreateNAND(i1, i2, wireOutNand);
			_ = new NOT(wireOutNand, o);
		}
	}
}
