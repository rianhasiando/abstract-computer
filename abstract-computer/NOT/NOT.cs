namespace abstractcomputer
{
	public class NOT
	{
		public int _in;
		public int _out;

		public NOT(int i, int o)
		{
			_in = i;
			_out = o;
			_ = Board.CreateNAND(i, i, o);
		}
	}
}
