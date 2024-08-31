using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_payroll.referenceForm.temperory
{
    public partial class decision_maker : Form
    {
        public decision_maker()
        {
            InitializeComponent();
            fillChart();
        }

        private void fillChart()
        {
            //AddXY value in chart1 in series named as Salary  
            chart1.Series["Quality Of Work"].Points.AddXY("", "80");
            chart1.Series["Productivity"].Points.AddXY("", "65");
            chart1.Series["Teamwork"].Points.AddXY("", "75");
            chart1.Series["Professionalism"].Points.AddXY("", "78");
            //chart title  
            chart1.Titles.Add("Performence");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
