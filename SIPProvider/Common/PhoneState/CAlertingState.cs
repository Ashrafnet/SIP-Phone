using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.Common;
using SIPProvider.SIPCore;

namespace SIPProvider.PhoneState
{
    /// <summary>
    /// Alerting state indicates other side accepts the call. Play ring back tone.
    /// </summary>
    internal class CAlertingState : IAbstractState
    {
        public CAlertingState(CStateMachine sm)
            : base(sm)
        {
            Id = EStateId.ALERTING;
        }

        internal override void OnEntry()
        {
            MediaProxy.playTone(ETones.EToneRingback);
        }

        internal override void OnExit()
        {
            MediaProxy.stopTone();
        }

        public override void onConnect()
        {
            _smref.Time = System.DateTime.Now;
            _smref.ChangeState(EStateId.ACTIVE);
        }

        public override void onReleased()
        {
            _smref.ChangeState(EStateId.RELEASED);
        }

        public override bool endCall()
        {
            _smref.ChangeState(EStateId.TERMINATED);
            CallProxy.endCall();
            return base.endCall();
        }
    }
}
