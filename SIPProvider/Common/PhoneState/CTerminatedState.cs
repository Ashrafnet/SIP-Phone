using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.Common;
using SIPProvider.SIPCore;

namespace SIPProvider.PhoneState
{
    /// <summary>
    /// Released State indicates call has been released by user and waiting for destruction.
    /// The state machine will be destroyed on onReleased event from stack or on released timer 
    /// timeout
    /// </summary>
    internal class CTerminatedState : IAbstractState
    {
        public CTerminatedState(CStateMachine sm)
            : base(sm)
        {
            Id = EStateId.TERMINATED;
        }

        /// <summary>
        /// Enter release state. If release timer not implemented release call imediately
        /// </summary>
        internal override void OnEntry()
        {
            bool success = _smref.StartTimer(ETimerType.ERELEASED);
            if (!success) _smref.Destroy();
        }

        internal override void OnExit()
        {
            _smref.StopAllTimers();
        }

        public override bool endCall()
        {
            CallProxy.endCall();
            return true;
        }

        public override bool releasedTimerExpired(int sessionId)
        {
            _smref.Destroy();
            return true;
        }

        public override void onAlerting()
        {
            CallProxy.endCall();
        }

        public override void onConnect()
        {
            CallProxy.endCall();
        }

        /// <summary>
        /// Destroy state machine 
        /// </summary>
        public override void onReleased()
        {
            _smref.Destroy();
        }
    }
}
