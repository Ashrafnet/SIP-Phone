using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.Common;
using SIPProvider.SIPCore;

namespace SIPProvider.PhoneState
{
    /// <summary>
    /// Released State indicates call has been released from other party (stack) 
    /// and now waiting for destruction. The state machine will be release on 
    /// endCall user request or released timer timeout.
    /// </summary>
    internal class CReleasedState : IAbstractState
    {
        public CReleasedState(CStateMachine sm)
            : base(sm)
        {
            Id = EStateId.RELEASED;
        }

        /// <summary>
        /// Enter release state. If release timer not implemented release call imediately
        /// </summary>
        internal override void OnEntry()
        {
            MediaProxy.playTone(ETones.EToneCongestion);
            bool success = _smref.StartTimer(ETimerType.ERELEASED);
            if (!success) _smref.Destroy();
        }

        internal override void OnExit()
        {
            MediaProxy.stopTone();
            _smref.StopAllTimers();
        }

        public override bool endCall()
        {
            // try once more (might not be needed)!
            CallProxy.endCall();
            // destroy it!
            _smref.Destroy();
            return true;
        }

        public override bool releasedTimerExpired(int sessionId)
        {
            _smref.Destroy();
            return true;
        }

        /// <summary>
        /// If by any chance this lost event comes here: destroy State machine
        /// </summary>
        public override void onReleased()
        {
            _smref.Destroy();
        }
    }
}
