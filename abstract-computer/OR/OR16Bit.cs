namespace abstractcomputer
{
	public class OR16Bit
	{
		public int[] in1;
		public int[] in2;
		public int[] _out;

		public OR16Bit(int[] i1, int[] i2, int[] o)
		{
			in1 = i1;
			in2 = i2;
			_out = o;

			for (int a = 0; a < 16;a++)
			{
				_ = new OR(i1[a], i2[a], o[a]);
			}
		}
	}
}
