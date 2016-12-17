using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.Common;
using SIPProvider.SIPCore;

namespace SIPProvider.PhoneState
{
    /// <summary>
    /// Incoming state indicates incoming call. Check CFx and DND features. Start ringer. 
    /// </summary>
    internal class CIncomingState : IAbstractState
    {
        public CIncomingState(CStateMachine sm)
            : base(sm)
        {
            Id = EStateId.INCOMING;
        }

        internal override void OnEntry()
        {
            // set incoming call flags
            _smref.Incoming = true;

            int sessionId = SessionId;

            // Start no response timer
            _smref.StartTimer(ETimerType.ENORESPONSE);

            CallProxy.alerted();
            _smref.Type = ECallType.EMissed;
            MediaProxy.playTone(ETones.EToneRing);

            // if CFNR active start timer
            if (_smref.Config.CFNRFlag)
            {
                _smref.StartTimer(ETimerType.ENOREPLY);
            }
            // auto answer call (if single call)
            if ((_smref.Config.AutoAnswer == true) && (_smref.NumberOfCalls == 1))
            {
                this.acceptCall();
            }
        }

        internal override void OnExit()
        {
            MediaProxy.stopTone();
            _smref.StopAllTimers();
        }

        public override bool acceptCall()
        {
            _smref.Type = ECallType.EReceived;
            _smref.Time = System.DateTime.Now;

            CallProxy.acceptCall();
            _smref.ChangeState(EStateId.ACTIVE);
            return true;
        }

        public override void onReleased()
        {
            _smref.ChangeState(EStateId.RELEASED);
        }

        public override bool xferCall(string number)
        {
            // In fact this is not Tranfser. It's Deflect => redirect...
            return CallProxy.serviceRequest((int)EServiceCodes.SC_CD, number);
        }

        public override bool endCall()
        {
            _smref.ChangeState(EStateId.TERMINATED);
            CallProxy.endCall();
            return base.endCall();
        }

        /// <summary>
        /// No reply timer expired. Send service code to call proxy.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public override bool noReplyTimerExpired(int sessionId)
        {
            CallProxy.serviceRequest((int)EServiceCodes.SC_CFNR, _smref.Config.CFUNumber);
            return true;
        }

        /// <summary>
        /// Response timer expired. Releasing the call...
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public override bool noResponseTimerExpired(int sessionId)
        {
            _smref.ChangeState(EStateId.TERMINATED);
            CallProxy.endCall();
            return true;
        }
    }
}
