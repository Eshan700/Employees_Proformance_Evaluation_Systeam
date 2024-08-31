
namespace new_payroll
{
    partial class login_part
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_two1 = new textBoxControler.textBox_two();
            this.eshanButton1 = new textBoxControler.eshanButton();
            this.eshanTextBox1 = new textBoxControler.eshanTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(227, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "Login";
            // 
            // textBox_two1
            // 
            this.textBox_two1.BackColor = System.Drawing.Color.White;
            this.textBox_two1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox_two1.BorderColor = System.Drawing.Color.Black;
            this.textBox_two1.BorderFocusColor = System.Drawing.Color.Black;
            this.textBox_two1.BorderRadius = 20;
            this.textBox_two1.BorderSize = 2;
            this.textBox_two1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.textBox_two1.Location = new System.Drawing.Point(97, 156);
            this.textBox_two1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_two1.Multiline = false;
            this.textBox_two1.Name = "textBox_two1";
            this.textBox_two1.Padding = new System.Windows.Forms.Padding(9);
            this.textBox_two1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBox_two1.PlaceholderText = "Username";
            this.textBox_two1.Size = new System.Drawing.Size(385, 51);
            this.textBox_two1.TabIndex = 9;
            this.textBox_two1.Texts = "";
            this.textBox_two1.UnderlinedStyle = false;
            this.textBox_two1.Load += new System.EventHandler(this.textBox_two1_Load);
            // 
            // eshanButton1
            // 
            this.eshanButton1.BackColor = System.Drawing.Color.Teal;
            this.eshanButton1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.eshanButton1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.eshanButton1.BorderRadius = 30;
            this.eshanButton1.BorderSize = 2;
            this.eshanButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eshanButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eshanButton1.ForeColor = System.Drawing.Color.White;
            this.eshanButton1.Location = new System.Drawing.Point(189, 364);
            this.eshanButton1.Margin = new System.Windows.Forms.Padding(4);
            this.eshanButton1.Name = "eshanButton1";
            this.eshanButton1.Padding = new System.Windows.Forms.Padding(9);
            this.eshanButton1.Size = new System.Drawing.Size(189, 65);
            this.eshanButton1.TabIndex = 7;
            this.eshanButton1.Texts = "Login";
            this.eshanButton1.UnderlinedStyle = false;
            this.eshanButton1._Click += new System.EventHandler(this.eshanButton1__Click);
            this.eshanButton1.Click += new System.EventHandler(this.eshanButton1_Click);
            // 
            // eshanTextBox1
            // 
            this.eshanTextBox1.BackColor = System.Drawing.Color.White;
            this.eshanTextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.eshanTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.eshanTextBox1.BorderFocusColor = System.Drawing.Color.Black;
            this.eshanTextBox1.BorderRadius = 20;
            this.eshanTextBox1.BorderSize = 2;
            this.eshanTextBox1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eshanTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.eshanTextBox1.Location = new System.Drawing.Point(97, 246);
            this.eshanTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.eshanTextBox1.Multiline = false;
            this.eshanTextBox1.Name = "eshanTextBox1";
            this.eshanTextBox1.Padding = new System.Windows.Forms.Padding(9);
            this.eshanTextBox1.PasswordChar = true;
            this.eshanTextBox1.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.eshanTextBox1.PlaceholderText = "Password";
            this.eshanTextBox1.Size = new System.Drawing.Size(385, 51);
            this.eshanTextBox1.TabIndex = 6;
            this.eshanTextBox1.Texts = "";
            this.eshanTextBox1.UnderlinedStyle = false;
            this.eshanTextBox1.Enter += new System.EventHandler(this.eshanTextBox1_Enter);
            // 
            // login_part
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(544, 487);
            this.Controls.Add(this.textBox_two1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eshanButton1);
            this.Controls.Add(this.eshanTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "login_part";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "login_part";
            this.Load += new System.EventHandler(this.login_part_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.login_part_Paint);
            this.MouseHover += new System.EventHandler(this.login_part_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private textBoxControler.eshanButton eshanButton1;
        private textBoxControler.eshanTextBox eshanTextBox1;
        private System.Windows.Forms.Label label1;
        private textBoxControler.textBox_two textBox_two1;
    }
}