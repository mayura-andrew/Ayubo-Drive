using System.Data.SqlClient;
using System.Data;

namespace Ayubo_Drive
{
    public partial class Form1 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog = Ayubo; Integrated Security = True;";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Form1()
        {
            InitializeComponent();
        }

        private void Search_Record()
        {
            try
            {
                
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT Type,MinSpace,MaxSpace FROM TypeTable WHERE Type =@Type";
                cmd.Parameters.AddWithValue("@Type", txtType.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtMin.Text = dr["MinSpace"].ToString();
                    txtMax.Text = dr["MaxSpace"].ToString();

                }
                else
                {
                    MessageBox.Show("Vehicle Type NOT Found!!!");
                    Clear_Controls();
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cnn.Close();
            }
        }

        private void Clear_Controls()
        {
            txtType.Clear();
            txtMin.Clear();
            txtMax.Clear();
        }

        private void Add_Record()
        {
            try
            {

                string sqlAdd;
                sqlAdd = "INSERT INTO TypeTable(Type,MinSpace,MaxSpace) VALUES('" + txtType.Text + "','" + txtMin.Text + "','" + txtMax.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlAdd, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted the Vehicle Type Record");
                Clear_Controls();
                cnn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cnn.Close();

            }
        }

        private void Update_Record()
        {
            try
            {

                string sqlUpdate;
                sqlUpdate = "UPDATE TypeTable SET Type = ('" + txtType.Text + "',MinSpace = '" + txtMin.Text + "', MaxSpace = '" + txtMax.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlUpdate, cnn);
                MessageBox.Show("Record Updated!");
                cnn.Open();
                Clear_Controls();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cnn.Close();
            }
        }

        private void Delete_Record()
        {
            try
            {
                DialogResult res = MessageBox.Show("Do you want to Delete this record?", "");
                if (res == DialogResult.OK)
                {
                    string sqlDelect;
                    sqlDelect = "DELETE FROM TypeTable WHERE Type = '" + txtType.Text + "'";
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sqlDelect, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted!!!");
                }
                Clear_Controls();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cnn.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search_Record();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Record();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear_Controls();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update_Record();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete_Record();
        }
    }

}