using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace new_payroll
{
    public partial class loding : Form
    {



        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
       int nLeftRect,
       int nTopRect,
       int RightRect,
       int nBottomRect,
       int nWidthEllipse,
       int nHeightEllipse
       );
        public loding()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            progressBar1.Value = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 2;
            progressBar1.Text = progressBar1.Value.ToString() + "%";

            if (progressBar1.Value == 101)
            {
                timer1.Enabled = false;
                login_form form = new login_form();
                form.Show();
                this.Hide();
            }
        }

        private void loding_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
