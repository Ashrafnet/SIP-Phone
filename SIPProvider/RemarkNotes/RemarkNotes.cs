using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.XmlProvider;
using SIPProvider.CallRecords;
using SIPProvider.SIPCore;
using System.Windows.Forms;

namespace SIPProvider.RemarkNotes
{
    /// <summary>
    /// This class save the RemarkNotes
    /// Any change in the contact it saved internally so , dont save your  change
    /// Data base not add or remove any record only if using AddNote and DeleteNote method
    /// </summary>
    public class RemarkNotes
    {
        #region properties
        public Control Container { get; set; }
        private static RemarkNotes _instance = null;
        public static RemarkNotes Instance
        {
            get
            {
                if (_instance == null) _instance = new RemarkNotes();
                return _instance;
            }
        }
        /// <summary>
        /// Occurs when item removed from data base
        /// </summary>
        public event ItemRemoved OnItemRemoved;
        /// <summary>
        /// Occurs when item added to data base
        /// </summary>
        public event ItemAdded OnItemAdded;
        /// <summary>
        /// Occurs when item Edited and changed
        /// </summary>
        public event DataChanged OnItemEdited;
        /// <summary>
        /// Conain the last error
        /// </summary>
        public Exception LastException { get;private set; }
        private List<RemarkNote> Notes;
        /// <summary>
        /// The max item id
        /// </summary>
        private long MaxId;
        XmlFile XmlFile;
        #endregion

        private RemarkNotes()
        {
            XmlFile = new XmlFile("RemarkNotes.dat", true  );
            XmlFile.RootName = "RemarkNotes";
        }
        
        #region private methods
       
        private void LoadRecords()
        {
            Notes = new List<RemarkNote>();
            List<string> sections = XmlFile.GetSectionNames();
            foreach (string section in sections)
            {
                RemarkNote item = GetRecord(section);
                if (item == null) continue;
                item.Id = long.Parse(section);
                if (item.Id > MaxId) MaxId = item.Id;
                RegisterItemEvents(item);
                Notes.Add(item);
            }
        //    Items.Sort(PhoneItemComparer.Instance);
        }

       

        private void item_OnDataChanged(object sender, DataChangeEventArgs e)
        {
            try
            {
                RemarkNote item = (RemarkNote)sender;
                if (item == null) return;
                RiseEvent(OnItemEdited, sender, e);
                string section = item.Id + "";
                string newValue = e.NewValue is DateTime ? ((DateTime)e.NewValue).ToBinary() + "" : e.NewValue + "";
                if (e.DataName == RemarkNoteDataNames.Time && ((DateTime)e.NewValue) > DateTime.Now)
                    item.IsRead = false;
                XmlFile.SetValue(section, e.DataName, newValue);
                XmlFile.SaveDocument();
            }
            catch { }
        }



        private RemarkNote GetRecord(string section)
        {
            try
            {
                Dictionary<string, string> data = XmlFile.GetEntryValues(section);
                RemarkNote item = new RemarkNote();
                item.Text = data[RemarkNoteDataNames.Text];
                item.Time = DateTime.FromBinary(long.Parse(data[RemarkNoteDataNames.Time]));
                item.IsRead = bool.Parse(data[RemarkNoteDataNames.IsRead]);
                return item;
            }
            catch { return null; }
        }


        /// <summary>
        /// Save this item to xml file
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool SaveItem(RemarkNote item)
        {
            try
            {
                string section = item.Id + "";
                XmlFile.SetValue(section, RemarkNoteDataNames.Text, item.Text);
                XmlFile.SetValue(section, RemarkNoteDataNames.Time, item.Time.ToBinary() + "");
                XmlFile.SetValue(section, RemarkNoteDataNames.IsRead, item.IsRead + "");
                return true;
            }
            catch (Exception ex) { LastException = ex; return false; }
        }

        private void RegisterItemEvents(RemarkNote item)
        {
            item.OnDataChanged += new SIPProvider.SIPCore.DataChanged(item_OnDataChanged);
        }

        private void RiseEvent(Delegate deleg, params object[] param)
        {
            if (deleg == null) return;
            if (Container != null && Container.InvokeRequired) Container.Invoke(deleg, param);
            else deleg.DynamicInvoke(param);
        }
        #endregion


        #region public methods

        public RemarkNote GetItemById(long itemId)
        {
            try
            {
                return SearchOneItem(u => u.Id == itemId);//load from memory if it loaded
            }
            catch (Exception ex) { LastException = ex; return null; }
        }

        /// <summary>
        /// If the item found return
        /// Return null if the add item failied
        /// </summary>
        /// <param name="item"></param>
        public RemarkNote AddItem(string Text, DateTime Time)
        {
            try
            {
                RemarkNote item = new RemarkNote(Text, Time);
                item.Id = ++MaxId;
                if (SaveItem(item))
                {
                    RegisterItemEvents(item);
                    if (Notes != null)
                        Notes.Add(item);
                    RiseEvent(OnItemAdded, item);
                    XmlFile.SaveDocument();
                    return item;
                }
                else return null;
            }
            catch (Exception ex) { LastException = ex; return null; }
        }


        public bool DeleteItem(long itemId)
        {
            try
            {
                RemarkNote item = GetItemById(itemId);
                if(item==null)return false;
                if (Notes != null)//remove item from memory
                     Notes.Remove(item);
                if (!XmlFile.RemoveSection(itemId + "")) return false;
                else
                {
                    RiseEvent(OnItemRemoved, item);
                    XmlFile.SaveDocument();
                    return true;
                }
            }
            catch (Exception ex) { LastException = ex; return false; }
        }


        public List<RemarkNote> SearchItems(Predicate<RemarkNote> match)
        {
            try
            {
                if (Notes == null) LoadRecords();
                return Notes.FindAll(match);
            }
            catch { return new List<RemarkNote>(); }
        }

        public RemarkNote SearchOneItem(Predicate<RemarkNote> match)
        {
            try
            {
                if (Notes == null) LoadRecords();
                return Notes.Find(match);
            }
            catch { return null; }
        }

        public List<RemarkNote> GetItems()
        {
            try
            {
                if (Notes == null) LoadRecords();
                return new List<RemarkNote>(Notes);
            }
            catch { return new List<RemarkNote>(); }
        }
        /// <summary>
        /// Save a back up copy
        /// </summary>
        /// <param name="backUpFile"></param>
        public void SaveBackUp(string backUpFile)
        {
            try { XmlFile.SaveBackUp(backUpFile); }
            catch { }
        }
        #endregion
       
    }
}
