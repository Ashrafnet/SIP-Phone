using System;
using System.Collections.Generic;
using System.Text;
using Softphone.Properties;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.SIPCore;
using System.Collections.Specialized;
using Softphone.SettingFolder;
using Softphone.ConfigFolder;

namespace Softphone.ConfigFolder
{
  internal class PhoneConfig : IConfiguratorInterface
  {
      private static PhoneConfig _Instance;
      public static PhoneConfig Instance
      {
          get
          {
              if (_Instance == null) _Instance = new PhoneConfig();
              return _Instance;
          }
      }

    List<IAccount> _acclist = new List<IAccount>();

    private PhoneConfig()
    {
      _acclist.Add(new AccountConfig());
      ECTail = ECTail;
      Expires = Expires;
      StunServerAddress = StunServerAddress;
      VADEnabled = VADEnabled;
    }

    #region IConfiguratorInterface Members

    public bool AutoAnswer
    {
        get { return Settings.Default.AutoAnswer; }
        set { Settings.Default.AutoAnswer = value; }
    }

    public List<IAccount> Accounts
    {
        get { return _acclist; }
    }


    public bool CFBFlag
    {
        get {  return Settings.Default.CFBFlag; }
        set { Settings.Default.CFBFlag = value; }
    }

    public string CFBNumber
    {
        get { return Settings.Default.CFBNumber; }
        set { Settings.Default.CFBNumber = value; }
    }

    public bool CFNRFlag
    {
        get { return Settings.Default.CFNRFlag; }
        set { Settings.Default.CFNRFlag = value; }
    }

    public string CFNRNumber
    {
        get { return Settings.Default.CFNRNumber; }
        set { Settings.Default.CFNRNumber = value; }
    }

    public bool CFUFlag
    {
        get { return Settings.Default.CFUFlag; }
        set { Settings.Default.CFUFlag = value; }
    }

    public string CFUNumber
    {
        get { return Settings.Default.CFUNumber; }
        set { Settings.Default.CFUNumber = value; }
    }
    public StringCollection CodecList
    {
        get
        {
            return Settings.Default.CodecList;
        }
        set
        {
            Settings.Default.CodecList = value;
        }
    }

    public bool DNDFlag
    {
        get { return Settings.Default.DNDFlag; }
        set { Settings.Default.DNDFlag = value; }
    }

    public int DefaultAccountIndex
    {
        get { return Settings.Default.DefaultAccountIndex; }
        set { Settings.Default.DefaultAccountIndex = value; }
    }

    public bool IsNull
    {
      get { return false; }
    }

    public bool PublishEnabled
    {
        get { return Settings.Default.PublishEnabled; }
        set { Settings.Default.PublishEnabled = value; }
    }

    public int SIPPort
    {
        get { return Settings.Default.SipPort; }
        set { Settings.Default.SipPort = value; }
    }

    public int ECTail
    {
        get { return Settings.Default.ECTail; }
        set 
        { 
            Settings.Default.ECTail = value;
            SipConfigStruct.Instance.ECTail = value;
        }
    }

      /// <summary>
    /// The RegistrationTimeout
      /// </summary>
    public int Expires
    {
        get
        {
            SipConfigStruct.Instance.expires = Settings.Default.Expires; 
            return Settings.Default.Expires; }
        set 
        {
            SipConfigStruct.Instance.expires = value; 
            Settings.Default.Expires = value; 
        }
    }

    public EDtmfMode DtmfMode
    {
        get { return Settings.Default.DtmfMode; }
        set { Settings.Default.DtmfMode = value; }
    }
      /// <summary>
    /// Voice Activity Detection
      /// </summary>
    public bool VADEnabled
    {
        get { return Settings.Default.VADEnabled; }
        set 
        {
            Settings.Default.VADEnabled = value;
            SipConfigStruct.Instance.VADEnabled = value;
        }
    }

    public string StunServerAddress
    {
        get { return Settings.Default.StunServerAddress; }
        set 
        { 
            Settings.Default.StunServerAddress = value;
            SipConfigStruct.Instance.stunServer = value;
        }
    }
    public void Save()
    {
        
        Settings.Default.Save();
    }
     
    #endregion
  }

  
}
