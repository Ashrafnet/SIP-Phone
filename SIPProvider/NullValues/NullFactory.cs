using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.Common;

namespace SIPProvider.NullValues
{
    /// <summary>
    /// Null Factory implementation
    /// </summary>
    internal class NullFactory : AbstractFactory
    {

        // factory methods
        public ITimer createTimer()
        {
            return new NullTimer();
        }
        public IStateMachine createStateMachine()
        {
            return new CStateMachine();
        }

    }
}
