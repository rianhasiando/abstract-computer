namespace abstractcomputer
{
	// Subtractor16Bit subtracts two 16bit numbers (in two's complement)
	// => i1-i2
	public class Subtractor16Bit
    {
        public int[] a;
        public int[] b;
        public int[] result;

        public Subtractor16Bit(int[] i1, int[] i2, int[] r)
        {
            a = i1;
            b = i2;
            result = r;

            int[] wOutNotB = new int[16];
            int[] wOutFirstAdd = new int[16];
            for (int i = 0; i < 16; i++)
            {
                wOutNotB[i] = Board.CreateWire();
                wOutFirstAdd[i] = Board.CreateWire();
            }
            
            _ = new Increment16Bit(
                new Adder16Bit(
                    i1,
                    new NOT16Bit(i2, wOutNotB)._out,
                    wOutFirstAdd
                ).sum,
                r
            );
        }
    }
}
