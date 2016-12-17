using System;
using SIPProvider.XmlProvider;
using System.Collections.Specialized;
using SIPProvider.SIPCore;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Softphone.SettingFolder
{
    public class Settings : ISettings
    {
        private XmlFile XmlFile;
        private static ISettings _Default;
        public static ISettings Default
        {
            get
            {
                if (_Default == null) _Default = new Settings();
                return _Default;
            }
        }

        private Settings()
        {
            XmlFile = new XmlFile("SoftphoneSettings.dat",true);
            XmlFile.RootName = "SoftphoneSettings";
            LoadSettings();
        }


  
        #region ISettings interface
        public Dictionary<string, string> ExtendibleVar { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public bool AutoAnswer { get; set; }
        public bool CFBFlag { get; set; }
        public string CFBNumber { get; set; }
        public bool CFNRFlag { get; set; }
        public string CFNRNumber { get; set; }
        public bool CFUFlag { get; set; }
        public string CFUNumber { get; set; }
        public StringCollection CodecList { get; set; }
        public StringCollection PhoneBookSearch { get; set; }
        public StringCollection CallRecordsSearch { get; set; }
        public string DateTimeFormat { get; set; }
        public int DefaultAccountIndex { get; set; }
        public string DisplayName { get; set; }
        public bool DNDFlag { get; set; }
        public string DomainName { get; set; }
        public string pass { get; set; }
        public bool PublishEnabled { get; set; }
        public string SipHostName { get; set; }
        public int SipPort { get; set; }
        public string SipProxy { get; set; }
        public ETransportMode TransportMode { get; set; }
        public string UserName { get; set; }
        public bool RememberRegistration { get; set; }
        public int ECTail { get; set; }
        public int Expires { get; set; }
        public EDtmfMode DtmfMode { get; set; }
        public bool VADEnabled { get; set; }
        public int SpeakerValue { get; set; }
        public int RecordingValue { get; set; }
        public string StunServerAddress { get; set; }
        public string ProgramName { get; set; }
        public string BalanceLink { get; set; }
        public string CreateAccountLink { get; set; }
        public string ChangePasswordLink { get; set; }
        public string ProfileUserLink { get; set; }
        public bool AutoLogin { get; set; }
        public string ProxyAddress { get; set; }
        public string ProxyUserName { get; set; }
        public string ProxyPassword { get; set; }
        public string ProxyDomain { get; set; }
        public bool UseProxy { get; set; }
        public bool UseProxyAuthentication { get; set; }
        public StringCollection LoginUsers { get; set; }
        #endregion


        public void LoadDefultSettings()
        {
            AccountId = DefultSettings.Default.AccountId;
            AccountName = DefultSettings.Default.AccountName;
            AutoAnswer = DefultSettings.Default.AutoAnswer;
            CFBFlag = DefultSettings.Default.CFBFlag;
            CFBNumber = DefultSettings.Default.CFBNumber;
            CFNRFlag = DefultSettings.Default.CFNRFlag;
            CFNRNumber = DefultSettings.Default.CFNRNumber;
            CFUFlag = DefultSettings.Default.CFUFlag;
            CFUNumber = DefultSettings.Default.CFUNumber;
            CodecList = DefultSettings.Default.CodecList;
            PhoneBookSearch = DefultSettings.Default.PhoneBookSearch;
            CallRecordsSearch = DefultSettings.Default.CallRecordsSearch;
            DateTimeFormat = DefultSettings.Default.DateTimeFormat;
            DefaultAccountIndex = DefultSettings.Default.DefaultAccountIndex;
            DisplayName = DefultSettings.Default.DisplayName;
            DNDFlag = DefultSettings.Default.DNDFlag;
            DomainName = DefultSettings.Default.DomainName;
            pass = DefultSettings.Default.pass;
            PublishEnabled = DefultSettings.Default.PublishEnabled;
            SipHostName = DefultSettings.Default.SipHostName;
            SipPort = DefultSettings.Default.SipPort;
            SipProxy = DefultSettings.Default.SipProxy;
            TransportMode = DefultSettings.Default.TransportMode;
            UserName = DefultSettings.Default.UserName;
            RememberRegistration = DefultSettings.Default.RememberRegistration;
            ECTail = DefultSettings.Default.ECTail;
            Expires = DefultSettings.Default.Expires;
            DtmfMode = DefultSettings.Default.DtmfMode;
            VADEnabled = DefultSettings.Default.VADEnabled;
            SpeakerValue = DefultSettings.Default.SpeakerValue;
            RecordingValue = DefultSettings.Default.RecordingValue;
            StunServerAddress = DefultSettings.Default.StunServerAddress;

            ProgramName = DefultSettings.Default.ProgramName; ;
            BalanceLink = DefultSettings.Default.BalanceLink; ;
            CreateAccountLink = DefultSettings.Default.CreateAccountLink;
            ChangePasswordLink = DefultSettings.Default.ChangePasswordLink;
            ProfileUserLink = DefultSettings.Default.ProfileUserLink;
            AutoLogin = DefultSettings.Default.AutoLogin;
            ProxyAddress = DefultSettings.Default.ProxyAddress;
            ProxyUserName = DefultSettings.Default.ProxyUserName;
            ProxyPassword = DefultSettings.Default.ProxyPassword;
            ProxyDomain = DefultSettings.Default.ProxyDomain;
            UseProxy = DefultSettings.Default.UseProxy;
            UseProxyAuthentication = DefultSettings.Default.UseProxyAuthentication;
            LoginUsers = DefultSettings.Default.LoginUsers;
        }

        public void LoadSettings()
        {
            ExtendibleVar = GetExtendiblVar();
            AccountId = GetStringValue("AccountId") ;
            AccountName = GetStringValue("AccountName");
            AutoAnswer = GetBoolValue("AutoAnswer");
            CFBFlag = GetBoolValue("CFBFlag");
            CFBNumber = GetStringValue("CFBNumber");
            CFNRFlag = GetBoolValue("CFNRFlag");
            CFNRNumber = GetStringValue("CFNRNumber");
            CFUFlag = GetBoolValue("CFUFlag");
            CFUNumber = GetStringValue("CFUNumber");
            CodecList = GetList("CodecList");
            PhoneBookSearch = GetList("PhoneBookSearch");
            CallRecordsSearch = GetList("CallRecordsSearch");
            DateTimeFormat = GetStringValue("DateTimeFormat");
            DefaultAccountIndex = GetIntValue("DefaultAccountIndex") ;
            DisplayName = GetStringValue("DisplayName");
            DNDFlag = GetBoolValue("DNDFlag");
            DomainName = GetStringValue("DomainName");
            pass = GetStringValue("pass");
            PublishEnabled = GetBoolValue("PublishEnabled");
            SipHostName = GetStringValue("SipHostName");
            SipPort = GetIntValue("SipPort");
            SipProxy = GetStringValue("SipProxy");
            TransportMode = (ETransportMode)GetIntValue("TransportMode");
            UserName = GetStringValue("UserName");
            RememberRegistration = GetBoolValue("RememberRegistration");
            ECTail = GetIntValue("ECTail");
            Expires = GetIntValue("Expires");
            DtmfMode = (EDtmfMode)GetIntValue("DtmfMode");
            VADEnabled = GetBoolValue("VADEnabled");
            SpeakerValue = GetIntValue("SpeakerValue");
            RecordingValue = GetIntValue("RecordingValue");
            StunServerAddress = GetStringValue("StunServerAddress");

            ProgramName = GetStringValue("ProgramName");
            BalanceLink = GetStringValue("BalanceLink");
            CreateAccountLink = GetStringValue("CreateAccountLink");
            ChangePasswordLink = GetStringValue("ChangePasswordLink");
            ProfileUserLink = GetStringValue("ProfileUserLink");
            AutoLogin = GetBoolValue("AutoLogin");

            ProxyAddress = GetStringValue("ProxyAddress");
            ProxyUserName = GetStringValue("ProxyUserName");
            ProxyPassword = GetStringValue("ProxyPassword");
            ProxyDomain = GetStringValue("ProxyDomain");
            UseProxy = GetBoolValue("UseProxy");
            UseProxyAuthentication = GetBoolValue("UseProxyAuthentication");

            LoginUsers = GetList("LoginUsers");
        }

        #region Methods used to load values from xml file


        private string GetStringValue(string valueName)
        {
            try
            {
                if (!XmlFile.IsExistsEntry("SingleSettings", valueName)) return DefultSettings.Default[valueName] + "";
                else return XmlFile.GetValue("SingleSettings", valueName);
            }
            catch { return DefultSettings.Default[valueName] + ""; }
        }

        private int GetIntValue(string valueName)
        {
            try
            {
                if (!XmlFile.IsExistsEntry("SingleSettings", valueName)) return (int)DefultSettings.Default[valueName];
                else return int.Parse( XmlFile.GetValue("SingleSettings", valueName));
            }
            catch { return (int)DefultSettings.Default[valueName]; }
        }
         
        private bool GetBoolValue(string valueName)
        {
            try
            {
                if (!XmlFile.IsExistsEntry("SingleSettings", valueName)) return (bool)DefultSettings.Default[valueName];
                else return Convert.ToBoolean(XmlFile.GetValue("SingleSettings", valueName));
            }
            catch { return (bool)DefultSettings.Default[valueName]; }
        }

        private Dictionary<string, string> GetExtendiblVar()
        {
            try
            {
                if (!XmlFile.IsExistsSection("ExtendibleVar")) return DefultSettings.Default.ExtendibleVar;
                Dictionary<string, string> list = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> itm in XmlFile.GetEntryValues("ExtendibleVar"))
                    list.Add(itm.Key, itm.Value);
                return list;
            }
            catch { return DefultSettings.Default.ExtendibleVar; }
        }

        private StringCollection GetList(string listName)
        {
            try
            {
                if (!XmlFile.IsExistsSection(listName)) return (StringCollection)DefultSettings.Default[listName];
                StringCollection list = new StringCollection();
                foreach (string itm in XmlFile.GetEntryValues(listName).Values)
                    list.Add(itm);
                return list;
            }
            catch { return (StringCollection)DefultSettings.Default[listName]; }
        }

        #endregion

       

        private object GetValue(string valueName)
        {
            switch (valueName)
            {
                case "ExtendibleVar": return ExtendibleVar;
                case "AccountId": return AccountId;
                case "AccountName": return AccountName;
                case "AutoAnswer": return AutoAnswer;
                case "CFBFlag": return CFBFlag;
                case "CFBNumber": return CFBNumber;
                case "CFNRFlag": return CFNRFlag;
                case "CFNRNumber": return CFNRNumber;
                case "CFUFlag": return CFUFlag;
                case "CFUNumber": return CFUNumber;
                case "CodecList": return CodecList;
                case "PhoneBookSearch": return PhoneBookSearch;
                case "CallRecordsSearch": return CallRecordsSearch;
                case "DateTimeFormat": return DateTimeFormat;
                case "DefaultAccountIndex": return DefaultAccountIndex;
                case "DisplayName": return DisplayName;
                case "DNDFlag": return DNDFlag;
                case "DomainName": return DomainName;
                case "pass": return pass;
                case "PublishEnabled": return PublishEnabled;
                case "SipHostName": return SipHostName;
                case "SipPort": return SipPort;
                case "SipProxy": return SipProxy;
                case "TransportMode": return TransportMode;
                case "UserName": return UserName;
                case "RememberRegistration":return RememberRegistration;
                case "ECTail": return ECTail;
                case "Expires": return Expires;
                case "DtmfMode": return DtmfMode;
                case "VADEnabled": return VADEnabled;
                case "SpeakerValue": return SpeakerValue;
                case "RecordingValue": return RecordingValue;
                case "StunServerAddress": return StunServerAddress;
                case "ProgramName": return ProgramName;
                case "BalanceLink": return BalanceLink;
                case "CreateAccountLink": return CreateAccountLink;
                case "ChangePasswordLink": return ChangePasswordLink;
                case "ProfileUserLink": return ProfileUserLink;
                case "AutoLogin": return AutoLogin;
                case "ProxyAddress": return ProxyAddress;
                case "ProxyUserName": return ProxyUserName;
                case "ProxyPassword": return ProxyPassword;
                case "ProxyDomain": return ProxyDomain;
                case "UseProxy": return UseProxy;
                case "UseProxyAuthentication": return UseProxyAuthentication;
                case "LoginUsers": return LoginUsers;
                default: return null;
            }
        }

        private void SetValue(string valueName,object value)
        {
            switch (valueName)
            {
                case "ExtendibleVar": ExtendibleVar = (Dictionary<string, string>)value; break;
                case "AccountId": AccountId = value + ""; break;
                case "AccountName": AccountName = value + ""; break;
                case "AutoAnswer": AutoAnswer = (bool)value; break;
                case "CFBFlag": CFBFlag = (bool)value; break;
                case "CFBNumber": CFBNumber = value + ""; break;
                case "CFNRFlag": CFNRFlag = (bool)value; break;
                case "CFNRNumber": CFNRNumber = value + ""; break;
                case "CFUFlag": CFUFlag = (bool)value; break;
                case "CFUNumber": CFUNumber = value + ""; break;
                case "CodecList": CodecList = (StringCollection)value; break;
                case "PhoneBookSearch": PhoneBookSearch = (StringCollection)value; break;
                case "CallRecordsSearch": CallRecordsSearch = (StringCollection)value; break;
                case "DateTimeFormat": DateTimeFormat = value + ""; break;
                case "DefaultAccountIndex": DefaultAccountIndex = (int)value; break;
                case "DisplayName": DisplayName = value + ""; break;
                case "DNDFlag": DNDFlag = (bool)value; break;
                case "DomainName": DomainName = value + ""; break;
                case "pass": pass = value + ""; break;
                case "PublishEnabled": PublishEnabled = (bool)value; break;
                case "SipHostName": SipHostName = value + ""; break;
                case "SipPort": SipPort = (int)value; break;
                case "SipProxy": SipProxy = value + ""; break;
                case "TransportMode": TransportMode = (ETransportMode)value; break;
                case "UserName": UserName = value + ""; break;
                case "RememberRegistration": RememberRegistration = (bool)value; break;
                case "ECTail": ECTail = (int)value; break;
                case "Expires": Expires = (int)value; break;
                case "DtmfMode": DtmfMode = (EDtmfMode)value; break;
                case "VADEnabled": VADEnabled = (bool)value; break;
                case "SpeakerValue": SpeakerValue = (int)value; break;
                case "RecordingValue": RecordingValue = (int)value; break;
                case "StunServerAddress": StunServerAddress = value + ""; break;
                case "ProgramName": ProgramName = value + ""; break;
                case "BalanceLink": BalanceLink = value + ""; break;
                case "CreateAccountLink": CreateAccountLink = value + ""; break;
                case "ChangePasswordLink": ChangePasswordLink = value + ""; break;
                case "ProfileUserLink": ProfileUserLink = value + ""; break;
                case "AutoLogin": AutoLogin = (bool)value; break;
                case "ProxyAddress": ProxyAddress = value + ""; break;
                case "ProxyUserName": ProxyUserName = value + ""; break;
                case "ProxyPassword": ProxyPassword = value + ""; break;
                case "ProxyDomain": ProxyDomain = value + ""; break;
                case "UseProxy": UseProxy = (bool)value; break;
                case "UseProxyAuthentication": UseProxyAuthentication = (bool)value; break;
                case "LoginUsers": LoginUsers = (StringCollection)value; break;
            }
        }

        public  object this[string valueName]
        {
            get
            {
                return GetValue(valueName);
            }
            set
            {
                SetValue(valueName, value);
            }
        }

        private void SaveExtendibleVar()
        {
            try
            {
                XmlFile.RemoveSection("ExtendibleVar");
                foreach (KeyValuePair<string, string> itm in ExtendibleVar)
                    XmlFile.SetValue("ExtendibleVar", itm.Key, itm.Value);
            }
            catch { }
        }

        private void SaveList(string listName)
        {
            try
            {
                XmlFile.RemoveSection(listName);
                int i = 0;
                foreach (string itm in (StringCollection)this[listName])
                    XmlFile.SetValue(listName, i++ + "", itm);
            }
            catch { }
        }

        public void Save(string valueName)
        {
            switch (valueName)
            {
                case "ExtendibleVar": SaveExtendibleVar(); break;
                case "AccountId": XmlFile.SetValue("SingleSettings", "AccountId", AccountId);break;
                case "AccountName": XmlFile.SetValue("SingleSettings", "AccountName", AccountName);break;
                case "AutoAnswer": XmlFile.SetValue("SingleSettings", "AutoAnswer", AutoAnswer + "");break;
                case "CFBFlag": XmlFile.SetValue("SingleSettings", "CFBFlag", CFBFlag + "");break;
                case "CFBNumber": XmlFile.SetValue("SingleSettings", "CFBNumber", CFBNumber);break;
                case "CFNRFlag": XmlFile.SetValue("SingleSettings", "CFNRFlag", CFNRFlag + "");break;
                case "CFNRNumber": XmlFile.SetValue("SingleSettings", "CFNRNumber", CFNRNumber);break;
                case "CFUFlag": XmlFile.SetValue("SingleSettings", "CFUFlag", CFUFlag + "");break;
                case "CFUNumber": XmlFile.SetValue("SingleSettings", "CFUNumber", CFUNumber);break;
                case "CodecList": SaveList("CodecList");break;
                case "PhoneBookSearch": SaveList("PhoneBookSearch"); break;
                case "CallRecordsSearch": SaveList("CallRecordsSearch"); break;
                case "DateTimeFormat": XmlFile.SetValue("SingleSettings", "DateTimeFormat", DateTimeFormat);break;
                case "DefaultAccountIndex": XmlFile.SetValue("SingleSettings", "DefaultAccountIndex", DefaultAccountIndex + "");break;
                case "DisplayName": XmlFile.SetValue("SingleSettings", "DisplayName", DisplayName);break;
                case "DNDFlag": XmlFile.SetValue("SingleSettings", "DNDFlag", DNDFlag + "");break;
                case "DomainName": XmlFile.SetValue("SingleSettings", "DomainName", DomainName);break;
                case "pass": XmlFile.SetValue("SingleSettings", "pass", pass);break;
                case "PublishEnabled": XmlFile.SetValue("SingleSettings", "PublishEnabled", PublishEnabled + "");break;
                case "SipHostName": XmlFile.SetValue("SingleSettings", "SipHostName", SipHostName);break;
                case "SipPort": XmlFile.SetValue("SingleSettings", "SipPort", SipPort + "");break;
                case "SipProxy": XmlFile.SetValue("SingleSettings", "SipProxy", SipProxy);break;
                case "TransportMode": XmlFile.SetValue("SingleSettings", "TransportMode", (int)TransportMode + "");break;
                case "UserName": XmlFile.SetValue("SingleSettings", "UserName", UserName);break;
                case "RememberRegistration": XmlFile.SetValue("SingleSettings", "RememberRegistration", RememberRegistration + ""); break;
                case "ECTail": XmlFile.SetValue("SingleSettings", "ECTail", (int)ECTail + ""); break;
                case "Expires": XmlFile.SetValue("SingleSettings", "Expires", (int)Expires + ""); break;
                case "DtmfMode": XmlFile.SetValue("SingleSettings", "DtmfMode", (int)DtmfMode + ""); break;
                case "VADEnabled": XmlFile.SetValue("SingleSettings", "VADEnabled", VADEnabled + ""); break;
                case "SpeakerValue": XmlFile.SetValue("SingleSettings", "SpeakerValue", SpeakerValue + ""); break;
                case "RecordingValue": XmlFile.SetValue("SingleSettings", "RecordingValue", RecordingValue + ""); break;
                case "StunServerAddress": XmlFile.SetValue("SingleSettings", "StunServerAddress", StunServerAddress + ""); break;

                case "ProgramName": XmlFile.SetValue("SingleSettings", "ProgramName", ProgramName + ""); break;
                case "BalanceLink": XmlFile.SetValue("SingleSettings", "BalanceLink", BalanceLink + ""); break;
                case "CreateAccountLink": XmlFile.SetValue("SingleSettings", "CreateAccountLink", CreateAccountLink + ""); break;
                case "ChangePasswordLink": XmlFile.SetValue("SingleSettings", "ChangePasswordLink", ChangePasswordLink + ""); break;
                case "ProfileUserLink": XmlFile.SetValue("SingleSettings", "ProfileUserLink", ProfileUserLink + ""); break;
                case "AutoLogin": XmlFile.SetValue("SingleSettings", "AutoLogin", AutoLogin + ""); break;

                case "ProxyAddress": XmlFile.SetValue("SingleSettings", "ProxyAddress", ProxyAddress + ""); break;
                case "ProxyUserName": XmlFile.SetValue("SingleSettings", "ProxyUserName", ProxyUserName + ""); break;
                case "ProxyPassword": XmlFile.SetValue("SingleSettings", "ProxyPassword", ProxyPassword + ""); break;
                case "ProxyDomain": XmlFile.SetValue("SingleSettings", "ProxyDomain", ProxyDomain + ""); break;
                case "UseProxy": XmlFile.SetValue("SingleSettings", "UseProxy", UseProxy + ""); break;
                case "UseProxyAuthentication": XmlFile.SetValue("SingleSettings", "UseProxyAuthentication", UseProxyAuthentication + ""); break;
                case "LoginUsers": SaveList("LoginUsers"); break;
            }
            XmlFile.SaveDocument();
        }

        public void Save()
        {
            SaveExtendibleVar();
            XmlFile.SetValue("SingleSettings", "AccountId", AccountId);
            XmlFile.SetValue("SingleSettings", "AccountName", AccountName);
            XmlFile.SetValue("SingleSettings", "AutoAnswer", AutoAnswer + "");
            XmlFile.SetValue("SingleSettings", "CFBFlag", CFBFlag + "");
            XmlFile.SetValue("SingleSettings", "CFBNumber", CFBNumber);
            XmlFile.SetValue("SingleSettings", "CFNRFlag", CFNRFlag + "");
            XmlFile.SetValue("SingleSettings", "CFNRNumber", CFNRNumber);
            XmlFile.SetValue("SingleSettings", "CFUFlag", CFUFlag + "");
            XmlFile.SetValue("SingleSettings", "CFUNumber", CFUNumber);
            SaveList("CodecList");
            SaveList("PhoneBookSearch");
            SaveList("CallRecordsSearch");
            XmlFile.SetValue("SingleSettings", "DateTimeFormat", DateTimeFormat);
            XmlFile.SetValue("SingleSettings", "DefaultAccountIndex", DefaultAccountIndex + "");
            XmlFile.SetValue("SingleSettings", "DisplayName", DisplayName);
            XmlFile.SetValue("SingleSettings", "DNDFlag", DNDFlag + "");
            XmlFile.SetValue("SingleSettings", "DomainName", DomainName);
            XmlFile.SetValue("SingleSettings", "pass", pass);
            XmlFile.SetValue("SingleSettings", "PublishEnabled", PublishEnabled + "");
            XmlFile.SetValue("SingleSettings", "SipHostName", SipHostName);
            XmlFile.SetValue("SingleSettings", "SipPort", SipPort + "");
            XmlFile.SetValue("SingleSettings", "SipProxy", SipProxy);
            XmlFile.SetValue("SingleSettings", "TransportMode", (int)TransportMode + "");
            XmlFile.SetValue("SingleSettings", "UserName", UserName);
            XmlFile.SetValue("SingleSettings", "RememberRegistration", RememberRegistration + "");

            XmlFile.SetValue("SingleSettings", "ECTail", (int)ECTail + "");
            XmlFile.SetValue("SingleSettings", "Expires", (int)Expires + "");
            XmlFile.SetValue("SingleSettings", "DtmfMode", (int)DtmfMode + "");
            XmlFile.SetValue("SingleSettings", "VADEnabled", VADEnabled + "");
            XmlFile.SetValue("SingleSettings", "SpeakerValue", SpeakerValue + "");
            XmlFile.SetValue("SingleSettings", "RecordingValue", RecordingValue + "");
            XmlFile.SetValue("SingleSettings", "StunServerAddress", StunServerAddress + "");
            XmlFile.SetValue("SingleSettings", "ProgramName", ProgramName + "");
            XmlFile.SetValue("SingleSettings", "BalanceLink", BalanceLink + "");
            XmlFile.SetValue("SingleSettings", "CreateAccountLink", CreateAccountLink + "");
            XmlFile.SetValue("SingleSettings", "ChangePasswordLink", ChangePasswordLink + "");
            XmlFile.SetValue("SingleSettings", "ProfileUserLink", ProfileUserLink + "");
            XmlFile.SetValue("SingleSettings", "AutoLogin", AutoLogin + "");

            XmlFile.SetValue("SingleSettings", "ProxyAddress", ProxyAddress + "");
            XmlFile.SetValue("SingleSettings", "ProxyUserName", ProxyUserName + "");
            XmlFile.SetValue("SingleSettings", "ProxyPassword", ProxyPassword + "");
            XmlFile.SetValue("SingleSettings", "ProxyDomain", ProxyDomain + "");
            XmlFile.SetValue("SingleSettings", "UseProxy", UseProxy + "");
            XmlFile.SetValue("SingleSettings", "UseProxyAuthentication", UseProxyAuthentication + "");
            SaveList("LoginUsers");
            XmlFile.SaveDocument();
        }
        
    }
}
