using System;
using System.Collections.Generic;
using System.Text;

namespace SIPProvider.SIPCore.Interfaces
{

    /// <summary>
    /// General state machine interface. 
    /// </summary>
    public abstract class IStateMachine
    {
        #region Public Methods
        public abstract void Destroy();
        public abstract bool IsNull { get; }
        #endregion

        #region Public Properties
        public abstract string CallingName { get; set; }
        public abstract string CallingNumber { get; set; }
        public abstract bool Incoming { get; set; }
        public abstract bool Is3Pty { get; set; }
        public abstract bool IsHeld { get; set; }
        public abstract int Session { get; set; }
        public abstract TimeSpan RuntimeDuration { get; }
        public abstract TimeSpan Duration { get; set; }
        public abstract EStateId StateId { get; }
        public abstract string Codec { get; }
        internal abstract bool DisableStateNotifications { get; set; }
        internal abstract int NumberOfCalls { get; }
        public bool IsRecording { get; set; }
        #endregion

        #region Internal Methods

        internal abstract void ChangeState(EStateId stateId);
        internal abstract bool StartTimer(ETimerType ttype);
        internal abstract bool StopTimer(ETimerType ttype);
        internal abstract void StopAllTimers();
        internal abstract void ActivatePendingAction();

        #endregion

        #region Internal Properties
        internal abstract IAbstractState State { get; }
        internal abstract bool RetrieveRequested { get; set; }
        internal abstract bool HoldRequested { get; set; }
        internal abstract ICallProxyInterface CallProxy { get; }
        internal abstract IConfiguratorInterface Config { get; }
        internal abstract IMediaProxyInterface MediaProxy { get; }
        internal abstract ECallType Type { get; set; }
        internal abstract DateTime Time { get; set; }
        internal abstract bool Counting { get; set; }
        #endregion

    }
}
