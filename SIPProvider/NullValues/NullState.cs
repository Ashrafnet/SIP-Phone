using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;

namespace SIPProvider.NullValues
{
    internal class NullState : IAbstractState
    {
        public NullState()
            : base(new NullStateMachine())
        { }

        internal override void OnEntry()
        {
        }

        internal override void OnExit()
        {
        }
    }
}
