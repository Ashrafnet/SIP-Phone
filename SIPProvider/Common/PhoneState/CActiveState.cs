using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.Common;
using SIPProvider.SIPCore;

namespace SIPProvider.PhoneState
{
    /// <summary>
    /// Active state indicates conversation. 
    /// </summary>
    internal class CActiveState : IAbstractState
    {
        public CActiveState(CStateMachine sm)
            : base(sm)
        {
            Id = EStateId.ACTIVE;
        }

        internal override void OnEntry()
        {
            _smref.Counting = true;
            MediaProxy.stopTone();
        }

        internal override void OnExit()
        {
        }

        public override bool endCall()
        {
            _smref.ChangeState(EStateId.TERMINATED);
            CallProxy.endCall();
            return base.endCall();
        }

        public override bool holdCall()
        {
            _smref.HoldRequested = true;
            return CallProxy.holdCall();
        }

        public override bool xferCall(string number)
        {
            return CallProxy.xferCall(number);
        }

        public override bool xferCallSession(int partnersession)
        {
            return CallProxy.xferCallSession(partnersession);
        }

        public override void onHoldConfirm()
        {
            // check if Hold requested
            if (_smref.HoldRequested)
            {
                _smref.ChangeState(EStateId.HOLDING);
                // activate pending action if any
                _smref.ActivatePendingAction();
            }
            _smref.HoldRequested = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void onReleased()
        {
            _smref.ChangeState(EStateId.RELEASED);
        }

        public override bool conferenceCall()
        {
            return CallProxy.conferenceCall();
        }
    }
}
