using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.Common;
using SIPProvider.SIPCore;

namespace SIPProvider.PhoneState
{
    /// <summary>
    /// Connecting states indicates outgoing call has been initiated and waiting for a response.
    /// </summary>
    internal class CConnectingState : IAbstractState
    {
        public CConnectingState(CStateMachine sm)
            : base(sm)
        {
            Id = EStateId.CONNECTING;
        }

        internal override void OnEntry()
        {
            _smref.Type = ECallType.EDialed;
        }

        internal override void OnExit()
        {
        }

        public override void onReleased()
        {
            _smref.ChangeState(EStateId.RELEASED);
        }

        public override void onAlerting()
        {
            _smref.ChangeState(EStateId.ALERTING);
        }


        public override void onConnect()
        {
            _smref.ChangeState(EStateId.ACTIVE);
        }

        public override bool endCall()
        {
            _smref.ChangeState(EStateId.TERMINATED);
            CallProxy.endCall();
            return base.endCall();
        }

    }
}
