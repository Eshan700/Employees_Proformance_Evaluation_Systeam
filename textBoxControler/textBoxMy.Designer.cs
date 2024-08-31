
using System.Windows.Forms;

namespace textBoxControler
{
    partial class textBoxMy
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AutoScaleMode AutoScaleMode { get; private set; }

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // textBoxMy
            // 
            this.Enter += new System.EventHandler(this.textBoxMy_Enter_1);
            this.Leave += new System.EventHandler(this.textBoxMy_Leave_1);
            this.MouseHover += new System.EventHandler(this.textBoxMy_MouseHover);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
