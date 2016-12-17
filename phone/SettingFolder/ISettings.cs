using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using SIPProvider.SIPCore;
using System.Windows.Forms;

namespace Softphone.SettingFolder
{
   public interface ISettings
    {
        Dictionary<string, string> ExtendibleVar { get; set; }
        string AccountId { get; set; }
        string AccountName { get; set; }
        bool AutoAnswer { get; set; }
        bool CFBFlag { get; set; }
        string CFBNumber { get; set; }
        bool CFNRFlag { get; set; }
        string CFNRNumber { get; set; }
        bool CFUFlag { get; set; }
        string CFUNumber { get; set; }
        StringCollection CodecList { get; set; }
        StringCollection PhoneBookSearch { get; set; }
        StringCollection CallRecordsSearch { get; set; }
        StringCollection LoginUsers { get; set; }
        string DateTimeFormat { get; set; }
        int DefaultAccountIndex { get; set; }
        string DisplayName { get; set; }
        bool DNDFlag { get; set; }
        string DomainName { get; set; }
        string pass { get; set; }
        bool PublishEnabled { get; set; }
        string SipHostName { get; set; }
        int SipPort { get; set; }
        string SipProxy { get; set; }
        ETransportMode TransportMode { get; set; }
        string UserName { get; set; }
        bool RememberRegistration { get; set; }
        object this[string valueName] { get; set; }
        int ECTail { get; set; }
        int Expires { get; set; }
        EDtmfMode DtmfMode { get; set; }
        bool VADEnabled { get; set; }
        int SpeakerValue { get; set; }
        int RecordingValue { get; set; }
        string StunServerAddress { get; set; }
        string ProgramName { get; set; }
        string BalanceLink { get; set; }
        string CreateAccountLink { get; set; }
        string ChangePasswordLink { get; set; }
        string ProfileUserLink { get; set; }
        bool AutoLogin { get; set; }
        string ProxyAddress { get; set; }
        string ProxyUserName { get; set; }
        string ProxyPassword { get; set; }
        string ProxyDomain { get; set; }
        bool UseProxy { get; set; }
        bool UseProxyAuthentication { get; set; }
       /// <summary>
       /// Save all values
       /// </summary>
         void Save();
       /// <summary>
       /// Save only this value
       /// </summary>
       /// <param name="valueName"></param>
         void Save(string valueName);
    }

}
