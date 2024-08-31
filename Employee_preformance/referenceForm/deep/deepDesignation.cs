using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_payroll.referenceForm.deep
{
    public partial class deepDesignation : UserControl
    {

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
        public deepDesignation()
        {
            InitializeComponent();
            con = database.Db.ConnectDB();



        }
        public void Alert(string msg, Custom_Notification.enumType type)
        {
            Custom_Notification frm = new Custom_Notification();
            frm.showAlert(msg, type);
        }


        private void deepDesignation_Load(object sender, EventArgs e)
        {
            column.HeaderText = "Check";
            column.Name = "checkBoxColumn";
            dataGridView1.Columns.Add(column);
            Evaluator_load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(e.ColumnIndex + e.RowIndex);
            Console.WriteLine(dataGridView1.CurrentCell.Value);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Evaluator_load()
        {

            String query = "select employee.emp_no,employee.full_name from employee WHERE designation_id = '33'";


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
                        items.Add(row["emp_no"].ToString(), row["full_name"].ToString());

                    }

                    comboBox1.DataSource = new BindingSource(items, null);
                    comboBox1.DisplayMember = "Value";
                    comboBox1.ValueMember = "Key";

                    con.Close();
                    sho();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("errdesignation");
                Console.WriteLine(ex);

            }

        }

        public void sho()
        {
            String emp_qry = "SELECT employee.emp_no, employee.full_name,employee.department_name, designation.designation,add_sup_date FROM employee INNER JOIN designation ON employee.designation_id = designation.desig_id WHERE employee.designation_id = '34' and employee.supervisor is null;";

            dataGridView1.Rows.Clear();
            con.Close();
            con.Open();
            cmd = new MySqlCommand(emp_qry, con);
            dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    DataGridViewCheckBoxCell col = new DataGridViewCheckBoxCell();
                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = dr["emp_no"].ToString(); ;
                    newRow.Cells[1].Value = dr["full_name"].ToString();

                    newRow.Cells[2].Value = dr["department_name"].ToString();
                    newRow.Cells[3].Value = dr["designation"].ToString();

                    dataGridView1.Rows.Add(newRow);



                }


                con.Close();
                SupervisorSelect();
            }

        }

        //public void sho1()
        //{
        //    String emp_qry = "SELECT employee.emp_no, employee.full_name, designation.designation FROM employee INNER JOIN designation ON employee.designation_id = designation.desig_id WHERE employee.designation_id != '33';";

        //    dataGridView2.Rows.Clear();
        //    con.Close();
        //    con.Open();
        //    cmd = new MySqlCommand(emp_qry, con);
        //    dr = cmd.ExecuteReader();


        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            DataGridViewRow newRow = new DataGridViewRow();

        //            newRow.CreateCells(dataGridView2);
        //            newRow.Cells[0].Value = dr["emp_no"].ToString(); ;
        //            newRow.Cells[1].Value = dr["full_name"].ToString();

        //            newRow.Cells[2].Value = "Production Department";
        //            newRow.Cells[3].Value = dr["designation"].ToString();
        //            dataGridView2.Rows.Add(newRow);



        //        }


        //        con.Close();
        //    }
        //    con.Close();
        //}
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sho1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            sho();
        }
        public void SupervisorSelect()
        {

            object leaderEMP_No = textBox1.Text;
            if (0 < dataGridView1.RowCount)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (leaderEMP_No != null && !leaderEMP_No.ToString().Any(char.IsLetter))
                    {
                        string emp_no = row.Cells[0].Value.ToString();
                        DataGridViewCell cell = dataGridView1.Rows[row.Index].Cells[column.Index];

                        if (row.Cells[column.Index].Value != null && row.Cells[column.Index].Value is bool)
                        {
                            bool isCheck = (bool)row.Cells[column.Index].Value;
                            DataGridViewRow newRow = new DataGridViewRow();
                            // DataGridViewCheckBoxCell col = new DataGridViewCheckBoxCell();
                            newRow.CreateCells(dataGridView2);
                            newRow.Cells[0].Value = row.Cells[0].Value;
                            newRow.Cells[1].Value = row.Cells[1].Value;

                            newRow.Cells[2].Value = row.Cells[2].Value;
                            newRow.Cells[3].Value = row.Cells[3].Value;
                            newRow.Cells[4].Value = DateTime.Today.ToString();
                            dataGridView2.Rows.Add(newRow);
                        }
                    }
                }
            }       //        string emp_qry = "SELECT employee.emp_no, employee.full_name, designation.designation FROM employee INNER JOIN designation ON employee.designation_id = designation.desig_id WHERE employee.supervisor='" + leaderEMP_No + "';";

            //        //dataGridView2.Rows.Clear();
            //        con.Close();
            //        con.Open();
            //        MySqlCommand cmd = new MySqlCommand(emp_qry, con);
            //        MySqlDataReader dr = cmd.ExecuteReader();


            //        if (dr.HasRows)
            //        {
            //            while (dr.Read())
            //            {
            //                DataGridViewRow newRow = new DataGridViewRow();

            //                newRow.CreateCells(dataGridView2);
            //                newRow.Cells[0].Value = dr["emp_no"].ToString(); ;
            //                newRow.Cells[1].Value = dr["full_name"].ToString();

            //                newRow.Cells[2].Value = "Production Department";
            //                newRow.Cells[3].Value = dr["designation"].ToString();
            //                //newRow.Cells[4].Value = true;

            //                dataGridView2.Rows.Add(newRow);



            //            }

            //            dr.Close();
            //            con.Close();
            //        }
            //        dr.Close();
            //        con.Close();
            //    }

            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);    


        }
        private void editButon2_Click(object sender, EventArgs e)
        {
            if (0 < dataGridView1.RowCount)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string emp_no = row.Cells[0].Value.ToString();
                    DataGridViewCell cell = dataGridView1.Rows[row.Index].Cells[column.Index];

                    if (row.Cells[column.Index].Value != null && row.Cells[column.Index].Value is bool)
                    {
                        bool isCheck = (bool)row.Cells[column.Index].Value;
                        Console.WriteLine($"emp_no: {emp_no}, isCheck: {isCheck}");
                        if (isCheck)
                        {

                            if (isCheck.ToString() == "True")
                            {
                                string supervisorEMP_No = comboBox1.SelectedValue.ToString();
                                string sql = "UPDATE employee SET supervisor ='" + supervisorEMP_No + "',add_sup_date='" + DateTime.Today + "' WHERE emp_no ='" + emp_no + "'";
                                con.Open();
                                MySqlCommand cmd = new MySqlCommand(sql, con);
                                cmd.ExecuteNonQuery();
                                con.Close();

                                textBox1.Text = supervisorEMP_No;
                            }
                        }

                        Console.WriteLine($"emp_no: {emp_no}, isCheck: {isCheck}");

                    }
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SupervisorSelect();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) // Assuming 4 is the checkbox column index
            {
                bool isCheck = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                Console.WriteLine($"emp_no:ff, isCheck: {isCheck}");
            }
        }


        //public void SendEmail(string _recipientEmail, string senderPassword, string smtpServer, int smtpPort, DataGridView dataGrid)
        //{
        //    string senderEmail = "employeeperformanceevaluations@gmail.com";
        //    using (SmtpClient smtpClient = new SmtpClient(smtpServer))
        //    {
        //        smtpClient.Port = smtpPort;
        //        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        //        smtpClient.EnableSsl = true;

        //        foreach (DataGridViewRow row in dataGrid.Rows)
        //        {
        //            if (!row.IsNewRow)
        //            {
        //                string recipientEmail = _recipientEmail;

        //                if (!string.IsNullOrEmpty(recipientEmail))
        //                {
        //                    try
        //                    {
        //                        using (MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail))
        //                        {
        //                            // Get values from the current row
        //                            string empNo = Convert.ToString(comboBox1.Text);
        //                            string section = Convert.ToString(row.Cells[2].Value);

        //                            // Concatenate multiple full names into the body
        //                            string fullNames = GetFullNamesFromRow(row);

        //                            // Customize subject and body using employee information
        //                            mailMessage.Subject = $"Subject for Employee {empNo}";
        //                            mailMessage.Body = $"Dear Sir/Madam,\r\nThe Monthly employee performance evaluation will be conducted from {DateTime.Now.ToString("MMMM-yyyy")} to {DateTime.Now.AddMonths(1).ToString("MMMM-yyyy")} During that period , you are assigned to evaluate the following employees through supervision.\n  {section},\n\n{fullNames}";

        //                            smtpClient.Send(mailMessage);

        //                            // Optionally, you can add a delay between sending emails to avoid rate limits or restrictions.
        //                            System.Threading.Thread.Sleep(1000); // 1-second delay
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // Handle the exception or log it
        //                        Console.WriteLine($"Error sending email to {recipientEmail}: {ex.Message}");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}



        private string GetFullNamesFromRow(DataGridViewRow row)
        {
            // Get the value from the "fullName" column and concatenate multiple names
            string empNo = row.Cells[0].Value.ToString();
            string fullNames = string.Join(", ", row.Cells[1].Value.ToString().Split(',').Select(name => name.Trim()));
            return fullNames;
        }
        public void SendEmail(string _recipientEmail, string senderPassword, string smtpServer, int smtpPort, DataGridView dataGrid)
        {
            string senderEmail = "employeeperformanceevaluations@gmail.com";
            using (SmtpClient smtpClient = new SmtpClient(smtpServer))
            {
                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                try
                {
                    using (MailMessage mailMessage = new MailMessage(senderEmail, _recipientEmail))
                    {
                        StringBuilder bodyBuilder = new StringBuilder();

                        // Iterate through rows to concatenate employee information
                        foreach (DataGridViewRow row in dataGrid.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string empNo = Convert.ToString(row.Cells[0].Value);
                                string fullNames = GetFullNamesFromRow(row);

                                // Append employee information to the email body
                                bodyBuilder.AppendLine($"Employee Number: {empNo}, Full Names: {fullNames}");
                            }
                        }

                        // Customize subject and body using concatenated employee information
                        mailMessage.Subject = "Subject for Employee Details";
                        mailMessage.Body = $"Dear Sir/Madam,\r\nThe Monthly employee performance evaluation will be conducted from {DateTime.Now.ToString("MMMM-yyyy")} to {DateTime.Now.AddMonths(1).ToString("MMMM-yyyy")} During that period, you are assigned to evaluate the following employees through supervision.\n\n{bodyBuilder.ToString()}";

                        smtpClient.Send(mailMessage);

                        // Optionally, you can add a delay between sending emails to avoid rate limits or restrictions.
                        System.Threading.Thread.Sleep(1000); // 1-second delay
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception or log it
                    Console.WriteLine($"Error sending email to {_recipientEmail}: {ex.Message}");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    string email = "";

                    string employee_id = textBox1.Text;
                    con.Close();
                    string sql = "SELECT email FROM admins WHERE employee_id='" + textBox1.Text + "' ";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataReader dr = cmd.ExecuteReader();


                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {

                            email = dr["email"].ToString();


                        }

                        string email2 = "employeeperformanceevaluations@gmail.com";
                        string senderPassword = "mczs toer eyjh dsdz ";
                        // send_email(email, dataGridView2,"smtp.gmail.com",587);
                        SendEmail(email, senderPassword, "smtp.gmail.com", 587, dataGridView1);
                    }
                }
                else
                {
                    MessageBox.Show("check again");
                }





            }
        }
    }
}