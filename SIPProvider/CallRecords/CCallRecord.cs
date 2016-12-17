using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore;
using SIPProvider.PhoneBookSaver;

namespace SIPProvider.CallRecords
{
    #region Constants Data Names
    public struct CallRecordDataNames
    {
        public const string Id = "Id";
        public const string Name = "Name";
        public const string Number = "Number";
        public const string Time = "Time";
        public const string Type = "Type";
        public const string Duration = "Duration";
    }
    #endregion

    public class CCallRecord : RizeDataChangeEvents
    {

        /// <summary>
        /// The id which used to defferant CallRecords
        /// This flag set by the CallRecordsCollection class so dont change it
        /// This flag does not rise the OnDataChanged events
        /// </summary>
        public  long Id;
        public CCallRecord() 
        {
            PhoneBook.Instance.OnUserAdded += new ItemAdded(Instance_OnUserAdded);
            PhoneBook.Instance.OnUserEdited += new DataChanged(Instance_OnUserEdited);
            PhoneBook.Instance.OnUserRemoved += new ItemRemoved(Instance_OnUserRemoved);
        }

        void Instance_OnUserRemoved(object sender)
        {
            Instance_OnUserAdded(sender);
        }

        void Instance_OnUserEdited(object sender, DataChangeEventArgs e)
        {
            Instance_OnUserAdded(sender);
        }

        void Instance_OnUserAdded(object sender)
        {
            Name = Name;//Get name from phonebook and rize events
        }

        public CCallRecord(ECallType type, string number, DateTime time, TimeSpan duration)
        {
            this._Type = type;
            this._Number = number;
            this._Time = time;
            this._Duration = duration;
        }
        
        /// <summary>
        ///Get Call name from phoneBook data base
        /// </summary>
        public string Name
        {
            get 
            {
                if (PhoneUser == null) return Number;
                else return PhoneUser.UserName; 
            }
            private set
            {
                RiseEvent2(CallRecordDataNames.Name, value, value);
            }
        }

        /// <summary>
        /// Call number
        /// </summary>
        private string _Number;
        public string Number
        {
            get { return _Number; }
            set
            {
                if (!RiseEvent1(CallRecordDataNames.Number, _Number, value)) return;
                _Number = value;
                RiseEvent2(CallRecordDataNames.Number, _Number, value);
            }
        }
        /// <summary>
        /// Call mode
        /// </summary>
        private ECallType _Type;
        public ECallType Type
        {
            get { return _Type; }
            set
            {
                if (!RiseEvent1(CallRecordDataNames.Type, _Type, value)) return;
                _Type = value;
                RiseEvent2(CallRecordDataNames.Type, _Type, value);
            }
        }
        /// <summary>
        /// Duration of call
        /// </summary>
        private TimeSpan _Duration;
        public TimeSpan Duration
        {
            get { return _Duration; }
            set
            {
                if (!RiseEvent1(CallRecordDataNames.Duration, _Duration, value)) return;
                _Duration = value;
                RiseEvent2(CallRecordDataNames.Duration, _Duration, value);
            
            }
        }
        /// <summary>
        /// Call time
        /// </summary>
        private DateTime _Time;
        public DateTime Time
        {
            get { return _Time; }
            set
            {
                if (!RiseEvent1(CallRecordDataNames.Time, _Time, value)) return;
                _Time = value;
                RiseEvent2(CallRecordDataNames.Time, _Time, value);

            }
        }

        /// <summary>
        /// The txt take the image :   Name,Number,Type,Duration,Time
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return  Number + "," + (int)Type + "," + Duration.Ticks + "," + Time.Ticks;
        }

        /// <summary>
        /// Get value wheteh this call number Exist In PhoneBook data base
        /// </summary>
        public bool ExistInPhoneBook
        {
            get
            {
                return PhoneUser != null;
            }
        }
        /// <summary>
        /// Get PhoneUser if this call number Exist In PhoneBook data base or null if not exist
        /// </summary>
        public PhoneUser PhoneUser
        {
            get
            {
                try
                {
                    return PhoneBook.Instance.SearchOneUser(u => u.UserNumber.ToLower() == Number.ToLower());
                }
                catch { return null; }
            }
        }
    }
}
