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
    public partial class Form12 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog=Ayubo;Integrated Security=True;";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Form12()
        {
            InitializeComponent();
            FillComboBox();
            dataGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGV.MultiSelect = false;
        }
        private void FillComboBox()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT RentedDate FROM LongTourDetailsTable", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comRentedDate.DataSource = dt;
            comRentedDate.DisplayMember = "RentedDate";
            comRentedDate.ValueMember = "RentedDate";

            SqlDataAdapter dp = new SqlDataAdapter("SELECT ReturnDate FROM LongTourDetailsTable ", cnn);
            DataTable dd = new DataTable();
            dp.Fill(dd);
            comReturnDate.DataSource = dd;
            comReturnDate.DisplayMember = "ReturnDate";
            comReturnDate.ValueMember = "ReturnDate";


        }
        private void historyRented()
        {

            try
            {
            
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT LongTourID, RentedDate, ReturnDate, TotalofDays , BaseHireCharge, StartedKM, EndedKM, TotalofKM, ExtraKM, ExtraKMChrge, TotalLongAmount FROM LongTourDetailsTable WHERE RentedDate = @date";
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
                cmd.CommandText = "SELECT LongTourID, RentedDate, ReturnDate, TotalofDays , BaseHireCharge, StartedKM, EndedKM, TotalofKM, ExtraKM, ExtraKMChrge, TotalLongAmount FROM LongTourDetailsTable WHERE ReturnDate= @date";
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

        private void comRentedDate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            historyRented();
        }

        private void comReturnDate_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  historyReturn();
        }

        private void comRentedDate_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comReturnDate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            historyReturn();
        }
    }
}