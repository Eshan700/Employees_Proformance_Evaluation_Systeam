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
    public partial class evaaluation_main : UserControl
    {
        public evaaluation_main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Efficiency Efficiency= new Efficiency();
            Efficiency.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quality productivity = new Quality();
            productivity.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            productivity productivity = new productivity();
            productivity.Show();
        }
    }
}
