using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_Drive
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width += 1;

            if(panel1.Width > 800)
            {
                timer1.Stop();
                Form8 fm8 = new Form8();
                fm8.Show();
                this.Hide();
            }
        }
    }
}
