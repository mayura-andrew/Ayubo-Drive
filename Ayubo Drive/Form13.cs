using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Ayubo_Drive
{
    public partial class Form13 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog=Ayubo;Integrated Security=True;";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Form13()
        {
            InitializeComponent();
        }
        private void login()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM LoginTable WHERE Username='" + txtUserName.Text + "' AND Password='" + txtPsswrd.Text + "'", cnn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {

                    this.Hide();
                    new Form14().Show();
                }
                else
                    MessageBox.Show("Invalid username or password");
                clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void clear()
        {
            txtPsswrd.Clear();
            txtUserName.Clear();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            new Form9().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
        }

        private void btnClear4_Click(object sender, EventArgs e)
        {
            txtPsswrd.Clear();
        }
    }
}
