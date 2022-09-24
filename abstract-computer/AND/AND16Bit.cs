namespace abstractcomputer
{
	public class AND16Bit
	{
		public int[] in1;
		public int[] in2;
		public int[] _out;

		public AND16Bit(int[] i1, int[] i2, int[] o)
		{
			in1 = i1;
			in2 = i2;
			_out = o;

			for (int j = 0; j < 16;j++)
			{
				_ = new AND(i1[j], i2[j], o[j]);
			}
		}
	}
}
