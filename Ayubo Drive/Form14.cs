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
    public partial class Form14 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog=Ayubo;Integrated Security=True;";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Form14()
        {
            InitializeComponent();
        }

        private void SearchRecords()
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT UserName, Password FROM LoginTable WHERE Username =@Username ";
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtUserName.Text = dr["Username"].ToString();
                    txtUserPswrd.Text = dr["Password"].ToString();
                    
                }
                else
                {
                    MessageBox.Show("Login Details NOT Found!");
                    txtUserName.Clear();
                    txtUserPswrd.Clear();
                    
                   
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cnn.Close();
            }
        }

        private void AddRecords()
        {
            try
            {
                string sqlAdd;
                sqlAdd = "INSERT INTO LoginTable(Username, Password) VALUES('" + txtUserName.Text + "','" + txtUserPswrd.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlAdd, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted the USER Reocrd");
                txtUserName.Clear();
                txtUserPswrd.Clear();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cnn.Close();
            }
        }
        private void UpdateRecords()
        {
            try
            {
                string sqlUpdate;
                sqlUpdate = "UPDATE LoginTable SET Username = '" + txtUserName.Text + "',Password = '" + txtUserPswrd.Text + "'  WHERE Username = '" + txtUserName.Text + "', Password =  '" + txtUserPswrd.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlUpdate, cnn);
                MessageBox.Show("Record Updated!");
                txtUserName.Clear();
                txtUserPswrd.Clear();

                
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtUserName.Clear();
                txtUserPswrd.Clear();
            }
        }
        private void DeleteRecords()
        {
            try
            {
                DialogResult res = MessageBox.Show("Do you want to Delete this record?", "OK");
                if (res == DialogResult.OK)
                {
                    string sqlDelect;
                    sqlDelect = "DELETE FROM LoginTable WHERE Username = '" + txtUserName.Text + "'";
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sqlDelect, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted!!!");
                }
                txtUserName.Clear();
                txtUserPswrd.Clear();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtUserName.Clear();
                txtUserPswrd.Clear();
                cnn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchRecords();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddRecords();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtUserPswrd.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtUserPswrd.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateRecords();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form9().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRecords();
        }
    }
}
