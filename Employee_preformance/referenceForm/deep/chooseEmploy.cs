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
    public partial class chooseEmploy : UserControl
    {
        public chooseEmploy()
        {
            InitializeComponent();
        }
        private void OpenChildForm(UserControl childForm)
        {

            childForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }
        private void button3_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new deepDesignation());
            //button1.SendToBack();
            OpenChildForm(new lineLeaderEmployeeAsing());
            button3.SendToBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new lineLeaderEmployeeAsing());
            ////button1.SendToBack();
            //button3.SendToBack();
        }
    }
}
