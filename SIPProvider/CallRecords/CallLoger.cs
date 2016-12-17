using System;
using System.Collections.Generic;
using SIPProvider.SIPCore;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.XmlProvider;
using System.ComponentModel;
using System.Windows.Forms;
using SIPProvider.PhoneBookSaver;

namespace SIPProvider.CallRecords
{
    /// <summary>
    /// This class save the call records
    /// Data base not add or remove any record only if using AddUser and Deleteuser method
    /// </summary>
    public class CallLoger : ICallLogInterface
    { 
        #region properties
        public int MaxRecordsCount { get; set; }
        public Control Container { get; set; }
        private static CallLoger _instance = null;
        public static CallLoger Instance
        {
            get
            {
                if (_instance == null) _instance = new CallLoger();
                return _instance;
            }
        }
        private List<CCallRecord> CallRecords;
        /// <summary>
        /// Occurs when Record removed from data base
        /// </summary>
        public event ItemRemoved OnRecordRemoved;
        /// <summary>
        /// Occurs when Record added to data base
        /// </summary>
        public event ItemAdded OnRecordAdded;
        /// <summary>
        /// Occurs when Record Edited and changed
        /// </summary>
        public event DataChanged OnRecordEdited;
        /// <summary>
        /// The max user id
        /// </summary>
        private long MaxRecordId;
        XmlFile XmlFile;
        #endregion
        
        private CallLoger()
        {
            MaxRecordsCount = 30;
            XmlFile = new XmlFile("CallRecords.dat", true);
            XmlFile.RootName = "CallRecords";
        }



        #region private methods
        private void LoadRecords()
        {
            CallRecords = new List<CCallRecord>();
            List<string> sections = XmlFile.GetSectionNames();
            foreach (string section in sections)
            {
                CCallRecord record = GetRecord(section);
                if (record == null) continue;
                record.Id = long.Parse(section);
                if (record.Id > MaxRecordId) MaxRecordId = record.Id;
                record.OnDataChanged += new DataChanged(record_OnDataChanged);
                CallRecords.Add(record);
            }
            
            CallRecords.Sort(CallRecordComparer.Instance);
        }

        void record_OnDataChanged(object sender, DataChangeEventArgs e)
        {
            try
            {
                CCallRecord record = (CCallRecord)sender;
                if (record == null) return;
                RiseEvent(OnRecordEdited, sender, e);
            }
            catch { }
        }

        private CCallRecord GetRecord(string section)
        {
            try
            {
                Dictionary<string, string> data = XmlFile.GetEntryValues(section);
                CCallRecord record = new CCallRecord();
                record.Number = data[CallRecordDataNames.Number];
                record.Time = DateTime.FromBinary(long.Parse(data[CallRecordDataNames.Time]));
                record.Type = (ECallType)int.Parse(data[CallRecordDataNames.Type]);
                TimeSpan s;
                TimeSpan.TryParse(data[CallRecordDataNames.Duration], out s);
                record.Duration = s;

                return record;
            }
            catch { return null; }
        }


        /// <summary>
        /// Save record to xml file
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private bool SaveRecord(CCallRecord record)
        {
            try
            {
                string section = record.Id + "";
                XmlFile.SetValue(section, CallRecordDataNames.Number, record.Number + "");
                XmlFile.SetValue(section, CallRecordDataNames.Time, record.Time.ToBinary() + "");
                XmlFile.SetValue(section, CallRecordDataNames.Type, (int)record.Type + "");
                XmlFile.SetValue(section, CallRecordDataNames.Duration, record.Duration + "");
                XmlFile.SaveDocument();
                return true;
            }
            catch { return false; }
        }

        private void RiseEvent(Delegate deleg,params object[] param)
        {
            if (deleg == null) return;
            if (Container != null && Container.InvokeRequired) Container.Invoke(deleg, param);
            else deleg.DynamicInvoke(param);
        }
        #endregion

        #region public methods

        /// <summary>
        /// Save a back up copy
        /// </summary>
        /// <param name="backUpFile"></param>
        public void SaveBackUp(string backUpFile)
        {
            XmlFile.SaveBackUp(backUpFile);
        }

        public CCallRecord GetRecordById(long userId)
        {
            try
            {
               return  SearchOneRecord(ECallType.EAll, u => u.Id == userId);
            }
            catch { return null; }
        }

        public void addCall(ECallType type, string number, string name, DateTime time, TimeSpan duration)
        {
            try
            {
                CCallRecord record = new CCallRecord(type, number, time, duration);
                record.Id = ++MaxRecordId;
                record.OnDataChanged += new DataChanged(record_OnDataChanged);
                if (CallRecords != null) CallRecords.Insert(0, record);
                SaveRecord(record);
                RiseEvent(OnRecordAdded, record);

                List<CCallRecord> records=getList(type);
                if (records.Count > MaxRecordsCount)
                    deleteRecord(records[records.Count - 1].Id);
            }
            catch { }
        }

        public void deleteRecord(long recordId)
        {
            try
            {
                CCallRecord record = GetRecordById(recordId);
                if (record == null) return;
                if (CallRecords != null)
                    CallRecords.Remove(record);
                XmlFile.RemoveSection(recordId + "");
                RiseEvent(OnRecordRemoved, record);
                XmlFile.SaveDocument();
            }
            catch { }
        }

        public void deleteRecord(long[] recordIds)
        {
            try 
            {
                foreach (long recordId in recordIds) 
                {
                    CCallRecord record = GetRecordById(recordId);
                    if (record == null) continue;
                    if (CallRecords != null)
                        CallRecords.Remove(record);
                    XmlFile.RemoveSection(recordId + "");
                    RiseEvent(OnRecordRemoved, record);
                }
                XmlFile.SaveDocument();
            }
            catch { }
        }

        public List<CCallRecord> getList(ECallType type)
        {
            try
            {
                if (CallRecords == null) LoadRecords();
                switch (type)
                {
                    case ECallType.EAll: return getList();
                    default: return CallRecords.FindAll(r => r.Type == type);
                }
            }
            catch { return new List<CCallRecord>(); }
        }

        public List<CCallRecord> SearchList(ECallType type,Predicate<CCallRecord> match)
        {
            try
            {
                if (CallRecords == null) LoadRecords();
                switch (type)
                {
                    case ECallType.EAll: return CallRecords.FindAll(match);
                    default: return CallRecords.FindAll(r => (r.Type == type) && match(r));
                }
            }
            catch { return new List<CCallRecord>(); }
        }

        public CCallRecord SearchOneRecord(ECallType type, Predicate<CCallRecord> match)
        {
            try
            {
                if (CallRecords == null) LoadRecords();
                switch (type)
                {
                    case ECallType.EAll: return CallRecords.Find(match);
                    default: return CallRecords.Find(r => (r.Type == type) && match(r));
                }
            }
            catch { return null; }
        }

        public List<CCallRecord> getList()
        {
            try
            {
                if (CallRecords == null)
                    LoadRecords();
                return new List<CCallRecord>(CallRecords);
            }
            catch { return new List<CCallRecord>(); }
        }

        #endregion
    }
}
