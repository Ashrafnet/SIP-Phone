using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.NullValues;

namespace SIPProvider.SIPCore.Interfaces
{
    /// <summary>
    /// VoIP protocol stack interface. Defines some common events invoked by VoIP stack and 
    /// API methods invoked by user.
    /// </summary>
    public abstract class IVoipProxy
    {
        #region Events

        /// <summary>
        /// User Events. A protected virtual method makes possible to invoke events from derived classes. 
        /// </summary>

        /// <summary>
        /// DtmfDigitReceived event trigger by VoIP stack when DTMF is detected 
        /// </summary>
        public event DDtmfDigitReceived DtmfDigitReceived;
        protected void BaseDtmfDigitReceived(int callId, int digit)
        {
            if (null != DtmfDigitReceived) DtmfDigitReceived(callId, digit);
        }
        /// <summary>
        /// MessageWaitingIndication event trigger by VoIP stack when MWI indication arrived 
        /// </summary>
        public event DMessageWaitingNotification MessageWaitingIndication;
        protected void BaseMessageWaitingIndication(int mwi, string text)
        {
            if (null != MessageWaitingIndication) MessageWaitingIndication(mwi, text);
        }

        /// <summary>
        /// Notification that call is being replaced.
        /// </summary>
        public event DCallReplaced CallReplaced;
        protected void BaseCallReplacedCallback(int oldid, int newid)
        {
            if (null != CallReplaced) CallReplaced(oldid, newid);
        }

        #endregion events

        #region Properties

        private IConfiguratorInterface _config = new NullConfigurator();
        public IConfiguratorInterface Config
        {
            set { _config = value; }
            get { return _config; }
        }

        /// <summary>
        /// Flag indicating stack initialization status
        /// </summary>
        public abstract bool IsInitialized
        {
            get;
            set;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Initialize VoIP stack
        /// </summary>
        /// <returns></returns>
        public abstract int initialize();

        /// <summary>
        /// Shutdown VoIP stack
        /// </summary>
        /// <returns></returns>
        public virtual int shutdown()
        {
            DtmfDigitReceived = null;
            MessageWaitingIndication = null;
            return 1;
        }

        /// <summary>
        /// Set codec priority
        /// </summary>
        /// <param name="item">Codec Name</param>
        /// <param name="p">priority</param>
        public abstract void setCodecPriority(string item, int p);

        /// <summary>
        /// Get number of codecs in list
        /// </summary>
        /// <returns>Number of codecs</returns>
        public abstract int getNoOfCodecs();

        /// <summary>
        /// Get codec by index
        /// </summary>
        /// <param name="i">codec index</param>
        /// <returns>Codec Name</returns>
        public abstract string getCodec(int i);

        /// <summary>
        /// Creates an instance of call proxy 
        /// </summary>
        /// <returns></returns>
        public abstract ICallProxyInterface createCallProxy();

        #endregion
    }
}
