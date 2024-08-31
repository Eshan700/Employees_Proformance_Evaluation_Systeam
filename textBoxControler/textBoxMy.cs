



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace textBoxControler
{


    public partial class textBoxMy : TextBox
    {

        private Color _borderColor = Color.Red;
        private Color _onFocusColor = Color.Blue;

        
    
        public textBoxMy()
        {
            InitializeComponent();


            BorderStyle = BorderStyle.None;
            AutoSize = false;

            Controls.Add(new Label
            {
                Height = 3,
                Dock = DockStyle.Bottom,
                BackColor = _borderColor,
                


            });



        }

        
        [Browsable(false)]

        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = value; }

        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set { Controls[0].BackColor = _borderColor; }
        }
        public Color BottomFocusColor
        {
            get { return _onFocusColor; }
            set { _onFocusColor = value; }
        }


     
        private void textBoxMy_Leave(object sender, EventArgs e)
        {
          
        }

        private void textBoxMy_Enter_1(object sender, EventArgs e)
        {
            Controls[0].BackColor = _onFocusColor;
        }

        private void textBoxMy_Leave_1(object sender, EventArgs e)
        {
            Controls[0].BackColor = _borderColor;
        }

        private void textBoxMy_MouseHover(object sender, EventArgs e)
        {

        }
    }

}
