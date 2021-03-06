﻿using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.SIPCore;
using SIPProvider.NullValues;
using SIPProvider.SIPCore.NullValues;
using SIPProvider.CallRecords;

namespace SIPProvider.Common
{
    /// <summary>
    /// CCallManager
    /// Main telephony class. Manages call instances. Handles user events and dispatches to a proper 
    /// call instance automaton. 
    /// </summary>
    public class CCallManager
    {
        #region Variables

        private static CCallManager _instance = null;

        private Dictionary<int, IStateMachine> _calls;  //!< Call table

        private AbstractFactory _factory = new NullFactory();

        PendingAction _pendingAction;

        #endregion

        #region Properties

        public AbstractFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        private IMediaProxyInterface _media = new NullMediaProxy();
        public IMediaProxyInterface MediaProxy
        {
            get { return _media; }
            set { _media = value; }
        }

        private ICallLogInterface _callLog = CallLoger.Instance;
        public ICallLogInterface CallLogger
        {
            get { return _callLog; }
            set { _callLog = value; }
        }

        private IVoipProxy _stack = new NullVoipProxy();
        public IVoipProxy StackProxy
        {
            get { return _stack; }
            set { _stack = value; }
        }

        private IConfiguratorInterface _config = new NullConfigurator();
        public IConfiguratorInterface Config
        {
            get { return _config; }
            set { _config = value; }
        }

        /// <summary>
        /// Call indexer. 
        /// Retrieve a call instance (IStateMachine) from a call list. 
        /// </summary>
        /// <param name="sessionId">call/session identification</param>
        /// <returns>an instance of a call with a given sessionId</returns>
        public IStateMachine this[int sessionId]
        {
            get
            {
                if ((_calls.Count == 0) || (!_calls.ContainsKey(sessionId)))
                {
                    return new NullStateMachine();
                }
                return _calls[sessionId];
            }
        }

        /// <summary>
        /// Retrieve a complete list of calls (IStateMachines)
        /// </summary>
        public Dictionary<int, IStateMachine> CallList
        {
            get { return _calls; }
        }

        public int Count
        {
            get 
            {
                if (_calls == null) return 0;
                return _calls.Count; 
            }
        }

        public bool Is3Pty
        {
            get
            {
                return this[EStateId.ACTIVE].Count == 2;
            }
        }

        private bool _initialized = false;
        public bool IsInitialized
        {
            get { return _initialized; }
        }

        public List<IStateMachine> this[EStateId stateId]
        {
            get { return SearchCalls(s => s.State.Id == stateId); }
        }

        public List<IStateMachine> this[Predicate<IStateMachine> match]
        {
            get { return SearchCalls(match); }
        }

        public List<IStateMachine> SearchCalls(Predicate<IStateMachine> match)
        {
            List<IStateMachine> calls = new List<IStateMachine>(_calls.Values);
           return calls.FindAll(match);
        }

        #endregion Properties

        #region Constructor


        /// <summary>
        /// CCallManager Singleton
        /// </summary>
        /// <returns></returns>
        public static CCallManager Instance
        {
            get
            {

                if (_instance == null) _instance = new CCallManager();
                return _instance;
            }
        }

        #endregion Constructor

        #region Events

        /// <summary>
        /// Notify about call state changed in automaton with given sessionId
        /// </summary>
        public event DCallStateRefresh CallStateRefresh;

        public event DIncomingCallNotification IncomingCallNotification;


        /// <summary>
        /// Action definitions for pending events.
        /// </summary>
        enum EPendingActions : int
        {
            EUserAnswer,
            ECreateSession,
            EUserHold
        };

        /// <summary>
        /// Internal mechanism to execute 2 stage actions. Some user events requires 
        /// two request to VoIP side. Depending on result the second action is executed.
        /// </summary>
        class PendingAction
        {
            delegate void DPendingAnswer(int sessionId); // for onUserAnswer
            delegate void DPendingCreateSession(string number, int accountId); // for CreateOutboudCall

            private EPendingActions _actionType;
            private int _sessionId;
            private int _accountId;
            private string _number;


            public PendingAction(EPendingActions action, int sessionId)
            {
                _actionType = action;
                _sessionId = sessionId;
            }
            public PendingAction(EPendingActions action, string number, int accId)
            {
                _actionType = action;
                _sessionId = -1;
                _number = number;
                _accountId = accId;
            }

