using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.Common;
using SIPProvider.SIPCore;
using Softphone.ConfigFolder;
using SIPProvider.SIPCore.Interfaces;
using Softphone.MediaFolder;
using System.Windows.Forms;
using SIPProvider.CallRecords;

namespace Softphone
{
    public class FactoryManger
    {

        public FactoryManger()
        {
            // register callbacks
            CCallManager.Instance.CallStateRefresh += new DCallStateRefresh(CallManager_CallStateRefresh);
            pjsipRegistrar.Instance.AccountStateChanged += new DAccountStateChanged(Instance_AccountStateChanged);
            CCallManager.Instance.IncomingCallNotification += new DIncomingCallNotification(CallManager_IncomingCallNotification);

            // Inject VoIP stack engine to CallManager
            CCallManager.Instance.StackProxy = pjsipStackProxy.Instance;

            //SipConfigStruct.Instance.expires = PhoneConfig.Instance.Expires;
            //SipConfigStruct.Instance.VADEnabled = PhoneConfig.Instance.VADEnabled;
            //SipConfigStruct.Instance.ECTail = PhoneConfig.Instance.ECTail;

            CCallManager.Instance.MediaProxy = new CMediaPlayerProxy();

            // Inject configuration settings 
            CCallManager.Instance.Config = PhoneConfig.Instance;
            pjsipStackProxy.Instance.Config = PhoneConfig.Instance;
            pjsipRegistrar.Instance.Config = PhoneConfig.Instance;

            CallLoger.Instance.Container = MainForm.Instance;
            CallLoger.Instance.Container = MainForm.Instance;

            OnRegistrationUpdate += new DAccountStateChanged(FactoryManger_OnRegistrationUpdate);
            OnStateUpdate += new DCallStateRefresh(FactoryManger_OnStateUpdate);
        }

        void FactoryManger_OnStateUpdate(int sessionId)
        {
            MainForm.Instance.Cursor = Cursors.Default;
        }



        public void SetCodec()
        {
            int i = 0;
            foreach (string item in pjsipStackProxy.Instance.getAllCodecs())
            {
                pjsipStackProxy.Instance.setCodecPriority(item, 0);
            }
            foreach (string item in PhoneConfig.Instance.CodecList)
            {

                pjsipStackProxy.Instance.setCodecPriority(item, 128 - i);
                i++;

            }
        }
        #region Properties
        private static FactoryManger _instance = null;
        public static FactoryManger Instance
        {
            get
            {
                if (_instance == null) _instance = new FactoryManger();
                return _instance;
            }
        }

        #endregion

        #region Events
        /// <summary>
        /// Occurs when new call income
        /// </summary>
        public event DIncomingCallNotification OnIncomingCallNotification;
        /// <summary>
        /// Occurs when register state change
        /// </summary>
        public event DAccountStateChanged OnRegistrationUpdate;
        /// <summary>
        /// Occurs when call state change
        /// </summary>
        public event DCallStateRefresh OnStateUpdate;
        /// <summary>
        /// Occurs when Balance Loaded from web site
        /// This Event rise when use RequestGetBalance method
        /// </summary>
        public event BalanceLoad OnBalanceLoad;
        /// <summary>
        /// Occurs when start try connect to SIP server
        /// </summary>
        public event Regestering OnRegestering;

        #endregion

        #region Callbacks

        void CallManager_IncomingCallNotification(int sessionId, string number, string info)
        {
            try
            {
                if (OnIncomingCallNotification == null) return;
                // MUST synchronize threads
                if (MainForm.Instance.InvokeRequired)
                    MainForm.Instance.BeginInvoke(new DIncomingCallNotification(OnIncomingCallNotification), new object[] { sessionId, number, info });
                else
                    OnIncomingCallNotification(sessionId, number, info);
            }
            catch { }
        }

        void Instance_AccountStateChanged(int accountId, int accState)
        {
            try
            {
                if (OnRegistrationUpdate == null) return;
                // MUST synchronize threads
                if (MainForm.Instance.InvokeRequired)
                    MainForm.Instance.BeginInvoke(new DAccountStateChanged(OnRegistrationUpdate), new object[] { accountId, accState });
                else
                    OnRegistrationUpdate(accountId, accState);
            }
            catch { }
        }


        void CallManager_CallStateRefresh(int sessionId)
        {
            try
            {
                if (OnStateUpdate == null) return;
                // MUST synchronize threads
                if (MainForm.Instance.InvokeRequired)
                    MainForm.Instance.BeginInvoke(new DCallStateRefresh(OnStateUpdate), new object[] { sessionId });
                else
                    OnStateUpdate(sessionId);
            }
            catch { }
        }
        System.Threading.Thread threadBalance;
        /// <summary>
        /// When complete get Balance the event OnBalanceLoad rises
        /// </summary>
        public void RequestGetBalance()
        {
            try
            {
                threadBalance = new System.Threading.Thread(_GetBalance);
                threadBalance.Start();
            }
            catch { }
        }
        public void AbortRequestGetBalance()
        {
            try { threadBalance.Abort(); }
            catch { }
        }
        void _GetBalance()
        {
            
            try
            {
                if (OnBalanceLoad == null) return;
                System.Net.WebClient x = new System.Net.WebClient();
                x.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                string Balance = x.DownloadString("https://sip.nogafone.com/noga/credit.php?username=" + PhoneConfig.Instance.Accounts[0].UserName + "&password=" + PhoneConfig.Instance.Accounts[0].Password + "");
                Balance = Balance.Replace(',', '.'); Balance = Balance.Replace("\\", "");
                //  string Balance = x.DownloadString(Settings.Default.BalanceLink + "?username=" + PhoneConfig.Instance.Accounts[0].UserName + "&password=" + PhoneConfig.Instance.Accounts[0].Password + "");
                if (MainForm.Instance.InvokeRequired)
                    MainForm.Instance.BeginInvoke(new BalanceLoad(OnBalanceLoad), new object[] { Balance });
                else
                    OnBalanceLoad(Balance);
            }
            catch (Exception ex) {  }
        }


