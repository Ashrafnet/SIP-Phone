using System;
using System.Collections.Generic;
using System.Text;

namespace SIPProvider.SIPCore.Interfaces
{
    /// <summary>
    /// CAbstractState implements ICallProxyInterface interface. 
    /// Sends requests to call server. 
    /// It's a base for all call states classes (IStateMachine). 
    /// </summary>
    internal abstract class IAbstractState : ICallProxyInterface
    {

        #region Properties
        /// <summary>
        /// State identification property
        /// </summary>
        public EStateId Id
        {
            get { return _stateId; }
            set { _stateId = value; }
        }

        /// <summary>
        /// Signaling proxy instance for communication with VoIP stack
        /// </summary>
        public ICallProxyInterface CallProxy
        {
            get { return _smref.CallProxy; }
        }
        /// <summary>
        /// Media proxy instance for handling tones
        /// </summary>
        public IMediaProxyInterface MediaProxy
        {
            get { return _smref.MediaProxy; }
        }
        /// <summary>
        /// Call/Session identification
        /// </summary>
        public override int SessionId
        {
            get { return _smref.Session; }
            set { }
        }

        public override string ToString()
        {
            return _stateId.ToString();
        }

        #endregion

        #region Variables

        private EStateId _stateId = EStateId.IDLE;

        protected IStateMachine _smref;

        #endregion Variables

        #region Constructor
        /// <summary>
        /// Abstract state construction.
        /// </summary>
        /// <param name="sm">reference to call state machine</param>
        public IAbstractState(IStateMachine sm)
        {
            _smref = sm;
        }

        #endregion Constructor

        #region Abstract Methods

        /// <summary>
        /// State entry method
        /// </summary>
        internal abstract void OnEntry();
        /// <summary>
        /// State exit method
        /// </summary>
        internal abstract void OnExit();

        /// <summary>
        /// Handler for Reply timer timeout. Reply timer is started on incoming call if 
        /// Call Forward No Reply is active. 
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public virtual bool noReplyTimerExpired(int sessionId) { return false; }

        /// <summary>
        /// Handle Release timer timeout. Release timer is usualy started when other 
        /// party releases the call.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public virtual bool releasedTimerExpired(int sessionId) { return false; }

        /// <summary>
        /// Handler no response on incoming call. Trigerred by ENORESPONSE timer
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public virtual bool noResponseTimerExpired(int sessionId) { return false; }

        #endregion

        #region Inherited methods

        public override int makeCall(string dialedNo, int accountId)
        {
            return -1;
        }

        public override bool endCall()
        {
            return true;
        }

        public override bool acceptCall()
        {
            return true;
        }


        public override bool alerted()
        {
            return true;
        }

        public override bool holdCall()
        {
            return true;
        }

        public override bool retrieveCall()
        {
            return true;
        }
        public override bool xferCall(string number)
        {
            return true;
        }
        public override bool xferCallSession(int partnersession)
        {
            return true;
        }
        public override bool threePtyCall(int partnersession)
        {
            return true;
        }

        public override bool serviceRequest(int code, string dest)
        {
            CallProxy.serviceRequest(code, dest);
            return true;
        }

        public override bool dialDtmf(string digits, EDtmfMode mode)
        {
            CallProxy.dialDtmf(digits, mode);
            return true;
        }

        public override string getCurrentCodec()
        {
            // not used!
            return "";
        }

        public override bool conferenceCall()
        {
            return false;
        }

        public override bool sendCallMessage(string message)
        {
            return CallProxy.sendCallMessage(message);
        }

        #endregion Methods

        #region Callbacks

        public virtual void incomingCall(string callingNo, string display)
        {
        }

        public virtual void onAlerting()
        {
        }

        public virtual void onConnect()
        {
        }

        public virtual void onReleased()
        {
        }

        public virtual void onHoldConfirm()
        {
        }
        #endregion Callbacks
    }
}
