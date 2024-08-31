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
using System.Windows.Forms;

namespace new_payroll.referenceForm.evaluation
{
    public partial class Quality : Form
    {
        MySqlConnection conn;
        public Quality()
        {
            InitializeComponent();
            conn = database.Db.ConnectDB();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Alert(string msg, Custom_Notification.enumType type)
        {
            Custom_Notification frm = new Custom_Notification();
            frm.showAlert(msg, type);
        }
        public void clear()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ReadOnly = false;
           

            }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 2)
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if(row.Index == 0){
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
                            this.Alert("No. Target Achieve Products is not valid  ", Custom_Notification.enumType.warning);

                        }
                        else if (row.Cells[3] == null || row.Cells[3].Value == null)
                        {
                            this.Alert("No.Defect Products is not valid  ", Custom_Notification.enumType.warning);

                        }
                        else if (row.Cells[4] == null || row.Cells[4].Value == null)
                        {
                            this.Alert("No. Quality Products is not valid  ", Custom_Notification.enumType.warning);

                        }
                        //else if (row.Cells[3] == null || row.Cells[3].Value == null)
                        //{
                        //    this.Alert("quality is not valid  ", Custom_Notification.enumType.warning);

                        //}
                        else if (comboBox1.Text == "")
                        {

                            this.Alert("Please select a month  ", Custom_Notification.enumType.warning);

                        } else if (comboBox5.Text == "")
                        {

                            this.Alert("Please select a year  ", Custom_Notification.enumType.warning);

                        }
                        else
                        {
                            string emp_no = row.Cells[0].Value.ToString();
                            double NoTarget = Convert.ToDouble(row.Cells[1].Value.ToString());
                            double no_target_achieve = Convert.ToDouble(row.Cells[2].Value.ToString());
                            double defect_products = Convert.ToDouble(row.Cells[3].Value.ToString());
                            double quality = Convert.ToDouble(row.Cells[4].Value.ToString());
                            double productivity = ((no_target_achieve - defect_products) / NoTarget) * 100;
                            string month = comboBox1.Text;
                            string year = comboBox5.Text;
                            int mark = marsk(productivity);
                            string insert_qry = "INSERT INTO output_quality(Emp_no,no_target,no_target_achieve,defect_products,quality,productivity,month,mark,year) VALUES('" + emp_no + "','" + NoTarget + "','"+ no_target_achieve + "','"+ defect_products + "','" + quality + "','"+ productivity + "','" + month + "','"+ mark + "','"+ year + "')";
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

        private void Quality_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
        public int marsk(double productivityCount)
        {
            int mark = 0;
            if (productivityCount<100 && productivityCount > 79)
            {
                mark = 5;
            }else if(productivityCount< 80 && productivityCount > 59)
            {
                mark = 4;
            }
            else if(productivityCount<60 && productivityCount> 39)
            {
                mark = 3;
            }
            else if (productivityCount< 40 && productivityCount > 19)
            {
                mark = 2;
            }
            else if (productivityCount < 20 && productivityCount> 0)
            {
                mark = 1;
            }
            return mark;
        }

        public void sho()
        {
            conn.Close();
            dataGridView1.Rows.Clear();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Emp_no,no_target,no_target_achieve,defect_products,quality,productivity From output_quality where  month='" + comboBox1.Text + "'and year='"+ comboBox5.Text+ "'", conn);
            MySqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = dr["Emp_no"].ToString(); ;
                    newRow.Cells[1].Value = dr["no_target"].ToString();
                    newRow.Cells[2].Value = dr["no_target_achieve"].ToString();
                    newRow.Cells[3].Value = dr["defect_products"].ToString();
                    newRow.Cells[4].Value = dr["quality"].ToString();
                    
                    double productivityCount = (Convert.ToDouble(dr["no_target_achieve"].ToString()) - Convert.ToDouble(dr["defect_products"].ToString())) / Convert.ToDouble(dr["no_target"].ToString()) * 100;
                    string productivity = productivityCount.ToString("0.00") + "%";
                    newRow.Cells[5].Value = productivity;
                    newRow.Cells[6].Value = marsk(productivityCount).ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                sho();
                dataGridView1.ReadOnly = true;

            }
            else
            {
                this.Alert("select a Date ", Custom_Notification.enumType.warning);
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
