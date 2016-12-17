using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.SIPCore;
using System.Collections.Specialized;

namespace SIPProvider.NullValues
{
    internal class NullConfigurator : IConfiguratorInterface
    {
        public NullConfigurator()
        {
            // add 1 account
            //_accountList.Add(new NullAccount());
        }

        public class NullAccount : IAccount
        {
            
            public bool IsLoggedin { get; set; }
            public bool Enabled { get { return false; } set { } }

            public int Index
            {
                get { return 0; }
                set { }
            }


            public string AccountName
            {
                get { return ""; }
                set { }
            }

            public string HostName
            {
                get { return ""; }
                set { }
            }

            public string Id
            {
                get { return ""; }
                set { }
            }

            public string UserName
            {
                get { return ""; }
                set { }
            }

            public string Password
            {
                get { return ""; }
                set { }
            }

            public string DisplayName
            {
                get { return ""; }
                set { }
            }

            public string DomainName
            {
                get { return ""; }
                set { }
            }

            public int Port
            {
                get { return 0; }
                set { }
            }

            public int RegState
            {
                get { return 0; }
                set { }
            }

            public string ProxyAddress
            {
                get { return ""; }
                set { }
            }

            public ETransportMode TransportMode { get { return ETransportMode.TM_UDP; } set { } }
        }

        
        #region IConfiguratorInterface Properties
        public EDtmfMode DtmfMode { get; set; }
        List<IAccount> _accountList = new List<IAccount>();

        public bool IsNull { get { return true; } }

        public bool CFUFlag
        {
            get { return false; }
            set { }
        }

        public string CFUNumber
        {
            get { return ""; }
            set { }
        }

        public bool CFNRFlag
        {
            get { return false; }
            set { }
        }

        public string CFNRNumber
        {
            get { return ""; }
            set { }
        }

        public bool CFBFlag
        {
            get { return false; }
            set { }
        }

        public string CFBNumber
        {
            get { return ""; }
            set { }
        }

        public bool DNDFlag
        {
            get { return false; }
            set { }
        }

        public bool AutoAnswer
        {
            get { return false; }
            set { }
        }
        public int SIPPort
        {
            get { return 5060; }
            set { }
        }
        public int DefaultAccountIndex
        {
            get { return 0; }
            set { }
        }

        public bool PublishEnabled
        {
            get { return true; }
            set { }
        }

        public List<IAccount> Accounts
        {
            get { return _accountList; }
        }

        public void Save()
        { }

        public StringCollection CodecList { get { return null; } set { } }
        public string StunServerAddress { get; set; }
        #endregion
    }
}