            public void Activate()
            {
                switch (_actionType)
                {
                    case EPendingActions.EUserAnswer:
                        CCallManager.Instance.OnUserAnswer(_sessionId);
                        break;
                    case EPendingActions.ECreateSession:
                        CCallManager.Instance.CreateSmartOutboundCall(_number, _accountId);
                        break;
                    case EPendingActions.EUserHold:
                        CCallManager.Instance.OnUserHoldRetrieve(_sessionId);
                        break;
                }
            }

        }

        /////////////////////////////////////////////////////////////////////////
        // Callback handlers
        /// <summary>
        /// Inform GUI to be refreshed 
        /// </summary>
        public void updateGui(int sessionId)
        {
            // check if call is in table (doesn't work in connecting state - session not inserted in call table)
            //if (!_calls.ContainsKey(sessionId)) return;

            if (null != CallStateRefresh) CallStateRefresh(sessionId);
        }

        #endregion Events

        #region Public methods

        /// <summary>
        /// Initialize telephony and VoIP stack. On success register accounts.
        /// </summary>
        /// <returns>initialiation status</returns>
        public int Initialize(IVoipProxy proxy)
        {
            _stack = proxy;

            int status = 0;
            ///
            if (!IsInitialized)
            {
                //// register to signaling proxy interface
                ICallProxyInterface.CallStateChanged += OnCallStateChanged;
                ICallProxyInterface.CallIncoming += OnIncomingCall;
                ICallProxyInterface.CallNotification += OnCallNotification;

                // Initialize call table
                _calls = new Dictionary<int, IStateMachine>();
            }

            // (re)initialize voip proxy
            status = StackProxy.initialize();
            if (status != 0) return status;

            // (re)register 
            _initialized = true;
            return status;
        }

        /// <summary>
        /// Shutdown telephony and VoIP stack
        /// </summary>
        public void Shutdown()
        {
            IStateMachine[] callarr = new IStateMachine[CallList.Count];
            CallList.Values.CopyTo(callarr, 0);
            for (int i = 0; i < callarr.Length; i++)
            {
                callarr[i].Destroy();
            }

            this.CallList.Clear();

            StackProxy.shutdown();
            _initialized = false;

            CallStateRefresh = null;
            IncomingCallNotification = null;

            ICallProxyInterface.CallStateChanged -= OnCallStateChanged;
            ICallProxyInterface.CallIncoming -= OnIncomingCall;
            ICallProxyInterface.CallNotification -= OnCallNotification;
            StackProxy.CallReplaced -= OnCallReplaced;
        }

        /// <summary>
        /// Create outgoing call using default accountId. 
        /// </summary>
        /// <param name="number">Number to call</param>
        public int CreateSimpleOutboundCall(string number)
        {
            int accId = Config.DefaultAccountIndex;
            return this.CreateSimpleOutboundCall(number, accId);
        }

        /// <summary>
        /// Try to create an outbound call. No automatics: make call only if no other call exists
        /// </summary>
        /// <param name="number"></param>
        /// <param name="accountId"></param>
        /// <returns>SessionId or -1 on error</returns>
        public int CreateSimpleOutboundCall(string number, int accountId)
        {
            // if no calls in list
            if ((this.Count > 0) || (!IsInitialized))
            {
                return -1;
            }
            else
            {
                // create state machine
                IStateMachine call = Factory.createStateMachine();
                // couldn't create new call instance (max calls?)
                if (call == null)
                {
                    return -1;
                }

                // make call request (stack provides new sessionId)
                int newsession = call.State.makeCall(number, accountId);
                if (newsession == -1)
                {
                    return -1;
                }
                // update call table
                // catch argument exception (same key)!!!!
                try
                {
                    call.Session = newsession;
                    _calls.Add(newsession, call);
                }
                catch (ArgumentException)
                {
                    // previous call not released ()
                    // first release old one
                    _calls[newsession].Destroy();
                    // and then add new one
                    _calls.Add(newsession, call);
                }

                return call.Session;
            }
        }
        /// <summary>
        /// Create outgoing call to a number and from a given account.
        /// 
        /// If the other calls exist check if it is possible to create a new one.
        /// The logic below will automatically put the active call on hold, 
        /// return -2 and store a new call creation request. When hold confirmation 
        /// received create a call. 
        /// 
        /// Be aware: This is done asynchronously. 
        /// 
        /// </summary>
        /// <param name="number">Number to call</param>
        /// <param name="accountId">Specified account Id </param>
        public int CreateSmartOutboundCall(string number, int accountId)
        {

            
            if (!IsInitialized ) return -1;

            // check if current call automatons allow session creation.
            if (this.GetNoCallsInStates((int)(EStateId.CONNECTING | EStateId.ALERTING)) > 0)
            {
                // new call not allowed!
                return -1;
            }
            // if at least 1 call connected try to put it on hold first
            if (this[EStateId.ACTIVE].Count == 0)
            {
                // create state machine
                IStateMachine call = Factory.createStateMachine();
                // couldn't create new call instance (max calls?)
                if (call == null)
                {
                    return -1;
                }

                // make call request (stack provides new sessionId)
                int newsession = call.State.makeCall(number, accountId);
                //makeCall not done correctly becouse it always return non -1
                if (newsession == -1)
                {
                    return -1;
                }
                // update call table
                // catch argument exception (same key)!!!!
                try
                {
                    call.Session = newsession;
                    _calls.Add(newsession, call);
                }
                catch (ArgumentException)
                {
                    // previous call not released ()
                    // first release old one
                    _calls[newsession].Destroy();
                    // and then add new one
                    _calls.Add(newsession, call);
                }

                return call.Session;
            }
            else // we have at least one ACTIVE call
            {
                // put connected call on hold
                _pendingAction = new PendingAction(EPendingActions.ECreateSession, number, accountId);

                List<IStateMachine> calls = this[EStateId.ACTIVE];
                if (calls.Count > 0)
                {
                    calls[0].State.holdCall();
                }
                // indicates that new call is pending...
                // At this point we don't know yet if the call will be created or not
                // The call will be created when current call is put on hold (confirmation)!
                return -2;
            }

        }


