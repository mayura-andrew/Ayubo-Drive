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
    public partial class Form5 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog=Ayubo;Integrated Security=True;";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Form5()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Package_Type FROM PackageTable", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comPack.DataSource = dt;
            comPack.DisplayMember = "Package_Type";
            comPack.ValueMember = "Package_Type";

        }



        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void Search_Records()
        {
            string PackageType = comPack.Text;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT Package_ID, Package_Type, Pack_Rate, Max_KM, Max_Hours, ExtraKm_Rate, ExtraHours_Rate, DriverOverNight_Rate, VehicleOverNight_Rate, Vehicle_Type FROM PackageTable WHERE Package_Type=@PackageType ";
                cmd.Parameters.AddWithValue("@PackageType", comPack.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtPackId.Text = dr["Package_ID"].ToString();
                    txtPackRate.Text = dr["Pack_Rate"].ToString();
                    txtMaxKM.Text = dr["Max_KM"].ToString();
                    txtMaxHours.Text = dr["Max_Hours"].ToString();
                    txtExKmRate.Text = dr["ExtraKM_Rate"].ToString();
                    txtExHoursRate.Text = dr["ExtraHours_Rate"].ToString();
                    txtDriOveN.Text = dr["DriverOverNight_Rate"].ToString();
                    txtVehiOveN.Text = dr["VehicleOverNight_Rate"].ToString();
                    txtVehiType.Text = dr["Vehicle_Type"].ToString();
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

            }


        }

        private void Clear_Controls()
        {
            txtPackId.Clear();
            comPack.ResetText();
            txtPackRate.Clear();
            txtMaxKM.Clear();
            txtMaxHours.Clear();
            txtExKmRate.Clear();
            txtExHoursRate.Clear();
            txtDriOveN.Clear();
            txtVehiOveN.Clear();
            txtVehiType.Clear();
        }

        private void dayRour_Cal()
        {
            DateTime startTime, endTime;
            TimeSpan timeGap;
            double totHours;
            int maxHours, numOfHours, extraHours, startKm, endKm, totKm, extKm, kmGap, maxKm, numOfKm;
            double extHourRate, extHrChrge, extKmRate, extKmChrge;

            // Calculation Hours
            startTime = DateTime.Parse(dtStartTime.Text);
            endTime = DateTime.Parse(dtEndTime.Text);
            timeGap = endTime - startTime;
            totHours = timeGap.TotalHours;

            txtTotH.Text = totHours.ToString();

            maxHours = int.Parse(txtMaxHours.Text);
            numOfHours = int.Parse(txtTotH.Text);

            if (numOfHours > maxHours)
                extraHours = numOfHours - maxHours;
            else
                extraHours = 0;

            txtExtH.Text = extraHours.ToString();

            extHourRate = double.Parse(txtExHoursRate.Text);
            extHrChrge = extHourRate * extraHours;
            txtExtHrChrge.Text = extHrChrge.ToString();

            // Calculation Km
            startKm = int.Parse(txtStartKm.Text);
            endKm = int.Parse(txtEndKm.Text);
            kmGap = endKm - startKm;
            totKm = kmGap;

            txtTotKm.Text = totKm.ToString();

            maxKm = int.Parse(txtMaxKM.Text);
            numOfKm = int.Parse(txtTotKm.Text);

            if (numOfKm > maxKm)
                extKm = numOfKm - maxKm;
            else
                extKm = 0;

            txtExKm.Text = extKm.ToString();

            extKmRate = double.Parse(txtExKmRate.Text);
            extKmChrge = extKmRate * extKm;
            txtExKmChrge.Text = extKmChrge.ToString();

            // Total Calculation Part

            double packRate, totAmount;

            packRate = double.Parse(txtPackRate.Text);

            totAmount = packRate + extKmChrge + extHrChrge;
            txtTotAmount.Text = totAmount.ToString();


        }

        private void upload_DayTour()
        {
            try
            {
                Guid myNewId = Guid.NewGuid();
                string sqlAdd;
                sqlAdd = "INSERT INTO DayTourDetailsTable(Tour_ID, Started_Time, Ended_Time, TotalOfHours, ExtraHours, ExtraHoursCharge, Started_KM, Ended_KM, TotalOfKM, ExtraKM, ExtraKMCharge, TotalAmount, Date) VALUES('" + myNewId + "','" + dtStartTime.Value + "','" + dtEndTime.Value + "','" + txtTotH.Text + "','" + txtExtH.Text + "','" + txtExtHrChrge.Text + "','" + txtStartKm.Text + "','" + txtEndKm.Text + "','" + txtTotKm.Text + "','" + txtExKm.Text + "', '" + txtExKmChrge.Text + "','" + txtTotAmount.Text + "', '"+dateTimePicker1.Value+"')";
                SqlCommand cmd = new SqlCommand(sqlAdd, cnn);

                cnn.Open();

                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted the Day Tour Details Record");

                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clear_Cal()
        {
            dtStartTime.ResetText();
            dtEndTime.ResetText();
            txtStartKm.Clear();
            txtEndKm.Clear();
            txtExKm.Clear();
            txtTotH.Clear();
            txtExtH.Clear();
            txtTotKm.Clear();
            txtExtHrChrge.Clear();
            txtExKmChrge.Clear();
            txtTotAmount.Clear();
            dateTimePicker1.ResetText();
        }

        private void comPack_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Search_Records();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear_Controls();
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            clear_Cal();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            dayRour_Cal();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            upload_DayTour();
        }
    }
}