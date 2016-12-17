using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using System.Windows.Forms;
using SIPProvider.SIPCore;
using SIPProvider.Common;
using SIPProvider.PhoneBookSaver;

namespace Softphone.MainFolder
{
    public class DropDownItems
    {
        private static DropDownItems _instance = null;
        public static DropDownItems Instance
        {
            get
            {
                if (_instance == null) _instance = new DropDownItems();
                return _instance;
            }
        }

        public void RegisterToolStripButtonEvents(ToolStripSplitButton item)
        {
            item.ButtonClick += new EventHandler(toolStripButton7_ButtonClick);
            item.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStripButton7_DropDownItemClicked);
            item.DropDownOpening += new EventHandler(acceptToolStripMenuItem_DropDownOpening);
        }

        public void RegisterToolStripMenuItemEvents(ToolStripMenuItem item)
        {
            item.Click += new EventHandler(toolStripButton7_ButtonClick);
            item.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStripButton7_DropDownItemClicked);
            item.DropDownOpening += new EventHandler(acceptToolStripMenuItem_DropDownOpening);
        }


        public void toolStripButton7_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                ToolStripDropDownItem button = (ToolStripDropDownItem)sender;
                acceptToolStripMenuItem_DropDownOpening(sender, e);
                if (button.DropDownItems.Count > 1) { button.ShowDropDown(); return; }
                else if (button.DropDownItems.Count == 1)
                    toolStripButton7_DropDownItemClicked(button, new ToolStripItemClickedEventArgs(button.DropDownItems[0]));
            }
            catch { }
        }

        public void toolStripButton7_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem button = (ToolStripItem)sender;
            IStateMachine state = (IStateMachine)e.ClickedItem.Tag;
            string oper = button.Tag + "";
            if (oper == "transfer")
            {
                if (MainForm.Instance.ShowPanelContianerControl(13))
                    MainForm.Instance.GetControl<ctrTransferCall>().SetData(state);
            }
            else FactoryManger.Instance.CallOperation(oper, state);
        }


        public void acceptToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripDropDownItem button = (ToolStripDropDownItem)sender;
            button.DropDownItems.Clear();
            List<IStateMachine> calls = GetTagCalls(button.Tag + "");

            foreach (IStateMachine state in calls)
            {
                if (state.IsNull) continue;
                ToolStripDropDownItem item = new ToolStripMenuItem();
                item.Image = button.Image;
                item.Tag = state;
                item.Text = GetStateTxt(state.StateId, button.Tag + "") + PhoneBook.Instance.GetUserNameOrNumber(state.CallingNumber);
                button.DropDownItems.Add(item);
            }
            if (button is ToolStripMenuItem && button.DropDownItems.Count == 1)
                button.DropDownItems[0].Visible = false;
        }

        /// <summary>
        /// accept:for accept buton
        /// hold:for hold retrieve button
        /// release:for release button
        /// transfer:for transfer call button
        /// conference:Conference Call button
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        List<IStateMachine> GetTagCalls(string tag)
        {
            List<IStateMachine> calls;
            switch (tag)
            {
                case "accept": calls = CCallManager.Instance[EStateId.INCOMING]; break;
                case "hold": calls = new List<IStateMachine>(CCallManager.Instance.CallList.Values); break;
                case "release": calls = CCallManager.Instance[EStateId.ACTIVE];
                    calls.AddRange(CCallManager.Instance[EStateId.HOLDING]);
                    calls.AddRange(CCallManager.Instance[EStateId.INCOMING]);
                    calls.AddRange(CCallManager.Instance[EStateId.ALERTING]);
                    break;
                case "transfer": calls = CCallManager.Instance[EStateId.ACTIVE];
                    calls.AddRange(CCallManager.Instance[EStateId.INCOMING]);
                    break;
                case "conference": calls = CCallManager.Instance[EStateId.INCOMING]; break;
                default: calls = new List<IStateMachine>(); break;
            }
            return calls;
        }
        string GetStateTxt(EStateId state, string tag)
        {
            if (tag == "release") return "Release ";
            if (tag == "transfer") return "Transfer ";
            if (tag == "conference") return "Conference ";
            switch (state)
            {
                case EStateId.ACTIVE: if (tag == "hold") return "Hold "; break;
                case EStateId.ALERTING: return "Accept ";
                case EStateId.HOLDING: if (tag == "hold") return "Retrieve "; break;
                case EStateId.INCOMING: return "Accept ";
            }
            return "";
        }
    }
}
