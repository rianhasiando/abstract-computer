using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;



namespace abstractcomputer
{
    public partial class Main : Form
    {
        public int wStore;
        public int wData;
        public int o;


        public Main()
        {
            InitializeComponent();

            wStore = Board.CreateWire();
            wData = Board.CreateWire();
            o = Board.CreateWire();

            Debug.WriteLine(String.Format(
                "Creating DLatch... wStore={0}, wData={1}, o={2}", wStore, wData, o
            ));

            Latch latch = new Latch(wStore, wData, o);
            
            printWires();

            Debug.WriteLine("Change wStore ({0}) to true", wStore);
            Board.ChangeWireValue(wStore, true);

            Debug.WriteLine("Change wData ({0}) to true", wData);
            Board.ChangeWireValue(wData, true);

            printWires();


            Debug.WriteLine("Change wStore ({0}) to false", wStore);
            Board.ChangeWireValue(wStore, false);

            Debug.WriteLine("Change wData ({0}) to true", wData);
            Board.ChangeWireValue(wData, true);
            printWires();

            Debug.WriteLine("Change wStore ({0}) to false", wStore);
            Board.ChangeWireValue(wStore, false);

            Debug.WriteLine("Change wData ({0}) to false", wData);
            Board.ChangeWireValue(wData, false);
            printWires();

            Debug.WriteLine("Change wStore ({0}) to true", wStore);
            Board.ChangeWireValue(wStore, true);

            Debug.WriteLine("Change wData ({0}) to false", wData);
            Board.ChangeWireValue(wData, false);
            printWires();
        }

        private void printWires()
        {
            label1.Text += String.Format("\nwStore: {0}, wData: {1}, out: {2}",
                (Board.wires[wStore].value) ? "TRUE" : "FALSE",
                (Board.wires[wData].value) ? "TRUE" : "FALSE",
                (Board.wires[o].value) ? "TRUE" : "FALSE");
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
