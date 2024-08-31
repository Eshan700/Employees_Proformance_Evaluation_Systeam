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

namespace new_payroll.referenceForm.evaluation
{
    public partial class productivity : Form
    {
        MySqlConnection conn;
        public productivity()
        {
            InitializeComponent();
            conn = database.Db.ConnectDB();
        }
       
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                sho();
            }
            else
            {
                this.Alert("Please select a month  ", Custom_Notification.enumType.warning);
            }
            
        }

        public void clear()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ReadOnly = false;

        }

        public void Alert(string msg, Custom_Notification.enumType type)
        {
            Custom_Notification frm = new Custom_Notification();
            frm.showAlert(msg, type);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 2)
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (row.Cells[0] == null || row.Cells[0].Value == null)
                    {
                        this.Alert("Emp_no is not valid  ", Custom_Notification.enumType.warning);

                    }
                    else if (row.Cells[1] == null || row.Cells[1].Value == null)
                    {
                        this.Alert("working_days is not valid  ", Custom_Notification.enumType.warning);

                    }
                    else if (row.Cells[2] == null || row.Cells[2].Value == null)
                    {
                        this.Alert("absentisnt Achieve is not valid  ", Custom_Notification.enumType.warning);

                    }
                    else if (row.Cells[3] == null || row.Cells[3].Value == null)
                    {
                        this.Alert("attendance Achieve is not valid  ", Custom_Notification.enumType.warning);

                    }
                    else if (row.Cells[4] == null || row.Cells[4].Value == null)
                    {
                        this.Alert("productivity Achieve is not valid  ", Custom_Notification.enumType.warning);

                    }
                    else if (comboBox1.Text == "")
                    {

                        this.Alert("Please select a month  ", Custom_Notification.enumType.warning);

                    }

                    else
                    {
                        string emp_no = row.Cells[0].Value.ToString();
                        string working_days = row.Cells[1].Value.ToString();
                        string absentisnt = row.Cells[2].Value.ToString();
                        string attendance = row.Cells[3].Value.ToString();
                        string productivity = row.Cells[4].Value.ToString();
                        string month = comboBox1.Text;
                        string insert_qry = "INSERT INTO output_quality(emp_no,working_days,absentisnt,attendance,productivity,month) VALUES('" + emp_no + "','" + working_days + "','" + absentisnt + "','" + attendance + "','"+ productivity + "','" + month + "')";
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(insert_qry, conn);
                        cmd.ExecuteNonQuery();


                        conn.Close();
                        this.Alert("Succesfull  ", Custom_Notification.enumType.success);
                        clear();
                        // Access row data using 'row' variable
                    }
                }



            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void productivity_Load(object sender, EventArgs e)
        {

        }

        public void sho()
        {
            conn.Close();
            dataGridView1.Rows.Clear();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Emp_no,no_target,no_taget_achieve,no_achieve FROM performencedb.output_quality where month='" + comboBox1.Text + "'", conn);
            MySqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = dr["emp_no"].ToString(); ;
                    newRow.Cells[1].Value = dr["no_target"].ToString();
                    newRow.Cells[2].Value = dr["no_taget_achieve"].ToString();
                    newRow.Cells[3].Value = dr["efficiency"].ToString();

                    dataGridView1.Rows.Add(newRow);

                    this.Alert("Succesfull  ", Custom_Notification.enumType.success);
                }


                conn.Close();
            }
            else
            {
                this.Alert("This month has not Rows  ", Custom_Notification.enumType.success);
            }

        }
    }
}
