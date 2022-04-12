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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Form10().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Form11().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Form12().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new Form13().Show();

        }
    }
}
