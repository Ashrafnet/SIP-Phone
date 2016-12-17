using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.Common;
using SIPProvider.SIPCore;

namespace SIPProvider.PhoneState
{
    /// <summary>
    /// Holding state indicates call is hodling.
    /// </summary>
    internal class CHoldingState : IAbstractState
    {
        public CHoldingState(CStateMachine sm)
            : base(sm)
        {
            Id = EStateId.HOLDING;
        }

        internal override void OnEntry()
        {
        }

        internal override void OnExit()
        {
        }

        public override bool retrieveCall()
        {
            _smref.RetrieveRequested = true;
            CallProxy.retrieveCall();
            _smref.ChangeState(EStateId.ACTIVE);
            return true;
        }

        // TODO implement in stack interface
        //public override onRetrieveConfirm()
        //{
        //  if (_smref.RetrieveRequested)
        //  {
        //    _smref.changeState(EStateId.ACTIVE);
        //  }
        //  _smref.RetrieveRequested = false;
        //}

        public override void onReleased()
        {
            _smref.ChangeState(EStateId.RELEASED);
        }

        public override bool endCall()
        {
            CallProxy.endCall();
            _smref.ChangeState(EStateId.TERMINATED);
            return base.endCall();
        }
    }
}
