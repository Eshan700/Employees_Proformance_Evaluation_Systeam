using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
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
    public partial class dataAdmin_Employe_cheng : Form
    {
        public dataAdmin_Employe_cheng()
        {
            InitializeComponent();
        }
        public void Alert(string msg, Custom_Notification.enumType type)
        {
            Custom_Notification frm = new Custom_Notification();
            frm.showAlert(msg, type);
        }

        private void clear()
        {
            txt_production.Text = "";
            txt_quality.Text = "";
            txt_defects.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_production.Text == "" || txt_production.Text.Any(char.IsLetter))
            {
                this.Alert("production is not valid  ", Custom_Notification.enumType.warning);

            }
            else if (txt_quality.Text == "" || txt_quality.Text.Any(char.IsLetter))
            {
                this.Alert("quality is not valid  ", Custom_Notification.enumType.warning);

            }
            else if (txt_defects.Text == "" || txt_defects.Text.Any(char.IsLetter))
            {
                this.Alert("defects is not valid  ", Custom_Notification.enumType.warning);

            }
            else if (txt_complete.Text == "" || txt_complete.Text.Any(char.IsLetter))
            {
                this.Alert("defects is not valid  ", Custom_Notification.enumType.warning);

            }
            else if (txt_incomplete.Text == "" || txt_incomplete.Text.Any(char.IsLetter))
            {
                this.Alert("defects is not valid  ", Custom_Notification.enumType.warning);

            }
            else
            {
                string date=dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string production = txt_production.Text;
                string quality = txt_quality.Text;
                string defects = txt_defects.Text;
                string complete = txt_complete.Text;
                string incomplete = txt_incomplete.Text;

                string insert_qry = "INSERT INTO emp_per_evaluation(emp_no,total_production,number_of_quality,number_of_defects,complete_production,incomplete_production,date) VALUES('" + lab_emp_no.Text + "','" + production + "','" + quality + "','" + defects + "','" + complete + "','"+incomplete+"','"+date+"')";
                MySqlConnection conn = database.Db.ConnectDB();
                conn.Open();    
                MySqlCommand cmd = new MySqlCommand(insert_qry, conn);
                cmd.ExecuteNonQuery();
                this.Alert("Succesfull  ", Custom_Notification.enumType.success);
                clear();
                conn.Close();

            }
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
