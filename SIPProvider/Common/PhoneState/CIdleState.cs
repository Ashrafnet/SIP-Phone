using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.SIPCore;

namespace SIPProvider.PhoneState
{
    /// <summary>
    /// State Idle indicates the call is inactive
    /// </summary>
    internal class CIdleState : IAbstractState
    {
        public CIdleState(IStateMachine sm)
            : base(sm)
        {
            Id = EStateId.IDLE;
        }

        internal override void OnEntry()
        {
        }

        internal override void OnExit()
        {
        }

        public override bool endCall()
        {
            _smref.Destroy();
            CallProxy.endCall();
            return base.endCall();
        }

        /// <summary>
        /// Make call to a given number and accountId. Assign sessionId to call state machine got from VoIP part.
        /// </summary>
        /// <param name="dialedNo"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public override int makeCall(string dialedNo, int accountId)
        {
            _smref.CallingNumber = dialedNo;
            // make call and save sessionId
            _smref.ChangeState(EStateId.CONNECTING);
            _smref.Session = CallProxy.makeCall(dialedNo, accountId);
            return _smref.Session;
        }

        /// <summary>
        /// Handle incoming call requests. Check for supplementary services flags.
        /// </summary>
        /// <param name="callingNo"></param>
        /// <param name="display"></param>
        public override void incomingCall(string callingNo, string display)
        {
            // check supplementary services flags
            if ((_smref.Config.CFUFlag == true) && (_smref.Config.CFUNumber.Length > 0))
            {
                // do NOT notify about state changes 
                _smref.DisableStateNotifications = true;
                CallProxy.serviceRequest((int)EServiceCodes.SC_CFU, _smref.Config.CFUNumber);
                this.endCall();
                return;
            }
            else if (_smref.Config.DNDFlag == true)
            {
                // do NOT notify about state changes 
                _smref.DisableStateNotifications = true;
                CallProxy.serviceRequest((int)EServiceCodes.SC_DND, "");
                this.endCall();
                return;
            }

            _smref.CallingNumber = callingNo;
            _smref.CallingName = display;
            _smref.ChangeState(EStateId.INCOMING);
        }

    }
}
