using Microsoft.Reporting.Map.WebForms.BingMaps;
using MySql.Data.MySqlClient;
using new_payroll.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace new_payroll.referenceForm.employee
{
    public partial class employee_preformane_evaluation : Form
    {
        MySqlConnection con;
        string _emp_no;
        public employee_preformane_evaluation()
        {
            InitializeComponent();
        }
        public employee_preformane_evaluation(string emp_no)
        {
            InitializeComponent();
            _emp_no = emp_no;
            con = database.Db.ConnectDB();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        public void Alert(string msg, Custom_Notification.enumType type)
        {
            Custom_Notification frm = new Custom_Notification();
            frm.showAlert(msg, type);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (goals1.Checked == !true && goals2.Checked == !true && goals3.Checked == !true && goals4.Checked == !true && goals5.Checked == !true)
            {
                //MessageBox.Show("employee No cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("goals is not valid" + "\n" + "Or Not Checked", Custom_Notification.enumType.warning);
            }

            else if (subordinates1.Checked == !true && subordinates2.Checked == !true && subordinates3.Checked == !true && subordinates4.Checked == !true && subordinates5.Checked == !true)
            {
                //MessageBox.Show("Full name is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Subordinates with written communication is not valid", Custom_Notification.enumType.warning);

            }

            else if (communication1.Checked ==!true && communication2.Checked==!true && communication3.Checked == !true && communication4.Checked == !true && communication5.Checked == !true)
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Listenin is not valid", Custom_Notification.enumType.warning);
            }
            else if (hours1.Checked == !true && hours2.Checked == !true && hours3.Checked == !true && hours4.Checked == !true && hours5.Checked == !true)
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("hours conduct is not valid", Custom_Notification.enumType.warning);
            }
            else if (responsibilities1.Checked == !true && responsibilities2.Checked == !true && responsibilities3.Checked == !true && responsibilities4.Checked == !true && responsibilities5.Checked == !true)
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("responsibilities is not valid", Custom_Notification.enumType.warning);
            }
            else if (tasks1.Checked == !true && tasks2.Checked == !true && tasks3.Checked == !true && tasks4.Checked == !true && tasks5.Checked == !true)
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Tasks is not valid", Custom_Notification.enumType.warning);
            }
            else if (comboBox1.Text == "")
            {

                this.Alert("Please select a month  ", Custom_Notification.enumType.warning);

            } else if (comboBox2.Text == "")
            {

                this.Alert("Please select a month  ", Custom_Notification.enumType.warning);

            }
            else
            {
                string Communication= checkHoisSelected(goals1.Checked, goals2.Checked, goals3.Checked, goals4.Checked, goals5.Checked);
                string written_communication= checkHoisSelected(subordinates1.Checked, subordinates2.Checked, subordinates3.Checked, subordinates4.Checked, subordinates5.Checked);
                string Listening= checkHoisSelected(communication1.Checked, communication2.Checked, communication3.Checked, communication4.Checked, communication5.Checked);
                string Ethical_conduct= checkHoisSelected(hours1.Checked, hours2.Checked, hours3.Checked, hours4.Checked, hours5.Checked); 
                string Comfort_reporting = checkHoisSelected(responsibilities1.Checked, responsibilities2.Checked, responsibilities3.Checked, responsibilities4.Checked, responsibilities5.Checked);
                string Alignment = checkHoisSelected(tasks1.Checked, tasks2.Checked, tasks3.Checked, tasks4.Checked, tasks5.Checked);

                string query = "INSERT INTO emp_per_evaluation(emp_no,communication,written_communication,listening,ethical_conduct,comfort_reporting,alignment_ethical_values,month,year)" +
                "VALUES ('" + _emp_no + "','" + Communication + "','" + written_communication + "','" + Listening + "', '" + Ethical_conduct + "','" + Comfort_reporting + "', '" + Alignment + "','"+ comboBox1.Text + "','"+ comboBox2.Text+ "')";
                
                con.Close();
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
                this.Alert("Successfully Inserted !!", Custom_Notification.enumType.success);
                clear();
                this.Hide();
                employee_prefomane_evaluation_2 employee_Prefomane_Evaluation_2 = new employee_prefomane_evaluation_2(_emp_no);
                employee_Prefomane_Evaluation_2.Show();
                con.Close();
            }
        }
        public string checkHoisSelected(bool firstButton, bool SecondButton, bool thardButton, bool fourthButton, bool FifthButton)
        {
            string value = "";
            if (firstButton)
            {
                value = "1";


            }
            else if (SecondButton)
            {
                value = "2";

            }
            else if (thardButton)
            {
                value = "3";

            }
            else if (fourthButton)
            {
                value = "4";

            }
            else if (FifthButton)
            {
                value = "5";

            }
            return value;
        }

        public void clear()
        {
            goals1.Checked = false;
            goals2.Checked = false;
            goals3.Checked = false;
            goals4.Checked = false;
            goals5.Checked = false;

            subordinates1.Checked = false;
            subordinates2.Checked = false;
            subordinates3.Checked = false;
            subordinates4.Checked = false;
            subordinates5.Checked = false;

            communication1.Checked=false;
            communication2.Checked=false;
            communication3.Checked=false;
            communication4.Checked=false;
            communication5.Checked=false;

            hours1.Checked = false;
            hours2.Checked = false;
            hours3.Checked = false;
            hours4.Checked = false;
            hours5.Checked = false;

            responsibilities1.Checked=false;
            responsibilities2.Checked=false;
            responsibilities3.Checked=false;
            responsibilities4.Checked=false;
            responsibilities5.Checked=false;

            tasks1.Checked= false;
            tasks2.Checked= false;
            tasks3.Checked= false;
            tasks4.Checked= false;
            tasks5.Checked= false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
