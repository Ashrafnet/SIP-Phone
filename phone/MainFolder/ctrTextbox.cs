using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Softphone.MainFolder
{
    public class ctrTextbox : TextBox
    {
        private string _BackText;
        public string BackText
        {
            get { return _BackText; }
            set 
            {
                _BackText = value;
                if (Text.Length == 0)
                {
                    ForeColor = Color.Silver;
                    Text = BackText;
                }
            }
        }
        public ctrTextbox()
        {

            
            this.Enter += new EventHandler(ctrTextbox_Enter);
            this.Leave += new EventHandler(ctrTextbox_Leave);
            this.TextChanged += new EventHandler(ctrTextbox_TextChanged);
            ForeColor = Color.Silver;
            
        }

        void ctrTextbox_TextChanged(object sender, EventArgs e)
        {
            if (Text.Length > 0 && Text != BackText && ForeColor == Color.Silver  )
                ForeColor = Color.Black;
        }
       
        void ctrTextbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Text.Length == 0)
                {
                    ForeColor = Color.Silver;
                    Text = BackText;
                }
            }
            catch { }
        }

        void ctrTextbox_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Text==BackText && ForeColor == Color.Silver)
                {
                    ForeColor = Color.Black;
                    Text = "";
                }
            }
            catch { }
        }

   
    }
}
