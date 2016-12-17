using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore;

namespace SIPProvider.RemarkNotes
{
    #region Constants Data Names
    public struct RemarkNoteDataNames
    {
        public const string Id = "Id";
        public const string Text = "Text";
        public const string Time = "Time";
        public const string IsRead = "IsRead";
    }
    #endregion

    public class RemarkNote : RizeDataChangeEvents
    {
        public long Id { get; set; }
        public RemarkNote() {  }
        public RemarkNote(string Text, DateTime Time)
            : this()
        {
            this._Text = Text;
            this._Time = Time;
        }

        private string _Text;
        public string Text
        {
            get { return _Text; }
            set
            {
                if (!RiseEvent1(RemarkNoteDataNames.Text, _Text, value)) return;
                _Text = value;
                RiseEvent2(RemarkNoteDataNames.Text, _Text, value);
            }
        }

        private bool _IsRead;
        public bool IsRead
        {
            get { return _IsRead; }
            set
            {
                if (!RiseEvent1(RemarkNoteDataNames.IsRead, _IsRead, value)) return;
                _IsRead = value;
                RiseEvent2(RemarkNoteDataNames.IsRead, _IsRead, value);
            }
        }

        private DateTime _Time;
        public DateTime Time
        {
            get { return _Time; }
            set
            {
                if (!RiseEvent1(RemarkNoteDataNames.Time, _Time, value)) return;
                _Time = value;
                RiseEvent2(RemarkNoteDataNames.Time, _Time, value);
            }
        }

        /// <summary>
        /// get data  value by its name
        /// </summary>
        /// <param name="dataName"></param>
        /// <returns></returns>
        public object GetData(string dataName)
        {
            switch (dataName)
            {
                case RemarkNoteDataNames.Id: return Id;
                case RemarkNoteDataNames.Text: return Text;
                case RemarkNoteDataNames.Time: return Time;
                case RemarkNoteDataNames.IsRead: return IsRead;
                default: return null;
            }
        }

        /// <summary>
        /// Set data value by its name
        /// </summary>
        /// <param name="dataName"></param>
        /// <returns></returns>
        public void SetData(string dataName,object value)
        {
            try
            {
                switch (dataName)
                {
                    case RemarkNoteDataNames.Id: Id = long.Parse(value + ""); break;
                    case RemarkNoteDataNames.Text: Text = value + ""; break;
                    case RemarkNoteDataNames.Time: Time = (DateTime)value; break;
                    case RemarkNoteDataNames.IsRead: IsRead = (bool)value; break;
                }
            }
            catch { }
        }

        public object this[string dataName]
        {
            get { return GetData(dataName); }
            set { SetData(dataName, value); }
        }
    }
} 
