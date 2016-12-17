using System;
using System.Collections.Generic;

using System.Text;
using SIPProvider.SIPCore.Interfaces;

namespace SIPProvider.SIPCore
{
    public class pjsipPresenceAndMessaging
    {
        #region Events
        /// <summary>
        /// Buddy status changed notifier
        /// </summary>
        public event DBuddyStatusChanged BuddyStatusChanged;
        /// <summary>
        /// Message received notifier
        /// </summary>
        public event DMessageReceived MessageReceived;
        #endregion

        #region Constructor
        private static pjsipPresenceAndMessaging _instance = null;
        public static pjsipPresenceAndMessaging Instance
        {
            get
            {
                if (_instance == null) _instance = new pjsipPresenceAndMessaging();
                return _instance;
            }
        }
        static OnMessageReceivedCallback mrdel = new OnMessageReceivedCallback(onMessageReceived);
        static OnBuddyStatusChangedCallback bscdel = new OnBuddyStatusChangedCallback(onBuddyStatusChanged);

        private pjsipPresenceAndMessaging()
        {
            PjsipMethods.onBuddyStatusChangedCallback(bscdel);
            PjsipMethods.onMessageReceivedCallback(mrdel);
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

        #region Public Methods

        /// <summary>
        /// Add new entry in a buddy list and subscribe presence
        /// </summary>
        /// <param name="ident">Buddy address (without hostname part</param>
        /// <param name="presence">subscribe presence flag</param>
        /// <returns></returns>
        public int addBuddy(string name, bool presence, int accId)
        {
            string sipuri = "";

            if (!pjsipStackProxy.Instance.IsInitialized) return -1;

            // check if name contains URI
            if (name.IndexOf("sip:") == 0)
            {
                // do nothing...
                sipuri = name;
            }
            else
            {
                sipuri = "sip:" + name + "@" + Config.Accounts[accId].HostName;
            }
            // check transport - if TCP add transport=TCP
            sipuri = pjsipStackProxy.Instance.SetTransport(accId, sipuri);

            return PjsipMethods.dll_addBuddy(sipuri, presence);
        }

        /// <summary>
        /// Add buddy to buddy list and subscribe presence
        /// </summary>
        /// <param name="ident">Buddy identification</param>
        /// <param name="presence">Flag if buddy is to subscribe sip presence</param>
        /// <returns></returns>
        public int addBuddy(string ident, bool presence)
        {
            return this.addBuddy(ident, presence, Config.DefaultAccountIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buddyId"></param>
        /// <returns></returns>
        public int delBuddy(int buddyId)
        {
            return PjsipMethods.dll_removeBuddy(buddyId);
        }

        /// <summary>
        /// Send an instance message
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int sendMessage(string destAddress, string message, int accId)
        {
            if (!pjsipStackProxy.Instance.IsInitialized) return -1;

            string sipuri = "";

            // check if name contains URI
            if (destAddress.IndexOf("sip:") == 0)
            {
                // do nothing...
                sipuri = destAddress;
            }
            else
            {
                sipuri = "sip:" + destAddress + "@" + Config.Accounts[accId].HostName;
            }
            // set transport
            sipuri = pjsipStackProxy.Instance.SetTransport(accId, sipuri);

            return PjsipMethods.dll_sendMessage(Config.Accounts[accId].Index, sipuri, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int sendMessage(string destAddress, string message)
        {
            return sendMessage(destAddress, message, Config.Accounts[Config.DefaultAccountIndex].Index);
        }

        /// <summary>
        /// Set presence status
        /// </summary>
        /// <param name="accId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int setStatus(int accId, EUserStatus status)
        {
            if ((!pjsipStackProxy.Instance.IsInitialized) || (accId < 0)) return -1;

            if ((Config.Accounts.Count > 0) && (Config.Accounts[accId].RegState != 200)) return -1;
            if (!Config.PublishEnabled) return -1;

            return PjsipMethods.dll_setStatus(Config.Accounts[accId].Index, (int)status);
        }

        #endregion

        #region protected Methods
        /// <summary>
        /// MessageReceived event trigger by VoIP stack when instant message arrived
        /// </summary>
        protected void BaseMessageReceived(string from, string text)
        {
            if (MessageReceived != null) MessageReceived(from, text);
        }
        /// <summary>
        /// BuddyStatusChanged event trigger by VoIP stack when buddy status changed
        /// </summary>
        protected void BaseBuddyStatusChanged(int buddyId, int status, string text)
        {
            if (null != BuddyStatusChanged) BuddyStatusChanged(buddyId, status, text);
        }
        #endregion

        #region Callbacks
        private static int onMessageReceived(string from, string text)
        {
            Instance.BaseMessageReceived(from.ToString(), text.ToString());
            return 1;
        }

        private static int onBuddyStatusChanged(int buddyId, int status, string text)
        {
            Instance.BaseBuddyStatusChanged(buddyId, status, text.ToString());
            return 1;
        }
        #endregion
    }
}
