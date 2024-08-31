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

namespace new_payroll.referenceForm.employee
{
    public partial class employeeMain : UserControl
    {


        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        string desig_id = "";
        string reg_date = "";
        string _employee_id = "";

        public employeeMain()
        {
            //InitializeComponent();
            //con = database.Db.ConnectDB();
            //sho();
        }
        string emp_qry = "";
        public employeeMain(string desig,string employee_id)
        {
            InitializeComponent();
            con = database.Db.ConnectDB();
            this.desig_id = desig;
            _employee_id = employee_id;
            if (desig_id == "36")
            {
                
                emp_qry = "select employee.emp_no,employee.full_name,employee.enrollment_date,employee.department_name,designation.designation,employee.status,employee.contact_1,employee.address,employee.dob,employee.gender,employee.education_qualification,employee.other_qualification from employee inner join designation on employee.designation_id=designation.desig_id WHERE designation_id != '33' and designation_id != '36' and designation_id != '8'and designation_id != '4' and status='permanant'";
            }
            else if (desig_id == "33")
            {

                editButon2.Show();
                //emp_qry = "select employee.emp_no,employee.full_name,employee.enrollment_date,employee.department_name,designation.designation,employee.status,employee.contact_1,employee.address,employee.dob,employee.gender,employee.education_qualification,employee.other_qualification from employee inner join designation on employee.designation_id=designation.desig_id WHERE designation_id != '33' and designation_id != '36' and designation_id != '8'and designation_id != '4' and status='permanant'";
                emp_qry =@"
    SELECT employee.emp_no,
           employee.full_name,
           employee.enrollment_date,
           employee.department_name,
           designation.designation,
           employee.status,
           employee.contact_1,
           employee.address,
           employee.dob,
           employee.gender,
           employee.education_qualification,
           employee.other_qualification
    FROM employee
    INNER JOIN designation ON employee.designation_id = designation.desig_id
    WHERE designation_id != '33'
      AND designation_id != '36'
      AND designation_id != '8'
      AND designation_id != '4'
      AND status = 'permnent'
      AND NOT EXISTS (
          SELECT 1
          FROM emp_per_evaluation
          WHERE emp_per_evaluation.emp_no = employee.emp_no
          -- Add additional conditions if needed
      );
";

            }
            else
            {
                //pictureBox1.Hide();
                //dateFrom.Hide();
                //dateTo.Hide();
                //label1.Visible = false;
                //label2.Visible = false;
                //editButon2.Hide();
                emp_qry = "select employee.emp_no,employee.full_name,employee.enrollment_date,department_name,designation.designation,employee.status,employee.contact_1,employee.address,employee.dob,employee.gender,employee.education_qualification,employee.other_qualification from employee inner join designation on employee.designation_id=designation.desig_id WHERE designation_id != '33' and designation_id != '36' and designation_id != '8'and designation_id != '4' and status='permanant'";

            }
            sho();

        }

        //Data Enter the datagridview1
        public void sho()
        {

           dataGridView1.Rows.Clear();
            con.Open();
            MySqlCommand cmd = new MySqlCommand(emp_qry, con);
            MySqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = dr["emp_no"].ToString(); ;
                    newRow.Cells[1].Value = dr["full_name"].ToString();
                    newRow.Cells[2].Value = dr["enrollment_date"].ToString();
                    newRow.Cells[3].Value = dr["department_name"].ToString();
                    newRow.Cells[4].Value = dr["designation"].ToString();
                    newRow.Cells[5].Value = dr["status"].ToString();
                    newRow.Cells[6].Value = dr["contact_1"].ToString();
                    newRow.Cells[7].Value = dr["address"].ToString();
                    newRow.Cells[11].Value = dr["dob"].ToString();
                    newRow.Cells[10].Value = dr["gender"].ToString();
                    newRow.Cells[9].Value = dr["other_qualification"].ToString();
                    newRow.Cells[8].Value = dr["education_qualification"].ToString();
                    reg_date = dr["enrollment_date"].ToString();
                    dataGridView1.Rows.Add(newRow);


                }


