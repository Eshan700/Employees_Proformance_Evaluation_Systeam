

using new_payroll.referenceForm.deep;
using new_payroll.referenceForm.employee;
using new_payroll.referenceForm.evaluation;
using new_payroll.referenceForm.temperory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_payroll
{
    public partial class Main : Form
    {
        string desig_id = "";
        string _employee_id = "";
        public Main()
        {
            InitializeComponent();
        }
        public Main(string desig,string employee_id)
        {
            InitializeComponent();
            desig_id = desig;
            _employee_id = employee_id;
        }



        private void OpenChildForm(UserControl childForm)
        {
           
            childForm.Dock = DockStyle.Fill;
            this.panel8.Controls.Add(childForm);
            this.panel8.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
          
         
            deepDesignationButton.BackColor = Color.FromArgb(0, 64, 64);
           // OpenChildForm(new chooseEmploy());
            OpenChildForm(new deepDesignation());


        }

        private void button7_Click(object sender, EventArgs e)
        {
           

        }


        
        private void Main_Load(object sender, EventArgs e)
        {
            
   
            timer1.Start();
            employeeButton.BackColor = Color.FromArgb(0, 64, 64);
            OpenChildForm(new employeeMain(desig_id, _employee_id));

            if(desig_id=="36")
            {

                deepDesignationButton.Enabled = false;
                employeeButton.Enabled = true;
               
                repportsButton.Enabled = false;

            }
            else if(desig_id == "33") {

                deepDesignationButton.Enabled = false;
                employeeButton.Enabled = true;
                button1.Enabled = false;
                repportsButton.Enabled = false;

            }
            //else if (desig_id == "8")
            //{
            //    employeeButton.BackColor = Color.FromArgb(0, 128, 128);
            //    deepDesignationButton.Enabled = true;
            //    employeeButton.Enabled = false;
               
            //    repportsButton.Enabled = false;
            //}
            //else
            //{
            //    deepDesignationButton.Enabled = false;
            //    employeeButton.Enabled = true;
               
            //    repportsButton.Enabled = false;
                
            //}

                    
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
    
            //attendanceButton.BackColor = Color.FromArgb(0, 64, 64);
            //OpenChildForm(new attendance());
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //sidepanel5.Visible = true;
            //sidepanel1.Visible = false;
            //sidepanel3.Visible = false;
            //sidepanel4.Visible = false;
            //sidepanel2.Visible = false;
            //sidepanel6.Visible = false;
            //sidepanel7.Visible = false;
            //sidepanel8.Visible = false;
            //sidepanel9.Visible = false;
            //leaveButton.BackColor = Color.FromArgb(30, 21, 44);
            //OpenChildForm(new referenceForm.leave.leave_main());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //temperyButton.BackColor = Color.FromArgb(0, 64, 64); 
            //OpenChildForm(new referenceForm.leave.leave_main());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

      

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            login_form lf = new login_form();
            lf.Show();
        }

        private void employeeButton_Click(object sender, EventArgs e)
        {
            //Desing part
            OpenChildForm(new employeeMain(desig_id, _employee_id));
            employeeButton.BackColor = Color.FromArgb(0, 64, 64);
        }

      

        private void employeeButton_Leave(object sender, EventArgs e)
        {
            employeeButton.BackColor = Color.FromArgb(0, 128, 128);
        }

        private void sidepanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void deepDesignationButton_Leave(object sender, EventArgs e)
        {
            deepDesignationButton.BackColor = Color.FromArgb(0, 128, 128);
        }

        private void attendanceButton_Leave(object sender, EventArgs e)
        {
            
        }

        private void approveOtButton_Leave(object sender, EventArgs e)
        {
            //approveOtButton.BackColor = Color.FromArgb(83, 66, 111);
        }

        private void leaveButton_Leave(object sender, EventArgs e)
        {
            //leaveButton.BackColor = Color.FromArgb(83, 66, 111);
        }

        private void overTimeButton_Leave(object sender, EventArgs e)
        {
            //overTimeButton.BackColor = Color.FromArgb(83, 66, 111);
        }

        private void payRoleButton_Leave(object sender, EventArgs e)
        {
            //payRoleButton.BackColor = Color.FromArgb(83, 66, 111);
        }

        private void holidayButton_Leave(object sender, EventArgs e)
        {
            //holidayButton.BackColor = Color.FromArgb(83, 66, 111);
        }

        private void temperyButton_Leave(object sender, EventArgs e)
        {
           
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            login_form lf = new login_form();
            lf.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void logoutButton__Click(object sender, EventArgs e)
        {
            
        }

        private void repportsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Report());
            employeeButton.BackColor = Color.FromArgb(0, 128, 128);
            repportsButton.BackColor = Color.FromArgb(0, 64, 64);
            employeeButton.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new evaaluation_main());
            employeeButton.BackColor = Color.FromArgb(0, 128, 128);
            button1.BackColor = Color.FromArgb(0, 64, 64);
            employeeButton.Enabled = true;
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 128, 128);
        }

        private void repportsButton_Leave(object sender, EventArgs e)
        {
            repportsButton.BackColor = Color.FromArgb(0, 128, 128);
        }
    }
}