        #endregion

        #region Methods

        /// <summary>
        /// Use To EncryptPlianText
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EncryptPlianText(string str)
        {
            try
            {
                //str = RandomString(10) + str + RandomString(5);
                char[] outPut = new char[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    outPut[i] = (char)(str[i] + (i + 3));
                }
                return new string(outPut);
            }
            catch { return ""; }
        }

        /// <summary>
        /// Use To DecryptPlianText
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DecryptPlianText(string str)
        {
            try
            {
                char[] outPut = new char[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    outPut[i] = (char)(str[i] - (i + 3));
                }
                return new string(outPut);//.Substring(10, str.Length - 5);
            }
            catch { return ""; }
        }
        /// <summary>
        /// Read username and pass from phoneSetting and register
        /// </summary>
        public void SetConfig()
        {

            if (OnRegestering != null) OnRegestering();

            // Initialize
            CCallManager.Instance.Initialize(pjsipStackProxy.Instance);
            // register accounts...
            pjsipRegistrar.Instance.registerAccounts();

        }

        /// <summary>
        /// Do Accept call or release or hold retreave
        /// </summary>
        /// <param name="operation">
        /// accept : Accept call 
        ///release : release call
        ///hold:  Hold retreive call
        ///conference: Conference Call
        /// </param>
        /// <param name="state"></param>
        public void CallOperation(string operation, IStateMachine state)
        {
            try
            {
                switch (operation)
                {
                    //Accept call
                    case "accept": CCallManager.Instance.OnUserAnswer(state.Session);
                        break;
                    //Release call
                    case "release": CCallManager.Instance.OnUserRelease(state.Session);
                        break;
                    //Hold retreive call
                    case "hold": CCallManager.Instance.OnUserHoldRetrieve(state.Session);
                        break;
                    //Conference call
                    case "conference": CCallManager.Instance.OnUserConference(state.Session);
                        break;
                }
            }
            catch { }
        }

        /// <summary>
        /// Create New Call to this Number
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public IStateMachine CreateCall(string Number)
        {
            try
            {
                if (Number == null || Number == "" || CCallManager.Instance[EStateId.ACTIVE].Count > 0) return new CStateMachine();
                if (PhoneConfig.Instance.Accounts[0].IsLoggedin == false)
                {

                    //Cursor = Cursors.WaitCursor;
                    SetConfig();
                    //Cursor = Cursors.Default;
                }
                MainForm.Instance.Cursor = Cursors.WaitCursor;
                int Session = CCallManager.Instance.CreateSmartOutboundCall(Number, PhoneConfig.Instance.DefaultAccountIndex);
                MainForm.Instance.ShowPanelContianerControl(0);
                return CCallManager.Instance[Session];
            }
            catch { return null; }
        }

        public void PlayTone(ETones ton)
        {
            try
            {
                CCallManager.Instance.MediaProxy.playTone(ETones.EToneCongestion);
            }
            catch { }
        }

        /// <summary>
        /// make account unlogged
        /// </summary>
        public void Logoff()
        {
            try
            {
                Application.DoEvents();
                CCallManager.Instance.MediaProxy.stopTone();
                PhoneConfig.Instance.Accounts[0].IsLoggedin = false;
                //CCallManager.Instance.Shutdown();
                pjsipRegistrar.Instance.unregisterAccounts();
                AbortRequestGetBalance();
                //Application.Restart();
            }
            catch { }
        }

        void FactoryManger_OnRegistrationUpdate(int accountId, int accState)
        {
            try { PhoneConfig.Instance.Accounts[0].IsLoggedin = accState == 200; }
            catch { }
        }

        public void TransferCall(IStateMachine state, string to)
        {
            try
            {
                if (to == "") return;
                if (state.StateId != EStateId.ACTIVE && state.StateId != EStateId.INCOMING) return;
                CCallManager.Instance.OnUserTransfer(state.Session, to);

            }
            catch { }
        }

        public List<IStateMachine> CallsCanRelease
        {
            get { return CCallManager.Instance[s => s.StateId == EStateId.ACTIVE || s.StateId == EStateId.ALERTING || s.StateId == EStateId.HOLDING || s.StateId == EStateId.INCOMING]; }
        }

        public List<IStateMachine> CallsCanHold
        {
            get { return CCallManager.Instance[EStateId.ACTIVE]; }
        }

        public List<IStateMachine> CallsCanRetrieve
        {
            get { return CCallManager.Instance[EStateId.HOLDING]; }
        }

        public List<IStateMachine> CallsCanRecorded
        {
            get { return CCallManager.Instance[EStateId.ACTIVE]; }
        }

        public List<IStateMachine> CallsCanConference
        {
            get
            {
                int active = CCallManager.Instance[EStateId.ACTIVE].Count;
                if (active > 1) return CCallManager.Instance[EStateId.ACTIVE];
                int incom = CCallManager.Instance[EStateId.INCOMING].Count;
                if (incom > 0 && active > 0)
                    return CCallManager.Instance[s => s.StateId == EStateId.ACTIVE || s.StateId == EStateId.INCOMING];
                return new List<IStateMachine>();
            }
        }

        public List<IStateMachine> CallsCanTransfer
        {
            get
            {

                return CCallManager.Instance[s => s.StateId == EStateId.ACTIVE || s.StateId == EStateId.HOLDING || s.StateId == EStateId.INCOMING];

            }
        }

        #endregion
    }
}
