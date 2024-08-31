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

namespace new_payroll.referenceForm.deep
{
    public partial class lineLeaderEmployeeAsing : UserControl
    {
        public lineLeaderEmployeeAsing()
        {
            InitializeComponent();
            con = database.Db.ConnectDB();
            Evaluator_load();
        }
        MySqlConnection con;
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
            String emp_qry = "SELECT employee.emp_no, employee.full_name, designation.designation FROM employee INNER JOIN designation ON employee.designation_id = designation.desig_id WHERE employee.designation_id != '33';";

           
            dataGridView1.Rows.Clear();
            con.Close();
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

                    newRow.Cells[2].Value = "Production Department";
                    newRow.Cells[3].Value = dr["designation"].ToString();
                    dataGridView1.Rows.Add(newRow);


                }

                dr.Close();
                con.Close();
            }
            dr.Close();
            con.Close();

        }

        private void editButon2_Click(object sender, EventArgs e)
        {
            if (0 < dataGridView1.RowCount)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string emp_no = row.Cells[0].Value.ToString();
                    object isCheck = row.Cells[4].Value;
                    if (isCheck != null)
                    {
                        if (isCheck.ToString() == "True")
                        {
                            string leaderEMP_No = comboBox1.SelectedValue.ToString();
                            string sql = "UPDATE employee SET line_leader ='"+ leaderEMP_No + "' WHERE emp_no ='"+ emp_no + "'";
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            textBox1.Text = leaderEMP_No;
                        }
                    }
                   
                }
               
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        public void lineLeaderSelect() {

            object leaderEMP_No = textBox1.Text;

            if (leaderEMP_No != null)
            {
                string emp_qry = "SELECT employee.emp_no, employee.full_name, designation.designation FROM employee INNER JOIN designation ON employee.designation_id = designation.desig_id WHERE employee.line_leader='" + leaderEMP_No + "';";

                dataGridView2.Rows.Clear();
                con.Close();
                con.Open();
                MySqlCommand cmd = new MySqlCommand(emp_qry, con);
                MySqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DataGridViewRow newRow = new DataGridViewRow();

                        newRow.CreateCells(dataGridView2);
                        newRow.Cells[0].Value = dr["emp_no"].ToString(); ;
                        newRow.Cells[1].Value = dr["full_name"].ToString();

                        newRow.Cells[2].Value = "Production Department";
                        newRow.Cells[3].Value = dr["designation"].ToString();
                        dataGridView2.Rows.Add(newRow);



                    }

                    dr.Close();
                    con.Close();
                }
                dr.Close();
                con.Close();
            }
        }

        //private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    object leaderEMP_No = comboBox2.SelectedValue.ToString();

        //    if (leaderEMP_No)
        //    {
        //        string emp_qry = "SELECT employee.emp_no, employee.full_name, designation.designation FROM employee INNER JOIN designation ON employee.designation_id = designation.desig_id WHERE employee.line_leader='" + leaderEMP_No + "';";

        //        dataGridView2.Rows.Clear();
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
        //                dataGridView2.Rows.Add(newRow);



        //            }

        //            dr.Close();
        //            con.Close();
        //        }
        //        dr.Close();
        //        con.Close();
        //    }
        //    lineLeaderSelect();

        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sho();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lineLeaderSelect();
        }
    }
}
