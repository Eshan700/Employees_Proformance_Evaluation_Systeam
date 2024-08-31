using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace new_payroll
{
    public partial class login_part : Form
    {


        MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd;
        MySqlDataAdapter da;

        public login_part()
        {
            InitializeComponent();

            con = database.Db.ConnectDB();


        }
        //Notification mesege box

        public void Alert(string msg, Custom_Notification.enumType type)
        {
            Custom_Notification frm = new Custom_Notification();
            frm.showAlert(msg, type);
        }
        //

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
       );

        private void login_part_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Silver, ButtonBorderStyle.Solid);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(20, 20, Width, Height, 20, 20));

            label1.Focus();
        }

        private void login_part_MouseHover(object sender, EventArgs e)
        {

        }

        private void eshanButton1_Click(object sender, EventArgs e)
        {
            
            String user_name = textBox_two1.Texts;
            
            String pass = eshanTextBox1.Texts;



            cmd = new MySqlCommand("select username,password,desig_id,employee_id from admins where username='" + user_name+ "'and password='" +pass+ "'"  , con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["username"].ToString() == user_name && dt.Rows[i]["password"].ToString()==pass)
                    {
                        string employee_id = dt.Rows[i]["employee_id"].ToString();
                        Main ma = new Main(dt.Rows[i]["desig_id"].ToString(), employee_id);
                        ma.Show();
                        this.ParentForm.Hide();
                        this.Alert("Hi '"+user_name+"' ", Custom_Notification.enumType.success);
                    }

                    else if (dt.Rows[i]["username"].ToString() == user_name && dt.Rows[i]["password"].ToString() == pass)
                    {
                        Main ma = new Main();
                        ma.Show();
                        this.ParentForm.Hide();
                        this.Alert("Hi '" + user_name + "' ", Custom_Notification.enumType.success);
                    }


                }
            }
            else
            {
                
                this.Alert("Check Username Or Password", Custom_Notification.enumType.error);
            }
        


        }

        private void eshanButton1__Click(object sender, EventArgs e)
        {
        
            
        }

  

        private void eshanTextBox2_Enter(object sender, EventArgs e)
        {
            
           
            

        }

       

        private void login_part_Load(object sender, EventArgs e)
        {
            
        }

     

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

     

        private void eshanTextBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void eshanTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void eshanTextBox2__TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox_two1_Load(object sender, EventArgs e)
        {

        }
    }
}
   