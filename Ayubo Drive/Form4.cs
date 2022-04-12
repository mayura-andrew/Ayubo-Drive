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
    public partial class Form4 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog=Ayubo;Integrated Security=True;";
        SqlConnection cnn = new SqlConnection(connectionString);

        private DateTime retrunDate;
        private int i;
        public Form4()
        {
            InitializeComponent();
            FillComboBox();
            dataGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGV.MultiSelect = false;

        }
        private void FillComboBox()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT VehicleReg_No FROM VehicleTable", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comVehicleNo.DataSource = dt;
            comVehicleNo.DisplayMember = "VehicleReg_No";
            comVehicleNo.ValueMember = "VehicleReg_No";
        }

        private void calculate_Totdays(object sender, EventArgs e)
        {
            DateTime rentedDate, returnDate;
            TimeSpan dateDif;
            Double gap;
            rentedDate = DateTime.Parse(dtpRentedDate.Text);
            retrunDate = DateTime.Parse(dtpReturnDate.Text);
            dateDif = retrunDate - rentedDate;
            gap = dateDif.TotalDays;
            txtTotDays.Text = gap.ToString();

        }

        private void rentCal()
        {
            int totDays, totMonths, totWeeks, NoDays, amt, totCost;
            int remainder;

            DateTime rentedDate, returnDate;
            TimeSpan dateDif;
            Double gap;
            rentedDate = DateTime.Parse(dtpRentedDate.Text);
            retrunDate = DateTime.Parse(dtpReturnDate.Text);
            dateDif = retrunDate - rentedDate;
            gap = dateDif.TotalDays;
            txtTotDays.Text = gap.ToString();

            totDays = int.Parse(txtTotDays.Text);
            // calculate months assumed 30 days per month
            totMonths = totDays / 30;
            txtMonths.Text = totMonths.ToString();
            remainder = totDays % 30;
            totWeeks = remainder / 7;
            txtWeeks.Text = totWeeks.ToString();

            NoDays = remainder % 7;
            txtDays.Text = NoDays.ToString();

            int dRate = Convert.ToInt32(dataGV.Rows[i].Cells["Day_Rate"].Value);
            int wRate = Convert.ToInt32(dataGV.Rows[i].Cells["Week_Rate"].Value);
            int mRate = Convert.ToInt32(dataGV.Rows[i].Cells["Mon_Rate"].Value);
            int driRate = Convert.ToInt32(dataGV.Rows[i].Cells["DriverPerDay_Rate"].Value);
            amt = totMonths * mRate + totWeeks * wRate + NoDays * dRate;

            if (checkDri.Checked == true)
                totCost = amt + (totDays * driRate);

            else
                totCost = amt;
            txtTot.Text = totCost.ToString();
        }

        private void upload()
        {
            try
            {
                string driverStatus;
                if (checkDri.Checked == true)
                    driverStatus = "Yes";
                else
                    driverStatus = "No";
                Guid myNewId = Guid.NewGuid();
                string sqlAdd;
                sqlAdd = "INSERT INTO RentDetailsTable(Rent_ID, Rented_Date, Return_Date, Driver_Status, Months, Weeks, Days, TotalOfDays, TotalAmount) VALUES('" + myNewId + "','" + dtpRentedDate.Value + "','" + dtpReturnDate.Value + "','" + driverStatus + "','" + txtMonths.Text + "','" + txtWeeks.Text + "','" + txtDays.Text + "','" + txtTotDays.Text + "','" + txtTot.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlAdd, cnn);

                cnn.Open();

                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted the Rent Calculation Record");
                // Clear_Controls();
                cnn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cnn.Close();

            }


        }

        private void datagrid()
        {
            string vehicleNo = comVehicleNo.Text;

            //his.dataGridView1.Rows.Clear();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT VehicleReg_No,Vehicle_Name,Vehicle_Type,Vehicle_Brand,Day_Rate,Week_Rate,Mon_Rate,DriverPerDay_Rate,Available_Status FROM VehicleTable WHERE VehicleReg_No =@VehicleNo";
                cmd.Parameters.AddWithValue("@vehicleNo", (comVehicleNo.SelectedIndex) + 1);

                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(cmd);

                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGV.DataSource = DS.Tables[0];

                cnn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear_Controls()
        {
            dtpRentedDate.ResetText();
            dtpReturnDate.ResetText();
            txtTotDays.Clear();
            txtWeeks.Clear();
            txtDays.Clear();
            txtMonths.Clear();
            txtTot.Clear();
            comVehicleNo.ResetText();
            

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            upload();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear_Controls();
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            rentCal();
        }

        private void comVehicleNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            datagrid();
        }
    }
}