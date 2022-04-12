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
    public partial class Form6 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog=Ayubo;Integrated Security=True;";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Form6()
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

        private void longTour_Calculation()
        {
            try
            {
                DateTime rentedDate, returnDate;
                TimeSpan dateGap;
                int totOfDays, numOfDays, maxOfKm, numOfKm, extraKm, strKm, endKm, kmGap, daysGap;
                double packRate, baseHireCharge, extraKMRate, extraKMChrg, vehiOveNight, vehiOvenRate, driOveNight, driOvenRate, totOfLongAmount;

                // calculation of base hire charging
                rentedDate = DateTime.Parse(dtpRentedDate.Text);
                returnDate = DateTime.Parse(dtpReturnDate.Text);
                dateGap = returnDate - rentedDate;
                totOfDays = Convert.ToInt32(dateGap.TotalDays);

                txtTotOfDays.Text = totOfDays.ToString();

                numOfDays = int.Parse(txtTotOfDays.Text);
                packRate = double.Parse(txtPackRate.Text);
                baseHireCharge = numOfDays * packRate;

                txtBaseHireChrg.Text = baseHireCharge.ToString();

                // calculation of km charging

                strKm = int.Parse(txtStrKm.Text);
                endKm = int.Parse(txtEndKm.Text);

                kmGap = endKm - strKm;
                txtTotOfKm.Text = kmGap.ToString();

                maxOfKm = int.Parse(txtMaxKM.Text);
                numOfKm = int.Parse(txtTotOfKm.Text);

                if (numOfKm > maxOfKm)
                    extraKm = numOfKm - maxOfKm;
                else
                    extraKm = 0;
                txtExtraKm.Text = extraKm.ToString();

                extraKMRate = double.Parse(txtExKmRate.Text);
                extraKMChrg = extraKm * extraKMRate;
                txtExtraKMChrg.Text = extraKMChrg.ToString();

                // calculation of Overnight Charging
                if (numOfDays > 2)
                    daysGap = numOfDays - 2;
                else
                    daysGap = 0;

                vehiOvenRate = double.Parse(txtDriOveN.Text);
                driOvenRate = double.Parse(txtVehiOveN.Text);

                vehiOveNight = vehiOvenRate * daysGap;

                driOveNight = driOvenRate * daysGap;

                totOfLongAmount = baseHireCharge + extraKMChrg + vehiOveNight + driOveNight;

                txtLongTot.Text = totOfLongAmount.ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {

                Guid myNewId = Guid.NewGuid();
                string sqlAdd;
                sqlAdd = "INSERT INTO LongTourDetailsTable(LongTourID, RentedDate, ReturnDate, TotalofDays , BaseHireCharge, StartedKM, EndedKM, TotalofKM, ExtraKM, ExtraKMChrge, TotalLongAmount) VALUES('" + myNewId + "','" + dtpRentedDate.Value + "','" + dtpReturnDate.Value + "','" + txtTotOfDays.Text + "','" + txtBaseHireChrg.Text + "','" + txtStrKm.Text + "','" + txtEndKm.Text + "','" + txtTotOfKm.Text + "','" + txtExtraKm.Text + "','" + txtExtraKMChrg.Text + "','" + txtLongTot.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlAdd, cnn);

                cnn.Open();

                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted the Long Tour Calculation Record");
                // Clear_Controls();
                cnn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cnn.Close();

            }
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            dtpRentedDate.ResetText();
            dtpReturnDate.ResetText();
            txtTotOfDays.Clear();
            txtBaseHireChrg.Clear();
            txtStrKm.Clear();
            txtEndKm.Clear();
            txtTotOfKm.Clear();
            txtExtraKMChrg.Clear();
            txtLongTot.Clear();
            txtExtraKm.Clear();
        }

        private void comPack_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Search_Records();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            longTour_Calculation();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear_Controls();
        }
    }
}

