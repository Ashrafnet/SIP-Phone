using System;
using System.Collections.Generic;
using System.Text;

namespace SIPProvider.SIPCore.Interfaces
{
    /// <summary>
    /// Timer interface
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// Request timer start
        /// </summary>
        bool Start();

        /// <summary>
        /// Request timer stop
        /// </summary>
        bool Stop();

        /// <summary>
        /// Set timer interval
        /// </summary>
        int Interval { get; set; }

        /// <summary>
        /// Set timer expiry callback method
        /// </summary>
        TimerExpiredCallback Elapsed { set; }

    }
}
