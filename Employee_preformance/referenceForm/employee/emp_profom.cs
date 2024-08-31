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
    public partial class emp_profom : Form
    {
        string emp_no = "";
        public emp_profom()
        {
            InitializeComponent();
        }
        public emp_profom(string Lemp_no)
        {
            InitializeComponent();
            emp_no = Lemp_no;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void emp_profom_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {






            //if (txt_production.Text == "" || txt_production.Text.Any(char.IsLetter))
            //{
            //    this.Alert("production is not valid  ", Custom_Notification.enumType.warning);

            //}
            //else if (txt_quality.Text == "" || txt_quality.Text.Any(char.IsLetter))
            //{
            //    this.Alert("quality is not valid  ", Custom_Notification.enumType.warning);

            //}
            //else if (txt_defects.Text == "" || txt_defects.Text.Any(char.IsLetter))
            //{
            //    this.Alert("defects is not valid  ", Custom_Notification.enumType.warning);

            //}
            //else if (txt_complete.Text == "" || txt_complete.Text.Any(char.IsLetter))
            //{
            //    this.Alert("defects is not valid  ", Custom_Notification.enumType.warning);

            //}
            //else if (txt_incomplete.Text == "" || txt_incomplete.Text.Any(char.IsLetter))
            //{
            //    this.Alert("defects is not valid  ", Custom_Notification.enumType.warning);

            //}
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (txt_production.Text == "" || txt_production.Text.Any(char.IsLetter))
        //    {
        //        this.Alert("production is not valid  ", Custom_Notification.enumType.warning);

        //    }
        //    else if (txt_quality.Text == "" || txt_quality.Text.Any(char.IsLetter))
        //    {
        //        this.Alert("quality is not valid  ", Custom_Notification.enumType.warning);

        //    }
        //    else if (txt_defects.Text == "" || txt_defects.Text.Any(char.IsLetter))
        //    {
        //        this.Alert("defects is not valid  ", Custom_Notification.enumType.warning);

        //    }
        //    else if (txt_complete.Text == "" || txt_complete.Text.Any(char.IsLetter))
        //    {
        //        this.Alert("defects is not valid  ", Custom_Notification.enumType.warning);

        //    }
        //    else if (txt_incomplete.Text == "" || txt_incomplete.Text.Any(char.IsLetter))
        //    {
        //        this.Alert("defects is not valid  ", Custom_Notification.enumType.warning);

        //    }
        //    else
        //    {
        //        string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        //        string production = txt_production.Text;
        //        string quality = txt_quality.Text;
        //        string defects = txt_defects.Text;
        //        string complete = txt_complete.Text;
        //        string incomplete = txt_incomplete.Text;

        //        string insert_qry = "INSERT INTO emp_per_evaluation(emp_no,total_production,number_of_quality,number_of_defects,complete_production,incomplete_production,date) VALUES('" + lab_emp_no.Text + "','" + production + "','" + quality + "','" + defects + "','" + complete + "','" + incomplete + "','" + date + "')";
        //        MySqlConnection conn = database.Db.ConnectDB();
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand(insert_qry, conn);
        //        cmd.ExecuteNonQuery();
        //        this.Alert("Succesfull  ", Custom_Notification.enumType.success);
        //        clear();
        //        conn.Close();

        //    }

        //}

    }
}
