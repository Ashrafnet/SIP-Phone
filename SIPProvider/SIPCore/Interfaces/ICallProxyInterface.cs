using System;
using System.Collections.Generic;
using System.Text;

namespace SIPProvider.SIPCore.Interfaces
{
    /// <summary>
    /// Call oriented interface. Offers basic session control API and events called from VoIP stack
    /// </summary>
    /// 
    public abstract class ICallProxyInterface
    {
        #region Properties
        /// <summary>
        /// Call/Session identification. All public methods refers to this identification
        /// </summary>
        public abstract int SessionId
        { get; set; }

        #endregion

        #region Events
        /// <summary>
        /// CallStateChanged event trigger by VoIP stack when call state changed
        /// </summary>
        public static event DCallStateChanged CallStateChanged;
        protected static void BaseCallStateChanged(int callId, ESessionState callState, string info)
        {
            if (null != CallStateChanged) CallStateChanged(callId, callState, info);
        }
        /// <summary>
        /// CallIncoming event triggered by VoIP stack when new incoming call arrived
        /// </summary>
        public static event DCallIncoming CallIncoming;
        protected static void BaseIncomingCall(int callId, string number, string info)
        {
            if (null != CallIncoming) CallIncoming(callId, number, info);
        }
        /// <summary>
        /// CallNotification event trigger by VoIP stack when call notification arrived
        /// </summary>
        public static event DCallNotification CallNotification;
        protected static void BaseCallNotification(int callId, ECallNotification notifFlag, string text)
        {
            if (null != CallNotification) CallNotification(callId, notifFlag, text);
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Make call request
        /// </summary>
        /// <param name="dialedNo">Calling Number</param>
        /// <param name="accountId">Account Id</param>
        /// <returns>Session Identification</returns>
        public abstract int makeCall(string dialedNo, int accountId);

        /// <summary>
        /// End call
        /// </summary>
        /// <returns></returns>
        public abstract bool endCall();

        /// <summary>
        /// Report that device is alerted
        /// </summary>
        /// <returns></returns>
        public abstract bool alerted();

        /// <summary>
        /// Report that call is accepted/answered
        /// </summary>
        /// <returns></returns>
        public abstract bool acceptCall();

        /// <summary>
        /// Request call hold
        /// </summary>
        /// <returns></returns>
        public abstract bool holdCall();

        /// <summary>
        /// Request retrieve call
        /// </summary>
        /// <returns></returns>
        public abstract bool retrieveCall();

        /// <summary>
        /// Tranfer call to a given number
        /// </summary>
        /// <param name="number">Number to transfer call to</param>
        /// <returns></returns>
        public abstract bool xferCall(string number);

        /// <summary>
        /// Transfer call to partner session
        /// </summary>
        /// <param name="partnersession">Session to transfer call to</param>
        /// <returns></returns>
        public abstract bool xferCallSession(int partnersession);

        /// <summary>
        /// Request three party conference
        /// </summary>
        /// <param name="partnersession">Partner session for conference with</param>
        /// <returns></returns>
        public abstract bool threePtyCall(int partnersession);

        /// <summary>
        /// Request service (TODO)
        /// </summary>
        /// <param name="code"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public abstract bool serviceRequest(int code, string dest);

        /// <summary>
        /// Dial digit by DTMF
        /// </summary>
        /// <param name="digits">digit string</param>
        /// <param name="mode">digit mode (TODO)</param>
        /// <returns></returns>
        public abstract bool dialDtmf(string digits, EDtmfMode mode);

        /// <summary>
        /// Retrieve codec information for this call
        /// </summary>
        /// <returns>codec name</returns>
        public abstract string getCurrentCodec();

        /// <summary>
        /// Make a conference 
        /// </summary>
        /// <returns></returns>
        public abstract bool conferenceCall();

        /// <summary>
        /// Send a message inside a call
        /// </summary>
        /// <returns></returns>
        public abstract bool sendCallMessage(string message);

        #endregion
    }
}
