using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Softphone.MainFolder
{
    public enum ItemView { Vertical, Horizontal }
    public partial class ctrMenuItem : UserControl
    {
        public ctrMenuItem()
        {
            InitializeComponent();
            ItemView = ItemView;
            Image = Image;
            linkLabel1.LostFocus += linkLabel1_LostFocus;
            linkLabel1.GotFocus += linkLabel1_GotFocus;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
            linkLabel1.LostFocus -= linkLabel1_LostFocus;
            linkLabel1.GotFocus -= linkLabel1_GotFocus;

            base.OnHandleDestroyed(e);
        }
        public new bool Focused
        {
            get { return linkLabel1.Focused; }
        }
        void linkLabel1_GotFocus(object sender, EventArgs e)
        {
            picmnu_MouseEnter(null, null);
        }

        void linkLabel1_LostFocus(object sender, EventArgs e)
        {
            picmnu_MouseLeave(null, null);
        }
        public Font TitleFont
        {
            get { return linkLabel1.Font; }
            set { linkLabel1.Font = value; }
        }

        Color _FocusBackColor = Color.FromArgb(24, 123, 222);
        public Color FocusBackColor
        {
            get { return _FocusBackColor; }
            set { _FocusBackColor = value; }
        }

        private ItemView _ItemView;
        public ItemView ItemView
        {
            get { return _ItemView; }
            set
            {
                _ItemView = value;
                if (value == ItemView.Horizontal)
                {
                    picmnu.Dock = DockStyle.Left;
                    linkLabel1.TextAlign = ContentAlignment.MiddleLeft;
                   this.Padding=  linkLabel1.Padding = new Padding(20, 0, 0, 0);
                }
                else
                {
                    picmnu.Dock = DockStyle.Top;
                    linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
                    this.Padding = linkLabel1.Padding = new Padding(0, 0, 0, 0);
                }
            }
        }

        public Image Image
        {
            get { return picmnu.Image; }
            set 
            {
                picmnu.Image = value;
                picmnu.SizeMode = PictureBoxSizeMode.AutoSize;
                picmnu.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        public string Title
        {
            get { return linkLabel1.Text; }
            set { linkLabel1.Text = value; }
        }
       public event EventHandler OnClikItem;
        private void picmnu_Click(object sender, EventArgs e)
        {
            if (OnClikItem == null) return;
            OnClikItem(this, e);
        }
        protected override void OnClick(EventArgs e)
        {
            picmnu_Click(this, e);
            base.OnClick(e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picmnu_Click(this, e);
        }

        private void picmnu_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = linkLabel1.BackColor = picmnu.BackColor = FocusBackColor;
            this.BorderStyle = BorderStyle.FixedSingle;
          //  Cursor.Position = PointToScreen(new Point(this.Width / 2, this.Height / 2));
        }

        private void picmnu_MouseLeave(object sender, EventArgs e)
        {
            if (linkLabel1.Focused) return;
            this.BackColor = linkLabel1.BackColor = picmnu.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;
        }

        private void ctrMenuItem_Load(object sender, EventArgs e)
        {
           
        }



    
    }
}
