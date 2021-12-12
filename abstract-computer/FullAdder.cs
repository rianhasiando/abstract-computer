namespace abstractcomputer
{
    // FullAdder menambahkan 3 bit input, dan
    // salah satu inputnya adalah carry
    class FullAdder
    {
        public int in1;
        public int in2;
        public int in3;
        public int sum;
        public int carry;

        public FullAdder(int i1, int i2, int i3, int s, int c)
        {
            in1 = i1;
            in2 = i2;
            in3 = i3;
            sum = s;
            carry = c;

            XOR xorBC = new XOR(in2, in3, Board.CreateWire());
            XOR rSum = new XOR(in1, xorBC._out, s);

            OR rCarry = new OR(
                new AND(in2, in3, Board.CreateWire())._out,
                new AND(in1, xorBC._out, Board.CreateWire())._out,
                c
            );
        }
    }
}
