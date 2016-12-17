using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using SIPProvider.SIPCore;
using System.Windows.Forms;

namespace Softphone.SettingFolder
{
    public class DefultSettings : ISettings
    {
        public DefultSettings()
        {
            ExtendibleVar = new Dictionary<string, string>();
            LoadDefultSettings();
        }

        private static ISettings _Default;
        public static ISettings Default
        {
            get
            {
                if (_Default == null) _Default = new DefultSettings();
                return _Default;
            }
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
            AccountId = "myId";
            AccountName = "Acount";
            AutoAnswer = false;
            CFBFlag = false;
            CFBNumber = "";
            CFNRFlag = false;
            CFNRNumber = "";
            CFUFlag = false;
            CFUNumber = "";
            CodecList = new StringCollection();
            CodecList.AddRange(new string[]{
            "G729/8000/1",
            "G711 uLaw",
            "G711 aLaw",
            "GSM/8000/1",
            "iLBC/8000/1",
            "G722/16000/1",
            "speex/8000/1",
            "speex/16000/1",
            "speex/32000/1",
            "L16/16000/1",
            });
            PhoneBookSearch = new StringCollection();
            CallRecordsSearch = new StringCollection();
            DateTimeFormat = "ddd, MMM dd, yy HH:mm";
            DefaultAccountIndex = 0;
            DisplayName = "Acount";
            DNDFlag = false;
            DomainName = "*";
            pass = "";
            PublishEnabled = false;
            SipHostName = "sip.nogafone.com";
           // SipHostName = "localhost";
            SipPort = 5090;
            SipProxy = "sip.nogafone.com";
            TransportMode = ETransportMode.TM_TCP      ;
            UserName = "";
            RememberRegistration = false;

            ECTail = 256;
            Expires = 1200;
            DtmfMode = EDtmfMode.DM_Inband;

            VADEnabled = false;
            SpeakerValue = 50;
            RecordingValue = 50;
            StunServerAddress = "";

            ProgramName = "NogaFone";
            BalanceLink = "http://www.nogafone.com/softrecharge.asp";
            CreateAccountLink = "";
            ChangePasswordLink = "";
            ProfileUserLink = "";
            AutoLogin = false;

            ProxyAddress = "";
            ProxyUserName = "";
            ProxyPassword = "";
            ProxyDomain = "";
            UseProxy = false;
            UseProxyAuthentication = false;
            LoginUsers = new StringCollection();
        }

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
                case "RememberRegistration": return RememberRegistration;
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


        public virtual object this[string valueName]
        {
            get
            {
                return GetValue(valueName);
            }
            set
            {
                //Not implemented
            }
        }
        public void Save() { }
        public void Save(string valueName) { }

    }
}