                con.Close();
            }

        }





        private void employeeMain_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (desig_id == "33")
            {
                pictureBox1.Visible = false;



            }
            else
            {
                pictureBox1.Visible = true;
            }
        }
        private void insertButon1_Click(object sender, EventArgs e)
        {
            //manage_emp me = new manage_emp();
           // me.update = true;
            //me.Show();
        }

        private void editButon1_Click(object sender, EventArgs e)
        {
          
        }

        private void editButon2_Click(object sender, EventArgs e)
        {
           
            if (desig_id == "33")
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    employee_preformane_evaluation employee_Preformane_Evaluation =new employee_preformane_evaluation(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    employee_Preformane_Evaluation.Show();
                }

                else
            
                {
                MessageBox.Show("Please Select A Record !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
                }
        }
            else
            {
                addEmployee ae = new addEmployee();
                ae.Show();
            }
            //if (dataGridView1.SelectedRows.Count == 1)
            //{
            //    dataAdmin_Employe_cheng mec = new dataAdmin_Employe_cheng();
            //    mec.lab_name.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //    mec.lab_emp_no.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //    mec.leb_department.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //    //mec.lab_enroll.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //    mec.Show();
            //}

            //else
            //{
            //    MessageBox.Show("Please Select A Record !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        //    if (dataGridView1.SelectedRows.Count == 1)
        //    {
        //        viweLineLeaderRecode viweLineLeaderRecode = new viweLineLeaderRecode(dateFrom.Value.ToString(), dateTo.Value.ToString());

        //        viweLineLeaderRecode.lab_empno.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        //        viweLineLeaderRecode.lab_name.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

        //        viweLineLeaderRecode.Show();

        //    }

        //    else
        //    {
        //        MessageBox.Show("Please Select A Record !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
          
                pictureBox1.Visible = true;
                if (dataGridView1.SelectedRows.Count == 1)
                {

                    addEmployee me = new addEmployee();
                    me.emp_no_textbox.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    me.txt_name.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    me.dateTimePicker1.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[2].Value.ToString());
                    me.com_department.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

                    me.com_designation.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    me.com_status.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    me.txt_contact.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    me.txt_addres.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    me.txt_education_qualification.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    me.txt_other_qualification.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    if (this.dataGridView1.CurrentRow.Cells[10].Value.ToString() == "Male")
                    {
                        me.radioButton1.Checked = true;
                    }
                    else
                    {
                        me.radioButton2.Checked = true;
                    }

                    me.dob_dateTimePicker.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[11].Value.ToString());


                    me.update = true;
                    me.Show();
                }

                else
                {
                    MessageBox.Show("Please Select A Record !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //MessageBox.Show("Please Select A Record !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        public void sho2()
        {
            string emp_qry2 = @"
    SELECT employee.emp_no,
           employee.full_name,
           employee.enrollment_date,
           employee.department_name,
           designation.designation,
           employee.status,
           employee.contact_1,
           employee.address,
           employee.dob,
           employee.gender,
           employee.education_qualification,
           employee.other_qualification
    FROM employee
    INNER JOIN designation ON employee.designation_id = designation.desig_id
    WHERE designation_id != '33'
      AND designation_id != '36'
      AND designation_id != '8'
      AND designation_id != '4'
      AND status = 'Permanant'
      AND supervisor = @Supervisor
      AND NOT EXISTS (
          SELECT 1
          FROM emp_per_evaluation
          WHERE emp_per_evaluation.emp_no = employee.emp_no
            AND emp_per_evaluation.month = @Month
            AND emp_per_evaluation.year = @Year
      );
";
            con.Close();

            dataGridView1.Rows.Clear();
            con.Open();
            MySqlCommand cmd = new MySqlCommand(emp_qry2, con);
            cmd.Parameters.AddWithValue("@Supervisor", _employee_id);
            cmd.Parameters.AddWithValue("@Month", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Year", comboBox5.Text);
            MySqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = dr["emp_no"].ToString(); ;
                    newRow.Cells[1].Value = dr["full_name"].ToString();
                    newRow.Cells[2].Value = dr["enrollment_date"].ToString();
                    newRow.Cells[3].Value = dr["department_name"].ToString();
                    newRow.Cells[4].Value = dr["designation"].ToString();
                    newRow.Cells[5].Value = dr["status"].ToString();
                    newRow.Cells[6].Value = dr["contact_1"].ToString();
                    newRow.Cells[7].Value = dr["address"].ToString();
                    newRow.Cells[11].Value = dr["dob"].ToString();
                    newRow.Cells[10].Value = dr["gender"].ToString();
                    newRow.Cells[9].Value = dr["other_qualification"].ToString();
                    newRow.Cells[8].Value = dr["education_qualification"].ToString();
                    reg_date = dr["enrollment_date"].ToString();
                    dataGridView1.Rows.Add(newRow);


                }


                con.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "" && comboBox5.Text != "")
            {
                sho2();
                dataGridView1.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Select a Date !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              
            }
           
        }
    }
    
}