        /// <summary>
        /// User triggers a call release for a given session
        /// </summary>
        /// <param name="session">session identification</param>
        public void OnUserRelease(int session)
        {
            this[session].State.endCall();
        }

        /// <summary>
        /// User accepts call for a given session
        /// In case of multi call put current active call to Hold
        /// </summary>
        /// <param name="session">session identification</param>
        public void OnUserAnswer(int session)
        {
            List<IStateMachine> list = this[EStateId.ACTIVE];
            // should not be more than 1 call active
            if (list.Count > 0)
            {
                // put it on hold
                IStateMachine sm = list[0];
                if (!sm.IsNull) sm.State.holdCall();

                // set ANSWER event pending for HoldConfirm
                _pendingAction = new PendingAction(EPendingActions.EUserAnswer, session);
                return;
            }
            this[session].State.acceptCall();
        }

        /// <summary>
        /// User put call on hold or retrieve 
        /// </summary>
        /// <param name="session">session identification</param>
        public void OnUserHoldRetrieve(int session)
        {
            // check Hold or Retrieve
            IAbstractState state = this[session].State;
            if (state.Id == EStateId.ACTIVE)
            {
                this[session].State.holdCall();
            }
            else if (state.Id == EStateId.HOLDING)
            {
                // execute retrieve
                // check if any ACTIVE calls
                if (this[EStateId.ACTIVE].Count > 0)
                {
                    // get 1st and put it on hold
                    IStateMachine sm = this[EStateId.ACTIVE][0];
                    if (!sm.IsNull) sm.State.holdCall();

                    // set Retrieve event pending for HoldConfirm
                    _pendingAction = new PendingAction(EPendingActions.EUserHold, session);
                    return;
                }

                this[session].State.retrieveCall();
            }
            else
            {
                // illegal
            }
        }

        /// <summary>
        /// User starts a call transfer
        /// </summary>
        /// <param name="session">session identification</param>
        /// <param name="number">number to transfer</param>
        public void OnUserTransfer(int session, string number)
        {
            this[session].State.xferCall(number);
        }

