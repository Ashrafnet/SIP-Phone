using System;
using System.Collections.Generic;
using System.Text;

namespace SIPProvider.SIPCore.Interfaces
{
    /// <summary>
    /// AbstractFactory is an abstract interface providing interfaces for CallControl module. 
    /// It consists of two parts: factory methods and getter methods. First creates instances, 
    /// later returns instances. 
    /// </summary>
    public interface AbstractFactory
    {
        /// <summary>
        /// Factory creator. Creates new instance of timer 
        /// </summary>
        /// <returns>ITimer instance</returns>
        ITimer createTimer();

        /// <summary>
        /// State machine factory. Use this method to create your own call state machine class.
        /// </summary>
        /// <returns></returns>
        IStateMachine createStateMachine();
    }

}
