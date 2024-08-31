using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;

namespace new_payroll.referenceForm.evaluation
{
    public partial class Efficiency : Form
    {
        MySqlConnection conn;
        public Efficiency()
        {
            InitializeComponent();
            conn = database.Db.ConnectDB();
            
        }
        public void Alert(string msg, Custom_Notification.enumType type)
        {
            Custom_Notification frm = new Custom_Notification();
            frm.showAlert(msg, type);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count==2)
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == 0)
                    {
                        if (row.Cells[0] == null || row.Cells[0].Value == null)
                        {
                            this.Alert("Emp_no is not valid  ", Custom_Notification.enumType.warning);

                        }
                        else if (row.Cells[1] == null || row.Cells[1].Value == null)
                        {
                            this.Alert("No.Target is not valid  ", Custom_Notification.enumType.warning);

                        }
                        else if (row.Cells[2] == null || row.Cells[2].Value == null)
                        {
                            this.Alert("No.Taget Achieve is not valid  ", Custom_Notification.enumType.warning);

                        }
                        else if (comboBox1.Text == "")
                        {

                            this.Alert("Please select a month  ", Custom_Notification.enumType.warning);

                        } else if (comboBox5.Text == "")
                        {

                            this.Alert("Please select a Year  ", Custom_Notification.enumType.warning);

                        }
                        else
                        {
                            string emp_no = row.Cells[0].Value.ToString();
                            double NoTarget = Convert.ToDouble(row.Cells[1].Value.ToString());
                            double NoTagetAchieve = Convert.ToDouble(row.Cells[2].Value.ToString());
                            string month = comboBox1.Text;
                            string year = comboBox5.Text;
                            double efficiencyD = (NoTagetAchieve / NoTarget) * 100;
                            string efficiency = efficiencyD.ToString("0.00") + "%";
                            row.Cells[3].Value = efficiency;
                           int mark= marsk(Convert.ToDouble(efficiencyD.ToString()));

                            string insert_qry = "INSERT INTO efficiency(emp_no,no_target,no_taget_achieve,efficiency,month,mark,year) VALUES('" + emp_no + "','" + NoTarget + "','" + NoTagetAchieve + "','" + efficiency + "','" + month + "','"+ mark + "','"+ year + "')";
                             conn.Close();
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
        }


        public void clear() {
            dataGridView1.Rows.Clear();
            dataGridView1.ReadOnly = false;

        }
        private void Efficiency_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
            this.Alert("Succesfull Clear  ", Custom_Notification.enumType.success);
        }
        public int marsk(double efficiencyCount)
        {
            int mark = 0;
            if (efficiencyCount < 100 && efficiencyCount > 79)
            {
                mark = 5;
            }
            else if (efficiencyCount < 80 && efficiencyCount > 59)
            {
                mark = 4;
            }
            else if (efficiencyCount < 60 && efficiencyCount > 39)
            {
                mark = 3;
            }
            else if (efficiencyCount < 40 && efficiencyCount > 19)
            {
                mark = 2;
            }
            else if (efficiencyCount < 20 && efficiencyCount > 0)
            {
                mark = 1;
            }
            return mark;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox5.Text!="")
            {
                sho();
                dataGridView1.ReadOnly = true;
               
            }
            else
            {
                this.Alert("select a Date ", Custom_Notification.enumType.warning);
            }
            
        }

        public void sho()
        {
            conn.Close();
            dataGridView1.Rows.Clear();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT emp_no,no_target,no_taget_achieve,efficiency FROM performencedb.efficiency where month='"+ comboBox1.Text + "' and year='"+ comboBox5.Text+ "'", conn);
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
                    newRow.Cells[4].Value = marsk(Convert.ToDouble(dr["efficiency"].ToString().Substring(0, dr["efficiency"].ToString().Length - 1))).ToString();
                    dataGridView1.Rows.Add(newRow);

                   
                }
                this.Alert("Succesfull  ", Custom_Notification.enumType.success);

                conn.Close();
            }
            else
            {
                this.Alert("This month has not Rows  ", Custom_Notification.enumType.success);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
