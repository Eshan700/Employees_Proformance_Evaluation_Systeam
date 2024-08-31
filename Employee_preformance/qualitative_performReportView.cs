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
    public partial class qualitative_performReportView : Form
    {
        string _emp_no = "";
        string _sup_name = "";
        string _month = "";
        string _year = "";
        public qualitative_performReportView()
        {
            InitializeComponent();
        }
        public qualitative_performReportView(string emp_no, string sup_name, string month,string year)
        {
            InitializeComponent();
            _emp_no = emp_no;
            _sup_name = sup_name;
            _month = month;
            _year = year;
        }
        private void qualitative_performReportView_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            string productivityV = "";
            string efficiencyV = "";
            DataTable dt = new DataTable();
            dt.Columns.Add("emp_no");
            dt.Columns.Add("communication");
            dt.Columns.Add("ethics");
            dt.Columns.Add("motivation");
            dt.Columns.Add("productivity");
            dt.Columns.Add("efficiency");
            dt.Columns.Add("month");
            dt.Columns.Add("sup_name");
            dt.Columns.Add("full_name");
            dt.Columns.Add("feedback");
            dt.Columns.Add("reward");
            dt.Columns.Add("level");
            MySqlConnection con = database.Db.ConnectDB();
            con.Open();
            //  string sqlQuery = "SELECT oq.Emp_no,e.full_name,(epe.communication+epe.written_communication+epe.listening)/ 3 as communication,(epe.ethical_conduct+epe.comfort_reporting+epe.alignment_ethical_values)/ 3 as ethics,(epe.work_motivation+epe.growth_opportunities+epe.daily_enthusiasm)/ 3 as motivation,oq.productivity,ef.efficiency,oq.month from output_quality oq  inner join employee e on oq.Emp_no = e.emp_no inner join efficiency ef on oq.Emp_no = ef.emp_no inner join emp_per_evaluation epe on oq.Emp_no = epe.emp_no COLLATE utf8mb4_general_ci;";
            string sqlQuery = @"
    SELECT
        oq.Emp_no,
        e.full_name,
        (epe.communication + epe.written_communication + epe.listening)  as communication,
        (epe.ethical_conduct + epe.comfort_reporting + epe.alignment_ethical_values) as ethics,
        (epe.work_motivation + epe.growth_opportunities + epe.daily_enthusiasm)  as motivation,
        oq.mark AS productivity,
        ef.mark AS efficiency,
        oq.month
    FROM
        output_quality oq
        INNER JOIN employee e ON oq.Emp_no = e.emp_no COLLATE utf8mb4_general_ci
        INNER JOIN efficiency ef ON oq.Emp_no = ef.emp_no COLLATE utf8mb4_general_ci
        INNER JOIN emp_per_evaluation epe ON oq.Emp_no = epe.emp_no COLLATE utf8mb4_general_ci where e.emp_no='"+ _emp_no + "'and oq.month='"+ _month + "' and oq.year='" + _year + "'";

            MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
            MySqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    //int endIndexproductivity = rd["communication"].ToString().LastIndexOf('%');

                    //if (endIndexproductivity >= 0)
                    //{
                    //    productivityV = rd["productivity"].ToString().Substring(0, endIndexproductivity);
                         
                    //}
                    //int endIndexefficiency = rd["efficiency"].ToString().LastIndexOf('%');

                    //if (endIndexefficiency >= 0)
                    //{
                    //    efficiencyV = rd["efficiency"].ToString().Substring(0, endIndexefficiency);

                    //}
                    double totmark = (Convert.ToDouble(rd["communication"].ToString()) + Convert.ToDouble(rd["ethics"].ToString()) + Convert.ToDouble(rd["motivation"].ToString()) + Convert.ToDouble(rd["productivity"].ToString()) + Convert.ToDouble(rd["efficiency"].ToString()));

                    string feedback = genareteFeedBack(totmark.ToString());
                    string reward = genareteReward(totmark.ToString());
                    string level = genareteLevel(totmark.ToString());
                    dt.Rows.Add(rd["emp_no"].ToString(),  rd["communication"].ToString(), rd["ethics"].ToString(), rd["motivation"].ToString(), rd["productivity"].ToString(), rd["efficiency"].ToString(), rd["month"].ToString(),rd["full_name"].ToString(),_sup_name, feedback, reward, level);

                    
                   
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

        public string genareteFeedBack(string prasentage)
        {
            string feedback1 = "";
            if (prasentage != null)
            {
                if (Convert.ToDouble(prasentage) < 55 && Convert.ToDouble(prasentage) >= 45)
                {
                    feedback1 = "Your overall performance is exceptional";
                }
                else if (Convert.ToDouble(prasentage) < 45 && Convert.ToDouble(prasentage) >= 35)
                {
                    feedback1 = "Your overall performance is very strong.";
                }
                else if (Convert.ToDouble(prasentage) < 35 && Convert.ToDouble(prasentage) >= 25)
                {
                    feedback1 = "Your overall performance is solid.";
                }
                else if (Convert.ToDouble(prasentage) < 25 && Convert.ToDouble(prasentage) >= 12)
                {
                    feedback1 = "Your overall performance is satisfactory.";
                }
                else
                {
                    feedback1 = "Your overall performance needs improvement";
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
                    reward = "Let's collaboratively create a development plan that includes targeted training to address identified weaknesses and set clear goals for improvement";
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
