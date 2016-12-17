using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.SIPCore;

namespace SIPProvider.NullValues
{
    internal class NullStateMachine : IStateMachine
    {
        public NullStateMachine() : base() { }

        public override EStateId StateId
        {
            get { return EStateId.NULL; }
        }

        public override string CallingName
        {
            get
            {
                return "";
            }
            set
            {
                ;
            }
        }

        public override string CallingNumber
        {
            get
            {
                return "";
            }
            set
            {
                ;
            }
        }

        public override bool Incoming
        {
            get
            {
                return false;
            }
            set
            {
                ;
            }
        }

        public override bool Is3Pty
        {
            get
            {
                return false;
            }
            set
            {
                ;
            }
        }

        public override bool IsHeld
        {
            get
            {
                return false;
            }
            set
            {
                ;
            }
        }

        public override int Session
        {
            get
            {
                return -1;
            }
            set
            {
                ;
            }
        }

        internal override IAbstractState State
        {
            get { return new NullState(); }
        }


        internal override void ChangeState(EStateId stateId)
        {
            ;
        }


        public override void Destroy() { }

        public override bool IsNull
        {
            get
            {
                return true;
            }
        }

        internal override bool RetrieveRequested
        {
            get
            {
                return false;
            }
            set
            {
                ;
            }
        }

        internal override bool HoldRequested
        {
            get
            {
                return false;
            }
            set
            {
                ;
            }
        }

        internal override ICallProxyInterface CallProxy
        {
            get
            {
                return new NullCallProxy();
            }
        }

        internal override IConfiguratorInterface Config
        {
            get
            {
                return new NullConfigurator();
            }
        }

        internal override IMediaProxyInterface MediaProxy
        {
            get { return new NullMediaProxy(); }
        }

        internal override ECallType Type
        {
            get
            {
                return ECallType.EDialed;
            }
            set
            {
                ;
            }
        }

        internal override bool StartTimer(ETimerType ttype)
        {
            return false;
        }

        internal override bool StopTimer(ETimerType ttype)
        {
            return false;
        }

        internal override void StopAllTimers()
        {
            ;
        }

        internal override DateTime Time
        {
            get
            {
                return new DateTime();
            }
            set
            {
                ;
            }
        }

        public override TimeSpan Duration
        {
            get
            {
                return new TimeSpan();
            }
            set
            {
                ;
            }
        }

        public override TimeSpan RuntimeDuration
        {
            get { return new TimeSpan(); }
        }

        internal override void ActivatePendingAction()
        {
            ;
        }

        internal override bool Counting
        {
            get
            {
                return false;
            }
            set
            {
                ;
            }
        }

        public override string Codec
        {
            get { return "PCMA"; }
        }

        internal override bool DisableStateNotifications
        {
            get
            {
                return true;
            }
            set
            {
                ;
            }
        }

        internal override int NumberOfCalls
        {
            get { return 0; }
        }
    }
}
