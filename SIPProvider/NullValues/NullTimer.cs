using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore;
using SIPProvider.SIPCore.Interfaces;

namespace SIPProvider.NullValues
{
    internal class NullTimer : ITimer
    {

        public bool Start() { return false; }
        public bool Stop() { return false; }
        public int Interval
        {
            get { return 100; }
            set { }
        }

        public TimerExpiredCallback Elapsed
        {
            set { }
        }


        
    }
}
