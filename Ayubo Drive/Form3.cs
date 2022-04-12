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
    public partial class Form3 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog=Ayubo;Integrated Security=True;";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Form3()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Type FROM TypeTable", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comVehiType.DataSource = dt;
            comVehiType.DisplayMember = "Type";
            comVehiType.ValueMember = "Type";

            SqlDataAdapter dp = new SqlDataAdapter("SELECT Package_ID FROM PackageTable", cnn);
            DataTable dd = new DataTable();
            dp.Fill(dd);
            comPackId.DataSource = dd;
            comPackId.DisplayMember = "Package_ID";
            comPackId.ValueMember = "Package_ID";
        }

        private void Search_Records()
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT Package_ID, Package_Type, Pack_Rate, Max_KM, Max_Hours, ExtraKm_Rate, ExtraHours_Rate, DriverOverNight_Rate, VehicleOverNight_Rate, Vehicle_Type FROM PackageTable WHERE Package_ID =@PackageID ";
                cmd.Parameters.AddWithValue("@PackageID", comPackId.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtPackType.Text = dr["Package_Type"].ToString();
                    comVehiType.Text = dr["Vehicle_Type"].ToString();
                    txtPackRate.Text = dr["Pack_Rate"].ToString();
                    txtMaxKm.Text = dr["Max_KM"].ToString();
                    txtMaxHours.Text = dr["Max_Hours"].ToString();
                    txtExtraKm.Text = dr["ExtraKM_Rate"].ToString();
                    txtExtraHours.Text = dr["ExtraHours_Rate"].ToString();
                    txtDriOveNight.Text = dr["DriverOverNight_Rate"].ToString();
                    txtVehiOveNight.Text = dr["VehicleOverNight_Rate"].ToString();
                }
                else
                {
                    MessageBox.Show("Package is NOT Found!");
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

        private void Add_Records()
        {
            try
            {
                string sqlAdd;
                sqlAdd = "INSERT INTO PackageTable(Package_ID, Package_Type, Pack_Rate, Max_KM, Max_Hours, ExtraKm_Rate, ExtraHours_Rate, DriverOverNight_Rate, VehicleOverNight_Rate, Vehicle_Type) VALUES('" + comPackId.Text + "','" + txtPackType.Text + "','" + txtPackRate.Text + "','" + txtMaxKm.Text + "','" + txtMaxHours.Text + "','" + txtExtraKm.Text + "','" + txtExtraHours.Text + "','" + txtDriOveNight.Text + "','" + txtVehiOveNight.Text + "','" + comVehiType.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlAdd, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted the Package Record");
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
            comPackId.ResetText();
            txtPackType.Clear();
            comVehiType.ResetText();
            txtPackRate.Clear();
            txtMaxKm.Clear();
            txtMaxHours.Clear();
            txtExtraKm.Clear();
            txtExtraHours.Clear();
            txtDriOveNight.Clear();
            txtVehiOveNight.Clear();
        }

        private void Update_Records()
        {
            try
            {
                string sqlUpdate;
                sqlUpdate = "UPDATE PackageTable SET Package_ID = '" + comPackId.Text + "',Package_Type = '" + txtPackType.Text + "',Pack_Rate = '" + txtPackRate.Text + "',Max_Km= '" + txtMaxKm.Text + "', Max_Hours= '" + txtMaxHours.Text + "', ExtraKm_Rate = '" + txtExtraKm.Text + "', ExtraHours_Rate = '" + txtExtraHours.Text + "', DriverOverNight_Rate  = '" + txtDriOveNight.Text + "', VehicleOverNight_Rate = '" + txtVehiOveNight.Text + "', Vehicle_Type = '" + comVehiType.Text + "'  WHERE Package_ID = '" + comPackId.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlUpdate, cnn);
                MessageBox.Show("Record Updated!");

                Clear_Controls();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Records()
        {
            try
            {
                DialogResult res = MessageBox.Show("Do you want to Delete this record?", "OK");
                if (res == DialogResult.OK)
                {
                    string sqlDelect;
                    sqlDelect = "DELETE FROM PackageTable WHERE Package_ID = '" + comPackId.Text + "'";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Records();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search_Records();   
        }

        private void btnDelect_Click(object sender, EventArgs e)
        {
            Delete_Records();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update_Records();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear_Controls();
        }

        private void comPackId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Search_Records();
        }
    }
}
