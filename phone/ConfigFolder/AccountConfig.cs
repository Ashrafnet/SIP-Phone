using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.SIPCore;
using Softphone.SettingFolder;

namespace Softphone.ConfigFolder
{
    public class AccountConfig : IAccount
    {
        #region IAccount Members

        public string AccountName
        {
            get { return Settings.Default.AccountName; }
            set { Settings.Default.AccountName = value; }
        }

        public string DisplayName
        {
            get { return Settings.Default.DisplayName; }
            set { Settings.Default.DisplayName = value; }
        }

        public string DomainName
        {
            get { return Settings.Default.DomainName; }
            set { Settings.Default.DomainName = value; }
        }

        public string HostName
        {
            get { return Settings.Default.SipHostName; }
            set { Settings.Default.SipHostName = value; }
        }

        public string Id
        {
            get { return Settings.Default.AccountId; }
            set { Settings.Default.AccountId = value; }
        }

        public int Index
        {
            get
            {
                return 0;
            }
            set { }
        }

        public string Password
        {
            get { return FactoryManger.Instance.DecryptPlianText( Settings.Default.pass); }
            set {  Settings.Default.pass =FactoryManger.Instance.EncryptPlianText( value); }
        }

        public string ProxyAddress
        {
            get { return Settings.Default.SipProxy; }
            set { Settings.Default.SipProxy = value; }
        }

        public int RegState
        {
            get
            {
                return 0;
            }
            set { }
        }

        public ETransportMode TransportMode
        {
            get { return Settings.Default.TransportMode; }
            set { Settings.Default.TransportMode = value; }
        }

        public string UserName
        {
            get { return Settings.Default.UserName; }
            set { Settings.Default.UserName = value; }
        }

        public bool Enabled
        {
            get
            {
                return true;
            }
            set
            {

            }
        }

        public bool IsLoggedin { get; set; }
        #endregion

    }
}
