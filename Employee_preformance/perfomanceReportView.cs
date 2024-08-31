using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using new_payroll.database;
using new_payroll.referenceForm.evaluation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace new_payroll
{
    public partial class perfomanceReportView : Form
    {
        string _month = "";
        string _year = "";
        public perfomanceReportView()
        {
            InitializeComponent();
        }public perfomanceReportView(string month,string year)
        {
            InitializeComponent();
            _month=month;
            _year = year;
        }

        private void perfomanceReportView_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
         
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("employee_id");
            dt.Columns.Add("Emp_no");
            dt.Columns.Add("full_name");
            dt.Columns.Add("average_performance");
            dt.Columns.Add("month");
            dt.Columns.Add("year");
            MySqlConnection con = database.Db.ConnectDB();
            con.Open();
            string sqlQuery = "SELECT e.employee_id,oq.Emp_no, e.full_name,(oq.mark + ef.mark +epe.communication + epe.written_communication + epe.listening +epe.ethical_conduct + epe.comfort_reporting + epe.alignment_ethical_values +epe.work_motivation + epe.growth_opportunities + epe.daily_enthusiasm) AS average_performance,oq.month from output_quality oq  inner join employee e on oq.Emp_no = e.emp_no inner join efficiency ef on oq.Emp_no = ef.emp_no   INNER JOIN performencedb.emp_per_evaluation epe ON oq.Emp_no = epe.emp_no where ef.month='" + _month + "' and ef.year='" + _year + "'";

            MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
            MySqlDataReader rd =cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while(rd.Read()) {

                    dt.Rows.Add(rd["employee_id"].ToString(), rd["Emp_no"].ToString(), rd["full_name"].ToString(), rd["average_performance"].ToString(), rd["month"].ToString(), _year);


                }
            }
           
            if (0 < dt.Rows.Count)
            {

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;

            }
          
            else
            {
                con.Close();
                MessageBox.Show("No Invoice found for the selected date", "Paysheet Viewer", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            //rd.Close();
            ////da.Fill(dt);
            //con.Close();

        }
    }
}
