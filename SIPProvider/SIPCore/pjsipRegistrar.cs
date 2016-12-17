using System;
using System.Collections.Generic;

using System.Text;
using SIPProvider.SIPCore.Interfaces;

namespace SIPProvider.SIPCore
{
    public class pjsipRegistrar
    {
        #region Events
        /// <summary>
        /// Event AccountStateChanged informs clients about account state changed
        /// </summary>
        public event DAccountStateChanged AccountStateChanged;

        /// <summary>
        /// AccountStateChanged event trigger by VoIP stack when registration state changed
        /// </summary>
        protected void BaseAccountStateChanged(int accountId, int accState)
        {
            if (null != AccountStateChanged) AccountStateChanged(accountId, accState);
        }
        #endregion
        #region Properties
        private IConfiguratorInterface _config;
        public IConfiguratorInterface Config
        {
            get
            {
                return _config;
            }
            set
            {
                _config = value;
            }
        }
        #endregion


        #region Constructor
        static private pjsipRegistrar _instance = null;
        static public pjsipRegistrar Instance
        {
            get
            {
                if (_instance == null) _instance = new pjsipRegistrar();
                return _instance;
            }
        }
        static OnRegStateChanged rsDel = new OnRegStateChanged(onRegStateChanged);
        private pjsipRegistrar()
        {
            PjsipMethods.onRegStateCallback(rsDel);
        }
        #endregion

        #region Public methods
        /////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Register all configured accounts 
        /// </summary>
        /// <returns></returns>
        public int registerAccounts()
        {
            if (!pjsipStackProxy.Instance.IsInitialized) return -1;

            if (Config.Accounts.Count <= 0) return 0;

            // unregister accounts
            PjsipMethods.dll_removeAccounts();

            // iterate all accounts
            for (int i = 0; i < Config.Accounts.Count; i++)
            {
                IAccount acc = Config.Accounts[i];
                // check if accounts available
                if (null == acc) return -1;

                // reset account Index field
                Config.Accounts[i].Index = -1;
                // reset account state
                Config.Accounts[i].RegState = -1;

                if (acc.Enabled && (acc.Id.Length > 0) && (acc.HostName.Length > 0))
                {

                    string displayName = acc.DisplayName;
                    // warning:::Publish do not work if display name in uri !!!
                    string uri = "sip:" + acc.UserName;
                    if (acc.UserName.IndexOf("@") < 0)
                    {
                        uri += "@" + acc.HostName;
                    }
                    string reguri = "sip:" + acc.HostName;
                    // check transport - if TCP add transport=TCP
                    reguri = pjsipStackProxy.Instance.SetTransport(i, reguri);

                    string domain = acc.DomainName;
                    string username = acc.UserName;
                    string password = acc.Password;

                    string proxy = "";
                    if (acc.ProxyAddress.Length > 0)
                    {
                        proxy = "sip:" + acc.ProxyAddress;
                    }

                    int accId = PjsipMethods.dll_registerAccount(uri, reguri, domain, username, password, proxy, (i == Config.DefaultAccountIndex ? true : false));

                    // store account Id to Index field
                    Config.Accounts[i].Index = accId;
                }
                else
                {
                    // trigger callback
                    BaseAccountStateChanged(i, -1);
                }
            }
            return 1;
        }

        /// <summary>
        /// Unregister all accounts
        /// </summary>
        /// <returns></returns>
        public int unregisterAccounts()
        {
            try
            {
                return PjsipMethods.dll_removeAccounts();
            }
            catch { return 0; }
        }

        /// <summary>
        /// Reception of on registration state change events. First account Id should be mapped to 
        /// account configuration sequence number.
        /// </summary>
        /// <param name="accId"></param>
        /// <param name="regState"></param>
        /// <returns></returns>
        private static int onRegStateChanged(int accId, int regState)
        {
            // first map account index
            for (int i = 0; i < Instance.Config.Accounts.Count; i++)
            {
                IAccount account = Instance.Config.Accounts[i];
                if (account.Index == accId)
                {
                    Instance.Config.Accounts[i].RegState = regState;
                    Instance.BaseAccountStateChanged(i, regState);
                    return 1;
                }
            }
            // should be here!
            return -1;
        }
        #endregion
    }
}
