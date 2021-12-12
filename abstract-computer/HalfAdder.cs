namespace abstractcomputer
{
    // HalfAdder only sums 2 inputs of 1 bit each
    // and store the result in sum and carry
    public class HalfAdder
    {
        public int in1;
        public int in2;
        public int sum;
        public int carry;

        public HalfAdder(int i1, int i2, int s, int c)
        {
            in1 = i1;
            in2 = i2;
            sum = s;
            carry = c;

            _ = new AND(in1, in2, c);
            _ = new XOR(in1, in2, s);
        }
    }
}
