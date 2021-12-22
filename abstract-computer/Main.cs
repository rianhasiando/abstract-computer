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

        public Main()
        {
            InitializeComponent();
			Board.wVal[9999999] = true;

		}

		private void label1_Click(object sender, EventArgs e)
        {
		
        }

    }
}