        /// <summary>
        /// Attendant transfer
        /// </summary>
        /// <param name="session"></param>
        /// <param name="number"></param>
        public void OnUserTransferAttendant(int session, int partnerSession)
        {
            this[session].State.xferCallSession(partnerSession);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="digits"></param>
        /// <param name="mode"></param>
        public void OnUserDialDigit(int session, string digits, EDtmfMode mode)
        {
            this[session].State.dialDtmf(digits, mode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public void OnUserConference(int session)
        {
            // check preconditions: 1 call active, other held
            // 1st if current call is held -> search if any active -> execute retrieve
            if ((this[EStateId.ACTIVE].Count == 1) && (this[EStateId.HOLDING].Count >= 1))
            {
                List<IStateMachine> calls = this[EStateId.HOLDING];
                if (calls.Count > 0)
                {
                    calls[0].State.retrieveCall();
                    // set conference flag
                    calls[0].State.conferenceCall();
                }
                return;
            }
        }

        /// <summary>
        /// Send message inside call dialog
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public bool OnUserSendCallMessage(int sessionId, string message)
        {
            return this[sessionId].State.sendCallMessage(message);
        }

        public void OnUserStartRecording(int sessionId, string FilePath)
        {
            try
            {
                PjsipMethods.dll_callRecording_start(sessionId, FilePath);
                this[sessionId].IsRecording = true;
            }
            catch { }
        }
        public void OnUserStopRecording(int sessionId)
        {
            try
            {
                PjsipMethods.dll_callRecording_stop(sessionId);
                this[sessionId].IsRecording = false;
            }
            catch { }

        }

        #endregion  // public methods

        #region Internal & Private Methods

        /// <summary>
        /// Destroy call 
        /// </summary>
        /// <param name="session">session identification</param>
        internal void DestroySession(int session)
        {
            bool notify = true;
            if (this[session].DisableStateNotifications)
            {
                notify = false;
            }
            _calls.Remove(session);
            // Warning: this call no longer exists
            if (notify) updateGui(session);
        }

        /// <summary>
        /// 
        /// </summary>
        internal void activatePendingAction()
        {
            if (null != _pendingAction) _pendingAction.Activate();
            _pendingAction = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callId"></param>
        /// <param name="callState"></param>
        private void OnCallStateChanged(int callId, ESessionState callState, string info)
        {
            if (callState == ESessionState.SESSION_STATE_INCOMING)
            {
                IStateMachine incall = Factory.createStateMachine();
                // couldn't create new call instance (max calls?)
                if (incall.IsNull)
                {
                    // check if CFB, activate redirection
                    if (Config.CFBFlag == true)
                    {
                        // get stack proxy
                        ICallProxyInterface proxy = StackProxy.createCallProxy();
                        // assign callid to the proxy...
                        //proxy.SessionId = callId;
                        proxy.serviceRequest((int)EServiceCodes.SC_CFB, Config.CFBNumber);
                        return;
                    }
                }
                // save session parameters
                incall.Session = callId;

                // check if callID already exists!!!
                if (CallList.ContainsKey(callId))
                {
                    // shouldn't be here
                    // release the call
                    CallList[callId].State.endCall();
                    return;
                }
                // add call to call table
                _calls.Add(callId, incall);

                return;
            }

            IStateMachine call = this[callId];
            if (call.IsNull) return;

            switch (callState)
            {
                case ESessionState.SESSION_STATE_CALLING:
                    //sm.getState().onCalling();
                    break;
                case ESessionState.SESSION_STATE_EARLY:
                    call.State.onAlerting();
                    break;
                case ESessionState.SESSION_STATE_CONNECTING:
                    call.State.onConnect();
                    break;
                case ESessionState.SESSION_STATE_DISCONNECTED:
                    call.State.onReleased();
                    break;
            }
        }

        /// <summary>
        /// Create session for incoming call.
        /// </summary>
        /// <param name="sessionId">session identification</param>
        /// <param name="number">number from calling party</param>
        /// <param name="info">additional info of calling party</param>
        private void OnIncomingCall(int sessionId, string number, string info)
        {
            IStateMachine call = this[sessionId];

            if (call.IsNull) return;

            // inform automaton for incoming call
            call.State.incomingCall(number, info);

            // call callback 
            if ((IncomingCallNotification != null) && (call.DisableStateNotifications == false)) IncomingCallNotification(sessionId, number, info);
        }

        private void OnCallNotification(int callId, ECallNotification notFlag, string text)
        {
            if (notFlag == ECallNotification.CN_HOLDCONFIRM)
            {
                IStateMachine sm = this[callId];
                if (!sm.IsNull) sm.State.onHoldConfirm();
            }
        }

        /// <summary>
        /// Replace call ids
        /// </summary>
        /// <param name="newid"></param>
        /// <param name="oldid"></param>
        private void OnCallReplaced(int oldid, int newid)
        {
            IStateMachine call = CallList[oldid];
            _calls.Remove(oldid);
            call.Session = newid;
            CallList.Add(newid, call);
        }

        /// <summary>
        /// Gets the number of calls in given states (bitmask)
        /// 
        /// example: 
        ///   getNoCallsInStates(EStateId.CONNECTING | EStateId.ALERTING)
        /// 
        /// </summary>
        /// <param name="states">a bit mask of states</param>
        /// <returns></returns>
        private int GetNoCallsInStates(int states)
        {
            int cnt = 0;
            foreach (KeyValuePair<int, IStateMachine> kvp in _calls)
            {
                if ((states & (int)kvp.Value.State.Id) == (int)kvp.Value.State.Id)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        #endregion Methods

        
    }
}
