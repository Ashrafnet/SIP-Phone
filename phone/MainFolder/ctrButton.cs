using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Softphone.Properties;

namespace Softphone
{
    public class ctrButton : PictureBox
    {
        private Image _Image_Normal;
        private Image _Image_MouseIn;
        private Image _Image_MouseClick;
        
        
        public ctrButton()
        {
            this.EnabledChanged += new EventHandler(ctrButton_EnabledChanged);
            
        }

        void ctrButton_EnabledChanged(object sender, EventArgs e)
        {
            if(!this.Enabled )
                this.Image = GrayScal(_Image_Normal);
            else
                this.Image =(_Image_Normal);
        }
        private Image GrayScal(Image srcImage)
        {
            try
            {
                byte CompareNo = 110;
                Bitmap x = new Bitmap(srcImage);
                for (int i = 0; i < srcImage.Width ; i++)
                {
                    
                    for (int j = 0; j < srcImage.Height ; j++)
                    {
                       
                            //MessageBox.Show(x.GetPixel(i, j).R.ToString() );
                        if (x.GetPixel(i, j).R >= CompareNo || x.GetPixel(i, j).G >= CompareNo || x.GetPixel(i, j).B >= CompareNo)
                            x.SetPixel(i, j, Color.Gray);
                    }
                }
                return ((Image)x);
            }
            catch
            {
                return srcImage;
            }
        }
       
        public Image Image_Normal
        {
            get
            {
                return _Image_Normal;
            }
            set
            {
                _Image_Normal = value;
                this.Image = value;
                this.Size = this.Size;
            }
        }
        public Image Image_MouseIn
        {
            get
            {
                return _Image_MouseIn;
            }
            set
            {
                _Image_MouseIn = value;

            }
        }
        public Image Image_MouseClick
        {
            get
            {
                return _Image_MouseClick;
            }
            set
            {
                _Image_MouseClick = value;

            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Image = _Image_MouseClick;
            base.OnMouseDown(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.Image = _Image_MouseIn;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.Image = _Image_Normal;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.Image = _Image_MouseIn;
            base.OnMouseUp(e);
        }
         
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
