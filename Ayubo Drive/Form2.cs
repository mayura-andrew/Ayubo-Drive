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
    public partial class Form2 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog=Ayubo;Integrated Security=True;";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Form2()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Type FROM " + "TypeTable", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comType.DataSource = dt;
            comType.DisplayMember = "Type";
            comType.ValueMember = "Type";
        }
        private void Search_Record()
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT VehicleReg_No,Vehicle_Name,Vehicle_Type,Vehicle_Brand,Day_Rate,Week_Rate,Mon_Rate,DriverPerDay_Rate,Available_Status FROM VehicleTable WHERE VehicleReg_No =@VehicleNo";
                cmd.Parameters.AddWithValue("@VehicleNo", txtNo.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtName.Text = dr["Vehicle_Name"].ToString();
                    comType.Text = dr["Vehicle_Type"].ToString();
                    txtBrand.Text = dr["Vehicle_Brand"].ToString();
                    txtDrent.Text = dr["Day_Rate"].ToString();
                    txtWrent.Text = dr["Week_Rate"].ToString();
                    txtMrent.Text = dr["Mon_Rate"].ToString();
                    txtDriRent.Text = dr["DriverPerDay_Rate"].ToString();
                    if (dr["Available_Status"].Equals("Yes"))
                        checkYes.Checked = true;
                    else
                        checkNo.Checked = true;

                }
                else
                {
                    MessageBox.Show("Vehicle NOT Found!!!");
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
        private void Add_Record()
        {
            try
            {
                string available;
                if (checkYes.Checked == true)
                    available = "Yes";
                else
                    available = "No";
                string sqlAdd;
                sqlAdd = "INSERT INTO VehicleTable(VehicleReg_No,Vehicle_Name,Vehicle_Type,Vehicle_Brand,Day_Rate,Week_Rate,Mon_Rate,DriverPerDay_Rate,Available_Status) VALUES('" + txtNo.Text + "','" + txtName.Text + "','" + comType.Text + "','" + txtBrand.Text + "','" + txtDrent.Text + "','" + txtWrent.Text + "','" + txtMrent.Text + "','" + txtDriRent.Text + "','" + available + "')";
                SqlCommand cmd = new SqlCommand(sqlAdd, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted the Vehicle Record");
                Clear_Controls();
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
            txtNo.Clear();
            txtName.Clear();
            comType.ResetText();
            txtBrand.Clear();
            txtDrent.Clear();
            txtWrent.Clear();
            txtMrent.Clear();
            txtDriRent.Clear();
            checkYes.Checked = false;
            checkNo.Checked = false;

        }

        private void Update_Record()
        {
            try
            {
                cnn.Open();
                string available;
                if (checkYes.Checked == true)
                    available = "Yes";
                else
                    available = "No";
                string sqlUpdate;
                sqlUpdate = "UPDATE VehicleTable SET VehicleReg_No = '" + txtNo.Text + "',Vehicle_Name = '" + txtName.Text + "',Vehicle_Type = '" + comType.Text + "',Vehicle_Brand = '" + txtBrand.Text + "', Day_Rate = '" + txtDrent.Text + "', Week_Rate= '" + txtWrent.Text + "', Mon_Rate = '" + txtMrent.Text + "', DriverPerDay_Rate = '" + txtDriRent.Text + "', Available = '" + available + "' WHERE Vehicle_No = '" + txtNo.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlUpdate, cnn);
                MessageBox.Show("Record Updated!");

                Clear_Controls();
                cnn.Close();



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
                DialogResult res = MessageBox.Show("Do you want to Delete this record?", "OK");
                if (res == DialogResult.OK)
                {
                    string sqlDelect;
                    sqlDelect = "DELETE FROM VehicleTable WHERE VehicleReg_No = '" + txtNo.Text + "'";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Record();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search_Record();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           Update_Record();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete_Record();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear_Controls();
        }
    }





}
