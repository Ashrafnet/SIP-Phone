using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIPProvider.PhoneBookSaver;
using SIPProvider.RemarkNotes;

namespace Softphone.RemarkNotesFace
{
    public partial class ctrRemarkNoteEditor : UserControl
    {
        public RemarkNote RemarkNote 
        { get; set; }
        /// <summary>
        /// New instance for create new phoneItem
        /// </summary>
        public ctrRemarkNoteEditor()
        {
            InitializeComponent();
            MainForm.Instance.OnOkButtonPressed += Instance_OnOkButtonPressed;
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            //unregister  events
           MainForm.Instance.OnOkButtonPressed -= Instance_OnOkButtonPressed;
           base.OnHandleDestroyed(e);
        }
        void Instance_OnOkButtonPressed()
        {
            if (!MainForm.Instance.IsShownControl<ctrRemarkNoteEditor>()) return;
            if (RemarkNote == null)//Add item
            {
                RemarkNote = RemarkNotes.Instance.AddItem(textBox1.Text,
                                            dateTimePicker1.Value);
                if (RemarkNote == null)//The addtion failed
                {
                    MessageBox.Show(RemarkNotes.Instance.LastException.Message, "Failid Add Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else//Edit item
            {
                RemarkNote.Text = textBox1.Text;
                RemarkNote.Time = dateTimePicker1.Value;
            }
            MainForm.Instance.GotoBack();
        }
        private void ctrButtonAccept_Click(object sender, EventArgs e)
        {
           
        }

        public void SetData(RemarkNote RemarkNote)
        {
            ctrTitle1.Title = this.Text = "Note Properties";
            
            this.RemarkNote = RemarkNote;
            if (RemarkNote == null) return;
            textBox1.Text = RemarkNote.Text;
            dateTimePicker1.Value = RemarkNote.Time;
        }


        public void SetData(string Text, string ItemNumber)
        {
            this.RemarkNote = null;
            textBox1.Text = Text;
        }

        private void ctrButtonCancel_Click(object sender, EventArgs e)
        {
            MainForm.Instance.GotoBack();
        }

    }
}
