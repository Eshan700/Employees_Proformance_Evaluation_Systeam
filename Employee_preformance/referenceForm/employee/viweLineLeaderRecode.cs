using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_payroll.referenceForm.employee
{
    public partial class viweLineLeaderRecode : Form
    {
        string fromDate = "";
        string toDate = "";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public viweLineLeaderRecode()
        {
            InitializeComponent();
        }

        double total_production=0;
        double number_of_quality=0;
        double number_of_defects=0;
        double complete_production = 0;
        double incomplete_production = 0;
        public viweLineLeaderRecode(string dateFrom,string dateTo)
        {
            InitializeComponent();
            fromDate=dateFrom;
            toDate=dateTo;
        }

        private void viweLineLeaderRecode_Load(object sender, EventArgs e)
        {
            con = database.Db.ConnectDB();
            string sql = "SELECT SUM(total_production) AS total_production,SUM(number_of_quality) AS number_of_quality,SUM(number_of_defects) AS number_of_defects,SUM(complete_production) AS complete_production,SUM(incomplete_production) AS incomplete_production FROM performencedb.emp_per_evaluation WHERE emp_no = '0132' AND date BETWEEN '2023-08-10' AND '2023-08-30';";

            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    total_production= Convert.ToDouble(dr["total_production"].ToString());
                    number_of_quality = Convert.ToDouble(dr["number_of_quality"].ToString());
                    number_of_defects = Convert.ToDouble(dr["number_of_defects"].ToString());
                    complete_production = Convert.ToDouble(dr["complete_production"].ToString());
                    incomplete_production = Convert.ToDouble(dr["incomplete_production"].ToString());
                   
                }

                dr.Close();
                con.Close();
            }
            dr.Close();
            con.Close();

            displayRecode();
        }

        public void displayRecode()
        {

            labPquality.Text=(Math.Round((number_of_quality / total_production)*100)).ToString()+" %";
            labPdefects.Text=(Math.Round((number_of_defects / total_production)*100)).ToString()+" %";
            labPCproduction.Text=(Math.Round((complete_production / total_production)*100)).ToString()+" %";
            labPInomplete.Text=(Math.Round((incomplete_production / total_production)*100)).ToString()+" %";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emp_profom emp_Profom = new emp_profom(lab_empno.Text);
            emp_Profom.Show();
        }

        private void labPquality_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
