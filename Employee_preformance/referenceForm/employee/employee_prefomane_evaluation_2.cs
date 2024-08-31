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
    public partial class employee_prefomane_evaluation_2 : Form
    {
        string _emp_no = "";
        MySqlConnection con;
        public employee_prefomane_evaluation_2()
        {
            InitializeComponent();
        }
        public employee_prefomane_evaluation_2(string emp_no)
        {
            InitializeComponent();
            _emp_no = emp_no;
            con = database.Db.ConnectDB();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (obstacles1.Checked == !true && obstacles2.Checked == !true && obstacles3.Checked == !true && obstacles4.Checked == !true && obstacles5.Checked == !true)
            {
                //MessageBox.Show("employee No cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Obstacles is not valid" + "\n" + "Or Not Checked", Custom_Notification.enumType.warning);
            }

            else if (processes1.Checked == !true && processes2.Checked == !true && processes3.Checked == !true && processes4.Checked == !true && processes5.Checked == !true)
            {
                //MessageBox.Show("Full name is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Processes with written communication is not valid", Custom_Notification.enumType.warning);

            }

            else if (goals1.Checked == !true && goals2.Checked == !true && goals3.Checked == !true && goals4.Checked == !true && goals5.Checked == !true)
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("goals is not valid", Custom_Notification.enumType.warning);
            }
            else
            {
                string work_motivation = checkHoisSelected(obstacles1.Checked, obstacles2.Checked, obstacles3.Checked, obstacles4.Checked, obstacles5.Checked);
                string growth_opportunities = checkHoisSelected(processes1.Checked, processes2.Checked, processes3.Checked,processes4.Checked, processes5.Checked);
                string daily_enthusiasm = checkHoisSelected(goals1.Checked, goals2.Checked, goals3.Checked, goals4.Checked, goals5.Checked);
                
              

                string query = "UPDATE emp_per_evaluation SET work_motivation ='"+ work_motivation + "',growth_opportunities='"+ growth_opportunities + "',daily_enthusiasm='"+ daily_enthusiasm + "' WHERE emp_no ='"+_emp_no+"'";

                con.Close();
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
                this.Alert("Successfully Inserted !!", Custom_Notification.enumType.success);
                clear();
                
                con.Close();
                this.Dispose();
            }
        }

        public void clear()
        {
            obstacles1.Checked = false;
            obstacles2.Checked = false;
            obstacles3.Checked = false;
            obstacles4.Checked = false;
            obstacles5.Checked = false;

            processes1.Checked = false;
            processes2.Checked = false;
            processes3.Checked = false;
            processes4.Checked = false;
            processes5.Checked = false;

            goals1.Checked = false;
            goals2.Checked = false;
            goals3.Checked = false;
            goals4.Checked = false;
            goals5.Checked = false;


         
        }

        public void Alert(string msg, Custom_Notification.enumType type)
        {
            Custom_Notification frm = new Custom_Notification();
            frm.showAlert(msg, type);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
