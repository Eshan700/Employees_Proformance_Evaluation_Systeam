﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace new_payroll
{
    public partial class Custom_Notification : Form
    {
        public Custom_Notification()
        {
            InitializeComponent();
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enumType
        {
            success,
            warning,
            error,
            info
        }

        private Custom_Notification.enmAction action;
        private int x, y;
        public void showAlert(string msg, enumType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert " + i.ToString();
                Custom_Notification frm = (Custom_Notification)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enumType.success:
                    
                    this.BackColor = Color.SeaGreen;
                    this.pictureBox1.Image = new_payroll.Properties.Resources.success;
                    break;

                case enumType.error:
                    
                    this.BackColor = Color.DarkRed;
                    this.pictureBox1.Image = new_payroll.Properties.Resources.error;
                    break;

                case enumType.info:
                    
                    this.BackColor = Color.RoyalBlue;
                    this.pictureBox1.Image = new_payroll.Properties.Resources.info;
                    break;

                case enumType.warning:
                    
                    this.BackColor = Color.DarkOrange;
                    this.pictureBox1.Image = new_payroll.Properties.Resources.warning;
                    break;
            }


            this.label1.Text = msg;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }

       
        
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;

                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;

                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;

                case enmAction.close:

                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;

                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;

            }
        }
    }
}
