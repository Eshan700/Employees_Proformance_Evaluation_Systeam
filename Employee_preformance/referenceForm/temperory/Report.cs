using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace new_payroll.referenceForm.temperory
{
    public partial class Report : UserControl
    {
        MySqlConnection con;
        MySqlDataReader dr;
        public Report()
        {
            InitializeComponent();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please selected Month", "Paysheet Viewer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           else if (comboBox5.Text == "")
            {
                MessageBox.Show("Please selected Year", "Paysheet Viewer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                perfomanceReportView perfomanceReportView = new perfomanceReportView(comboBox2.Text, comboBox5.Text);
                perfomanceReportView.Show();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Please selected Month", "Paysheet Viewer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (comboBox6.Text == "")
            {
                MessageBox.Show("Please selected Year", "Paysheet Viewer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                feedback_reportView feedback_ReportView = new feedback_reportView(comboBox3.Text, comboBox6.Text);
                feedback_ReportView.Show();
            }
        }

        private void employeeLoad()
        {
            String query = "SELECT * FROM employee where designation_id='34'";


            try
            {
                con=database.Db.ConnectDB();
                con.Open();

                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataReader row = command.ExecuteReader();

                if (row.HasRows)
                {
                    Dictionary<string, string> items = new Dictionary<string, string>();
                    while (row.Read())
                    {
                        items.Add(row["emp_no"].ToString(), row["full_name"].ToString());

                    }

                    comboBox1.DataSource = new BindingSource(items, null);
                    comboBox1.DisplayMember = "Value";
                    comboBox1.ValueMember = "Key";
                    //if (!update)
                    //{
                    //    comboBox2.Text = edit_designations;
                    //}
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("errdesignation");
                Console.WriteLine(ex);

            }

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            employeeLoad();
        }

        public string SearchSuperName(string emp_id)
        {
            //if (emp_id != null)
            //{
                con.Open();
                string supname = "";
                string sql = "SELECT full_name FROM employee WHERE emp_no = (SELECT supervisor FROM employee WHERE emp_no = '" + emp_id + "')"; 
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        supname = dr["full_name"].ToString();
                    }
                    //try { }catch(Exception ex) { }

                }
                dr.Close();
                con.Close();
            return supname;
            //}
            //else
            //{
            //    MessageBox.Show("Please check employee", "Paysheet Viewer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return "";
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
             if (comboBox1.SelectedIndex != -1 && comboBox4.SelectedIndex !=-1)
            {
                String emp_id = ((KeyValuePair<string, string>)this.comboBox1.SelectedItem).Key;
                string supName = SearchSuperName(emp_id);
                if (supName == "")
                {
                    MessageBox.Show("Please You Need Add\nsupervisor to this employee", "Paysheet Viewer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    qualitative_performReportView qualitative_PerformReportView = new qualitative_performReportView(emp_id, supName, comboBox4.Text,comboBox7.Text);
                    qualitative_PerformReportView.Show();
                }

            }
            else
            {
                MessageBox.Show("Please selected employee", "Paysheet Viewer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
