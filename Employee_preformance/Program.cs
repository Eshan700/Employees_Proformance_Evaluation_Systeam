using new_payroll.referenceForm.employee;
using new_payroll.referenceForm.temperory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_payroll
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
           Application.Run(new loding());
           //Application.Run(new Main());
          // Application.Run(new login_form());
           //Application.Run(new decision_maker());
            

        }
    }
}
