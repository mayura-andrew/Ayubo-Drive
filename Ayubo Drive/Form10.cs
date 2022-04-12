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
    public partial class Form10 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog=Ayubo;Integrated Security=True;";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Form10()
        {
            InitializeComponent();
            FillComboBox();
           
            dataGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGV.MultiSelect = false;
        }

        private void FillComboBox()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Rented_Date FROM RentDetailsTable", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comRentedDate.DataSource = dt;
            comRentedDate.DisplayMember = "Rented_Date";
            comRentedDate.ValueMember = "Rented_Date";

            SqlDataAdapter dp = new SqlDataAdapter("SELECT Return_Date FROM RentDetailsTable ", cnn);
            DataTable dd = new DataTable();
            dp.Fill(dd);
            comReturnDate .DataSource = dd;
            comReturnDate.DisplayMember = "Return_Date";
            comReturnDate.ValueMember = "Return_Date";


        }

       
        private void historyRented()
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Rent_ID, Rented_Date, Return_Date, Driver_Status, Months, Weeks, Days, TotalOfDays, TotalAmount FROM RentDetailsTable WHERE Rented_Date= @date";
                cmd.Parameters.AddWithValue("@date", (comRentedDate.Text));

                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGV.DataSource = DS.Tables[0];

                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Details NOT Found!!!");
            }

         

        }

        private void historyReturn()
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Rent_ID, Rented_Date, Return_Date, Driver_Status, Months, Weeks, Days, TotalOfDays, TotalAmount FROM RentDetailsTable WHERE Return_Date= @date";
                cmd.Parameters.AddWithValue("@date", (comReturnDate.Text));

                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGV.DataSource = DS.Tables[0];

                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Details NOT Found!!!");
            }



        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //history();
        }

        private void comRentedDate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            historyRented();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comRentedDate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
          //  history();
        }

        private void comReturnDate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            historyReturn();
        }
    }
}
