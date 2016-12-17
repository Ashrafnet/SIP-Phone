using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore;

namespace SIPProvider.PhoneBookSaver
{
    #region Constants Data Names
    public struct PhoneUserDataNames
    {
        public const string Id = "Id";
        public const string UserName = "UserName";
        public const string UserNumber = "UserNumber";
        public const string RegisterTime = "RegisterTime";
        public const string UserAddress = "UserAddress";
        public const string UserEmail = "UserEmail";
    }
    #endregion

    public class PhoneUser : RizeDataChangeEvents
    {
        /// <summary>
        /// The id which used to defferant useres
        /// This flag set by the phoneBook class so dont change it
        /// This flag does not rise the OnDataChanging events
        /// </summary>
        public long Id { get; set; }
       
        public PhoneUser() {  }
        public PhoneUser(string UserName, string UserNumber, DateTime RegisterTime, string UserAddress, string UserEmail)
            : this()
        {
            this._UserName = UserName;
            this._UserNumber = UserNumber;
            this._RegisterTime = RegisterTime;
            this._UserAddress = UserAddress;
            this._UserEmail = UserEmail;
        }


       
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set 
            {
                if (!RiseEvent1(PhoneUserDataNames.UserName, _UserName, value)) return;
                _UserName = value;
                RiseEvent2(PhoneUserDataNames.UserName, _UserName, value);
            }
        }

        private string _UserNumber;
        public string UserNumber
        {
            get { return _UserNumber; }
            set
            {
                if (!RiseEvent1(PhoneUserDataNames.UserNumber, _UserNumber, value)) return;
                _UserNumber = value;
                RiseEvent2(PhoneUserDataNames.UserNumber, _UserNumber, value);
            }
        }

        private DateTime _RegisterTime;
        public DateTime RegisterTime
        {
            get { return _RegisterTime; }
            set
            {
                if (!RiseEvent1(PhoneUserDataNames.RegisterTime, _RegisterTime, value)) return;
                _RegisterTime = value;
                RiseEvent2(PhoneUserDataNames.RegisterTime, _RegisterTime, value);
            }
        }


        private string _UserAddress;
        public string UserAddress
        {
            get { return _UserAddress; }
            set
            {

                if (!RiseEvent1(PhoneUserDataNames.UserAddress, _UserAddress, value)) return;
                _UserAddress = value;
                RiseEvent2(PhoneUserDataNames.UserAddress, _UserAddress, value);
            }
        }


        private string _UserEmail;
        public string UserEmail
        {
            get { return _UserEmail; }
            set
            {
                if (!RiseEvent1(PhoneUserDataNames.UserEmail, _UserEmail, value)) return;
                _UserEmail = value;
                RiseEvent2(PhoneUserDataNames.UserEmail, _UserEmail, value);
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
                case PhoneUserDataNames.Id: return Id;
                case PhoneUserDataNames.UserName: return UserName;
                case PhoneUserDataNames.UserNumber: return UserNumber;
                case PhoneUserDataNames.RegisterTime: return RegisterTime;
                case PhoneUserDataNames.UserAddress: return UserAddress;
                case PhoneUserDataNames.UserEmail: return UserName;
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
                    case PhoneUserDataNames.Id: Id = long.Parse(value + ""); break;
                    case PhoneUserDataNames.UserName: UserName = value + ""; break;
                    case PhoneUserDataNames.UserNumber: UserNumber = value + ""; break;
                    case PhoneUserDataNames.RegisterTime: RegisterTime = (DateTime)value; break;
                    case PhoneUserDataNames.UserAddress: UserAddress = value + ""; break;
                    case PhoneUserDataNames.UserEmail: UserName = value + ""; break;
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
