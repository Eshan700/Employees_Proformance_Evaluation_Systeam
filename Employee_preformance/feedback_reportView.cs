using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using new_payroll.referenceForm.evaluation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_payroll
{
    public partial class feedback_reportView : Form
    {
        string _month = "";
        string _year = "";
        public feedback_reportView()
        {
            InitializeComponent();
        } 
        public feedback_reportView(string month,string year)
        {
            InitializeComponent();
            _month = month;
            _year  = year;
        }

        private void feedback_reportView_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("employee_id");
            dt.Columns.Add("Emp_no");
            dt.Columns.Add("full_name");
            dt.Columns.Add("feedback");
            dt.Columns.Add("month");
            dt.Columns.Add("reward");
            dt.Columns.Add("level");
            dt.Columns.Add("average_performance");
            dt.Columns.Add("year");
            MySqlConnection con = database.Db.ConnectDB();
            con.Open();
            string sqlQuery = @"
          SELECT 
    e.employee_id,
    oq.Emp_no,
    e.full_name,
    (
        oq.mark + ef.mark +
        epe.communication + epe.written_communication + epe.listening +
        epe.ethical_conduct + epe.comfort_reporting + epe.alignment_ethical_values +
        epe.work_motivation + epe.growth_opportunities + epe.daily_enthusiasm
    ) AS average_performance,
    oq.month
FROM
    output_quality oq
    INNER JOIN employee e ON oq.Emp_no = e.emp_no
    INNER JOIN efficiency ef ON oq.Emp_no = ef.emp_no
    INNER JOIN performencedb.emp_per_evaluation epe ON oq.Emp_no = epe.emp_no
WHERE
    CONVERT(ef.month USING utf8mb4) = '"+_month+"'";

            MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
            MySqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    string feedback = genareteFeedBack(rd["average_performance"].ToString());
                    string reward = genareteReward(rd["average_performance"].ToString());
                    string level= genareteLevel(rd["average_performance"].ToString());
                    dt.Rows.Add(rd["employee_id"].ToString(), rd["Emp_no"].ToString(), rd["full_name"].ToString(), feedback, rd["month"].ToString(), reward, level, rd["average_performance"].ToString(),_year);


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
        }

        public string genareteFeedBack(string prasentage)
        {
            string feedback1 = "";
            if(prasentage != null)
            {
                if(Convert.ToDouble(prasentage)< 55 && Convert.ToDouble(prasentage)>= 45)
                {
                    feedback1 = "Performance is exceptional";
                }
                else if(Convert.ToDouble(prasentage) < 45 && Convert.ToDouble(prasentage) >= 35)
                {
                    feedback1 = "Performance is very strong.";
                }
                else if(Convert.ToDouble(prasentage) < 35 && Convert.ToDouble(prasentage) >= 25)
                {
                    feedback1 = "Performance is solid.";
                }
                else if (Convert.ToDouble(prasentage) < 25 && Convert.ToDouble(prasentage) >= 12)
                {
                    feedback1 = "Performance is satisfactory.";
                }
                else
                {
                    feedback1 = "Performance needs improvement";
                }
               
            }
            return feedback1;
        }

        public string genareteReward(string prasentage)
        {
            string reward = "";
            if (prasentage != null)
            {
                if (Convert.ToDouble(prasentage) < 55 && Convert.ToDouble(prasentage) >= 45)
                {
                    reward = "Given your outstanding performance, let's explore opportunities for leadership roles within the team or consider specialized training to further enhance your expertise";
                }
                else if (Convert.ToDouble(prasentage) < 45 && Convert.ToDouble(prasentage) >= 35)
                {
                    reward = "To maintain your growth, explore mentorship opportunities and tailored training programs to prepare for leadership roles or specialized tasks.";
                }
                else if (Convert.ToDouble(prasentage) < 35 && Convert.ToDouble(prasentage) >= 25)
                {
                    reward = "To advance your career, consider additional training programs to build specialized skills or take on leadership responsibilities to demonstrate your readiness for promotion.";
                }
                else if (Convert.ToDouble(prasentage) < 25 && Convert.ToDouble(prasentage) >= 12)
                {
                    reward  = "Let's collaboratively create a development plan that includes targeted training to address identified weaknesses and set clear goals for improvement";
                }
                else
                {
                    reward = "Let's work closely on a comprehensive improvement plan.";
                }

            }
            return reward;
        }
        public string genareteLevel(string prasentage)
        {
            string reward = "";
            if (prasentage != null)
            {
                if (Convert.ToDouble(prasentage) < 55 && Convert.ToDouble(prasentage) >= 45)
                {
                    reward = "Excellent performance";
                }
                else if (Convert.ToDouble(prasentage) < 45 && Convert.ToDouble(prasentage) >= 35)
                {
                    reward = "Satisfactory performance";
                }
                else if (Convert.ToDouble(prasentage) < 35 && Convert.ToDouble(prasentage) >= 25)
                {
                    reward = "Average improvement";
                }
                else if (Convert.ToDouble(prasentage) < 25 && Convert.ToDouble(prasentage) >= 12)
                {
                    reward = "Need performance"; 
                }
                else
                {
                    reward = "Need significant improvements";
                }

            }
            return reward;
        }
    }
}
