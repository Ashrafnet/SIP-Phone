using System;
using System.Collections.Generic;

using System.Text;
using SIPProvider.SIPCore.Interfaces;
using System.Collections.Specialized;

namespace SIPProvider.SIPCore
{
    /// <summary>
    /// Implementation of SIP interface using pjsip.org SIP stack.
    /// This proxy is used for sip stack initialization and shut down, registration, and 
    /// callback methods handling.
    /// </summary>
    public class pjsipStackProxy : IVoipProxy
    {
        #region Constructor

        private static pjsipStackProxy _instance = null;

        public static pjsipStackProxy Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new pjsipStackProxy();
                }
                return _instance;
            }
        }

        protected pjsipStackProxy()
        {
        }
        #endregion

        #region Properties

        private bool _initialized = false;
        public override bool IsInitialized
        {
            get { return _initialized; }
            set { _initialized = value; }
        }
        #endregion

     
        static OnDtmfDigitCallback dtdel = new OnDtmfDigitCallback(onDtmfDigitCallback);
        static OnMessageWaitingCallback mwidel = new OnMessageWaitingCallback(onMessageWaitingCallback);
        //static OnCallReplacedCallback crepdel = new OnCallReplacedCallback(onCallReplacedCallback);

        #region Variables

        // config structure (used for special configuration options)
        public SipConfigStruct ConfigMore = SipConfigStruct.Instance;

        #endregion Variables

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int start()
        {
            int status = -1;

            // prepare configuration struct
            // read data from Config interface. If null read all values directly from SipConfigMore
            if (!Config.IsNull)
            {
                ConfigMore.listenPort = Config.SIPPort;
            }

            PjsipMethods.dll_setSipConfig(ConfigMore);
            status = PjsipMethods.dll_init();

            if (status != 0) return status;

            status |= PjsipMethods.dll_main();

            return status;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Initialize pjsip stack
        /// </summary>
        /// <returns></returns>
        public override int initialize()
        {
            // shutdown if started already
            shutdown();

            // register callbacks (delegates)
            PjsipMethods.onDtmfDigitCallback(dtdel);
            PjsipMethods.onMessageWaitingCallback(mwidel);
            //PjsipMethods.onCallReplacedCallback(crepdel);

            // init call proxy (callbacks)
            pjsipCallProxy.initialize();

            // Initialize pjsip...
            int status = start();
            // set initialized flag
            IsInitialized = (status == 0) ? true : false;

            return status;
        }

        /// <summary>
        /// Shutdown pjsip stack
        /// </summary>
        /// <returns></returns>
        public override int shutdown()
        {
            //if (!IsInitialized) return -1;

            return PjsipMethods.dll_shutdown();
        }

        /// <summary>
        /// Get codec by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override string getCodec(int index)
        {
            if (!IsInitialized) return "";

            StringBuilder codec = new StringBuilder(256);
            PjsipMethods.dll_getCodec(index, codec);
            return (codec.ToString());
        }

        /// <summary>
        /// Get number of all codecs
        /// </summary>
        /// <returns></returns>
        public override int getNoOfCodecs()
        {
            if (!IsInitialized) return 0;

            int no = PjsipMethods.dll_getNumOfCodecs();
            return no;
        }

        public StringCollection getAllCodecs()
        {
            StringCollection codecs = new StringCollection();
            int n =getNoOfCodecs();
            for (int i = 0; i < n; i++)
                codecs.Add(getCodec(i));
            return codecs;
        }
        /// <summary>
        /// Set codec priority
        /// </summary>
        /// <param name="codecname"></param>
        /// <param name="priority"></param>
        public override void setCodecPriority(string codecname, int priority)
        {
            if (!IsInitialized) return;

            PjsipMethods.dll_setCodecPriority(codecname, priority);
        }

        /// <summary>
        /// Call proxy factory method
        /// </summary>
        /// <returns></returns>
        public override ICallProxyInterface createCallProxy()
        {
            return new pjsipCallProxy(Config);
        }


        /// <summary>
        /// Set sound device for playback and recording
        /// </summary>
        /// <param name="deviceId"></param>
        public void setSoundDevice(string playbackDeviceId, string recordingDeviceId)
        {
            int status = PjsipMethods.dll_setSoundDevice(playbackDeviceId, recordingDeviceId);

        }


        #endregion Methods

        #region Callbacks


        //////////////////////////////////////////////////////////////////////////////////

        private static int onDtmfDigitCallback(int callId, int digit)
        {
            Instance.BaseDtmfDigitReceived(callId, digit);
            return 1;
        }

        private static int onMessageWaitingCallback(int mwi, string info)
        {
            if (null == info) return -1;
            Instance.BaseMessageWaitingIndication(mwi, info.ToString());
            return 1;
        }

        private static int onCallReplacedCallback(int oldid, int newid)
        {
            Instance.BaseCallReplacedCallback(oldid, newid);
            return 1;
        }

        #endregion Callbacks

        #region Utility Methods
        internal string SetTransport(int accountId, string sipuri)
        {
            string temp = sipuri;

            try
            {
                // set transport mode
                switch (Config.Accounts[accountId].TransportMode)
                {
                    case ETransportMode.TM_TCP:
                        temp = sipuri + ";transport=tcp";
                        break;
                    case ETransportMode.TM_TLS:
                        temp = sipuri + ";transport=tls";
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            return temp;
        }
        #endregion

    }
}
