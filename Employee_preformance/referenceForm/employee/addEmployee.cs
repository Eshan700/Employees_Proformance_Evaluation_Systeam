using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_payroll.referenceForm.employee
{
    public partial class addEmployee : Form
    {
        public bool update;
        MySqlConnection con;
        MySqlDataReader dr;
        public addEmployee()
        {
            InitializeComponent();
        }


        ////designation Combobox lode
        private void designationLoad()
        {
            String query = "SELECT * FROM designation";


            try
            {
                con.Open();

                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataReader row = command.ExecuteReader();

                if (row.HasRows)
                {
                    Dictionary<string, string> items = new Dictionary<string, string>();
                    while (row.Read())
                    {
                        if (row["desig_id"].ToString()== "8")
                        {

                        }
                        else
                        {
                            items.Add(row["desig_id"].ToString(), row["designation"].ToString());
                        }
                      

                    }

                    com_designation.DataSource = new BindingSource(items, null);
                    com_designation.DisplayMember = "Value";
                    com_designation.ValueMember = "Key";
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

        private void clear()
        {
            txt_education_qualification.Text = "";
           
            txt_addres.Text = "";
            txt_contact.Text = "";
            emp_no_textbox.Text = "";
            txt_other_qualification.Text = "";
            txt_name.Text = "";
           

        }
        private void button3_Click(object sender, EventArgs e)
        {
            formValidation();
            employeeMain em = new employeeMain();
            em.Show();
        }

        private bool IsValidEmail(string email)
        {
            // Define a regular expression for email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Use Regex.IsMatch to check if the email matches the pattern
            return Regex.IsMatch(email, pattern);
        }
        private void formValidation()
        {

            if (emp_no_textbox.Text == "" || emp_no_is_repeated())
            {
                //MessageBox.Show("employee No cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Emp No is not valid" + "\n" + "Or Repeated", Custom_Notification.enumType.warning);
            }

            else if (txt_name.Text == "" || txt_name.Text.Any(char.IsNumber))
            {
                //MessageBox.Show("Full name is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Name is not valid", Custom_Notification.enumType.warning);

            }
            else if (dateTimePicker1.Value.Month > DateTime.Now.Month - 1)
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Enroolmant date is not valid", Custom_Notification.enumType.warning);
            }
            else if (com_department.SelectedIndex == -1)
            {
                // MessageBox.Show("Department is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Department is not valid", Custom_Notification.enumType.warning);
            }
            else if (com_designation.SelectedIndex == -1)
            {
                //MessageBox.Show("Designation is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Designation is not valid", Custom_Notification.enumType.warning);
            }
            else if (com_status.SelectedIndex == -1)
            {
                //MessageBox.Show("Shift Name is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Status Name is not valid", Custom_Notification.enumType.warning);
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Gender cannot be empty", Custom_Notification.enumType.warning);
            }
            else if (txt_addres.Text == "")
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Address cannot be empty", Custom_Notification.enumType.warning);
            }
            else if (txt_education_qualification.Text == "")
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Education Qualification cannot be empty", Custom_Notification.enumType.warning);
            }
            else if (txt_other_qualification.Text == "")
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Qualification Cannot be empty", Custom_Notification.enumType.warning);
            }
            else if (txt_contact.Text == "" ||!txt_contact.Text.Any(char.IsNumber) || txt_contact.Text.Length!=10)
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Contact Number is not valid", Custom_Notification.enumType.warning);
            }
            else if (!IsValidDOB(dob_dateTimePicker.Value.ToString("yyyyy-MM-dd")))
            {
                // MessageBox.Show("Address cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Alert("Date of Birth is not valid", Custom_Notification.enumType.warning);
            }
            

            else
            {

                Console.WriteLine("weda");
                String emp_no = emp_no_textbox.Text;
                String name = txt_name.Text;
                String enrollment_date = this.dateTimePicker1.Text;
                // String department_id = ((KeyValuePair<string, string>)this.comboBox1.SelectedItem).Key;
                String designation_id = "";
                if (com_designation.SelectedIndex == 0)
                {
                     designation_id = "33";
                }
                else
                {
                     designation_id = "34";
                }
               
                String status = com_status.Text;
                String contact = txt_contact.Text;
                String gender = "";
                if (this.radioButton1.Checked)
                {
                    gender = "Male";
                }
                else if (radioButton2.Checked)
                {
                    gender = "Female";
                }
                String address = txt_addres.Text + " " + textBox1.Text + " " + textBox2.Text;
                String education_qualification = txt_education_qualification.Text;
                String other_qualification = txt_other_qualification.Text;
                String dob = this.dob_dateTimePicker.Text;

                //insert
                if (!update)
                {
                    if(com_designation.SelectedIndex == 0)
                    {
                        if (IsValidEmail(textBox5.Text))
                        {
                          
                            string insertqry = "INSERT INTO admins(empname,email,password,username,employee_id,desig_id,contact1) VALUES ('" + name + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + emp_no + "','33','" + contact + "')";
                            con.Close();
                            con.Open();
                            MySqlCommand cm = new MySqlCommand(insertqry, con);
                            cm.ExecuteNonQuery();
                            con.Close();
                           
                        }
                        else
                        {
                            MessageBox.Show("Invalid email address.");
                            designation_id = "34";
                        }
                    }
                    // employe details inert query
                    string query = "INSERT INTO employee(emp_no,full_name,dob,gender,address,contact_1,status,designation_id,enrollment_date,education_qualification,other_qualification,department_name) " +
                        "VALUES ('" + emp_no + "','" + name + "','" + dob + "','" + gender + "', '" + address + "','" + contact + "', '" + status + "', '" + designation_id + "','" + enrollment_date + "', '" + education_qualification + "','" + other_qualification + "','"+ com_department .Text+ "')";
                    //try
                    //{
                    con.Close();
                    con.Open();
                    MySqlCommand command = new MySqlCommand(query, con);
                    command.ExecuteNonQuery();
                    this.Alert("Successfully Employee Inserted !!", Custom_Notification.enumType.success);

                    clear();
                    con.Close();
                    //}
                    //catch (Exception ex)
                    //{
                    //    con.Close();
                    //    Console.WriteLine(ex);

                    //}

                }
                ////update
                else
                {
                    //try
                    // {

                    if (com_designation.SelectedIndex == 0)
                    {
                        if (IsValidEmail(textBox5.Text))
                        {

                            string updqry = "UPDATE performencedb.admins SET empname='" + name + "',email='" + textBox5.Text + "', username ='" + textBox3.Text + "',password ='" + textBox4.Text + "' WHERE employee_id = '" + emp_no + "'";
                            con.Close();
                            con.Open();
                            MySqlCommand cm = new MySqlCommand(updqry, con);
                            cm.ExecuteNonQuery();
                            con.Close();

                        }
                        else
                        {
                            MessageBox.Show("Invalid email address.");
                        }
                    }
                    con.Close();
                    con.Open();
                    string updatequ = "UPDATE employee SET emp_no= '" + emp_no + "',full_name= '" + name + "',dob= '" + dob + "',gender= '" + gender + "',address= '" + address + "',contact_1='" + contact + "',status='" + status + "',designation_id='" + designation_id + "',enrollment_date='" + enrollment_date + "',education_qualification='" + education_qualification + "',other_qualification= '" + other_qualification + "',department_name='"+ com_department.Text + "' WHERE emp_no = '" + emp_no + "'";
                    MySqlCommand cmd = new MySqlCommand(updatequ, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Alert("Successfully Employee Updated!!", Custom_Notification.enumType.success);

                   
                 
                    con.Close();
                   
                    //}
                    //catch (Exception ex)
                    //{
                    //    //MessageBox.Show("err");
                    //    Console.WriteLine(ex);
                    //    con.Close();
                    //}
                    //}
                }
            }
        }

        //check dob is valid
        static bool IsValidDOB(string dobString)
        {
            DateTime dob;
            bool va = false;
            if (DateTime.TryParse(dobString, out dob))
            {
                // Calculate age by subtracting the birthdate from the current date
                TimeSpan age = DateTime.Now - dob;

                // Check if the age is at least 18 years
                if (age.TotalDays >= (365 * 18))
                {
                     va=true;
                }
                else
                {
                    va= false;
                }
            }
            return va;
            
        }
        //check emp_no is repeated
        public bool emp_no_is_repeated()
        {
            con.Close();
            con.Open();
            string query = "SELECT emp_no FROM employee where emp_no='" + emp_no_textbox.Text + "'";
            MySqlCommand Cmdepf_repeated = new MySqlCommand(query, con);
            MySqlDataReader DRepf_repeated = Cmdepf_repeated.ExecuteReader();

            if (DRepf_repeated.HasRows)
            {
                if (update)
                {
                    return false;
                }
                else
                {
                    return true;
                }

                DRepf_repeated.Close();
                con.Close();
            }
            else
            {

                return false;
                DRepf_repeated.Close();
                con.Close();
            }

            DRepf_repeated.Close();
            con.Close();
        }
        private void addEmployee_Load(object sender, EventArgs e)
        {
            if (!update)
            {
                con = database.Db.ConnectDB();
                //departmentLoad();
                con.Open();

                string Qry = "SELECT MAX(COALESCE(Employee_id, 0)) AS MaxEmployeeId FROM performencedb.employee";
                MySqlCommand cmd = new MySqlCommand(Qry, con);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Check for null or DBNull before casting to int
                    emp_no_textbox.Text = (Convert.ToInt32(result) + 1).ToString();
                }
                else
                {
                    // Handle the case where the result is null or DBNull
                    emp_no_textbox.Text = "1"; // or any default value you want to set
                }
                con.Close();
            }
            else
            {
                con = database.Db.ConnectDB();
            }
           
           
            
            designationLoad();
        }

        public void Alert(string msg, Custom_Notification.enumType type)
        {
            Custom_Notification frm = new Custom_Notification();
            frm.showAlert(msg, type);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txt_contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_education_qualification_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void com_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void com_designation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void com_designation_SelectedIndexChanged_1(object sender, EventArgs e)
        {
                if(com_designation.SelectedIndex == 0)
            {
                label6.Visible = true;
                label9.Visible = true;
                label11.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                label6.Visible = false;
                label9.Visible = false;
                label11.Visible = false;
                textBox4.Visible = false;
                textBox3.Visible = false;
                textBox5.Visible = false;
            }
        }
    }
}
