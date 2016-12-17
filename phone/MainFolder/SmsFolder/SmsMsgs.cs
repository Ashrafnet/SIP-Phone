using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SIPProvider.SIPCore;
using SIPProvider.XmlProvider;
using System.Xml;
using System.IO;
using Softphone.ConfigFolder;
using Softphone.SettingFolder;

namespace Softphone.SmsFolder
{

    #region Constants Data Names
    public struct MsgDataNames
    {
        public const string Id = "id";
        public const string Subject = "subject";
        public const string Msg = "msg";
        public const string Reads = "read";
        public const string Section = "message";
        public const string Date = "date";
    }
    #endregion

    public class SmsMsgs
    {
        #region properties
        /// <summary>
        /// Occurs when request load finished
        /// </summary>
        public event DataLoaded OnDataLoaded;
        /// <summary>
        /// Used to fix multi thread
        /// </summary>
        public Control Container { get; set; }
        private static SmsMsgs _instance = null;
        public static SmsMsgs Instance
        {
            get
            {
                if (_instance == null) _instance = new SmsMsgs();
                return _instance;
            }
        }

        private List<SmsMsg> Msgs;
        XmlDocument Document;
        public SMSBoxType SMSBoxType { get; set; }
        #endregion

        private SmsMsgs()
        {
            Document = new XmlDocument();
            //string xml = File.ReadAllText("sms_results.txt",Encoding.Default);
            //Document.LoadXml(xml);
        }

        private void RiseEvent(Delegate deleg)
        {
            if (deleg == null) return;
            if (Container != null && Container.InvokeRequired) Container.Invoke(deleg);
            else deleg.DynamicInvoke();
        }

        private void LoadFromWeb()
        {
            LoadMsgs();
           RiseEvent(OnDataLoaded);
        }

        #region public methods
        System.Threading.Thread thread;
        /// <summary>
        /// Load msg by thread and when finish load msgs the OnDataLoaded event rise
        /// </summary>
        public void RequestLoadMsgs()
        {
             thread = new System.Threading.Thread(LoadFromWeb);
            thread.Start();
        }
        public void StopLoading()
        {
            try
            {
                Loading = false;
                thread.Abort();
            }
            catch { }
        }
        bool Loading;
        /// <summary>
        /// Load msg from web
        /// </summary>
        public void LoadMsgs()
        {
            try
            {
                if (Loading) return;
                Loading = true;
                string xml = clsSMS.GetSmS(PhoneConfig.Instance.Accounts[0].UserName, PhoneConfig.Instance.Accounts[0].Password, SMSBoxType);
                //string xml = File.ReadAllText("sms_results.txt", Encoding.Default);
                Document.LoadXml(xml);

                List<SmsMsg> Msgs = new List<SmsMsg>();
                foreach (XmlNode child in Document.DocumentElement)
                {
                    SmsMsg msg = new SmsMsg();
                    msg.Id = long.Parse(child[MsgDataNames.Id].InnerText);
                    msg.Message = child[MsgDataNames.Msg].InnerText;
                    try { msg.Reads = int.Parse(child[MsgDataNames.Reads].InnerText); }
                    catch { }
                    msg.subject = child[MsgDataNames.Subject].InnerText;
                    msg.Date = child[MsgDataNames.Date].InnerText;
                    Msgs.Add(msg);
                }
                this.Msgs = Msgs;
            }
            catch { }
            finally { Loading = false; }
        }


        public SmsMsg GetMsgById(long userId)
        {
            try
            {
                 return SearchOneMsg(u => u.Id == userId);
            }
            catch  { return null; }
        }

        public List<SmsMsg> SearchMsgs(Predicate<SmsMsg> match)
        {
            try
            {
                return Msgs.FindAll(match);
            }
            catch { return new List<SmsMsg>(); }
        }

        public SmsMsg SearchOneMsg(Predicate<SmsMsg> match)
        {
            try
            {
                return Msgs.Find(match);
            }
            catch { return null; }
        }

        public List<SmsMsg> GetMsgs()
        {
            try
            {
                return new List<SmsMsg>(Msgs);
            }
            catch { return new List<SmsMsg>(); }
        }

        public bool DeleteMsg(List<string> msgs)
        {
            try
            {
                string x = "";
                foreach (string msg in msgs)
                {
                    if (x.Contains(msg)) continue;
                    x += msg + ",";
                }
                x = x.TrimEnd(',');
                return clsSMS.DelSmS(PhoneConfig.Instance.Accounts[0].UserName, PhoneConfig.Instance.Accounts[0].Password, x, SMSBoxType);
            }
            catch { return false; }
        }
        /// <summary>
        /// Save a back up copy
        /// </summary>
        /// <param name="backUpFile"></param>
        public bool SaveBackUp(string backUpFile)
        {
            try
            {
                Document.Save(backUpFile);
                return true;
            }
            catch { return false; }
        }
        #endregion

    }
}
