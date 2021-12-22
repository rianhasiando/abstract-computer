namespace abstractcomputer
{
	// Latch can store 1 bit of data (keep the state of data - true or false - over time)
	// it has store flag, which if set to true, then the data will be updated
    public class Latch
    {
        public int data;
        public int store;
        public int _out;

        public Latch(int s, int d, int o)
        {
            data = d;
            store = s;
            _out = o;

            int nand1 = Board.CreateNAND(s, d, Board.CreateWire());
            int nand2 = Board.CreateNAND(
                s,
                new NOT(d, Board.CreateWire())._out,
                Board.CreateWire()
            );
            int nandRight = Board.CreateNAND(
                o,
                Board.gOutputWire[nand2],
                Board.CreateWire()
            );
            int nandLeft = Board.CreateNAND(
                Board.gOutputWire[nand1],
                Board.gOutputWire[nandRight],
                o
            );
        }
    }
}
