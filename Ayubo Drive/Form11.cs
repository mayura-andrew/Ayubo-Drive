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
   
    public partial class Form11 : Form
    {
        static string connectionString = "Data Source=DESKTOP-UO6IKBR;Initial Catalog=Ayubo;Integrated Security=True;";
        SqlConnection cnn = new SqlConnection(connectionString);
        public Form11()
        {
            InitializeComponent();
            FillComboBox();

            dataGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGV.MultiSelect = false;
        }

        private void FillComboBox()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Date FROM DayTourDetailsTable", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comDayTourDate.DataSource = dt;
            comDayTourDate.DisplayMember = "Date";
            comDayTourDate.ValueMember = "Date";
        }

        private void historyDayTour()
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Tour_ID, Started_Time, Ended_Time, TotalOfHours, ExtraHours, ExtraHoursCharge, Started_KM, Ended_KM, TotalOfKM, ExtraKM, ExtraKMCharge, TotalAmount, date FROM DayTourDetailsTable WHERE date= @date";
                cmd.Parameters.AddWithValue("@date", (comDayTourDate.Text));

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

        private void comDayTourDate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            historyDayTour();   
        }
    }
}
