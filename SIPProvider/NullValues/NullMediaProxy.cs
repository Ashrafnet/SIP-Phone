using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore.Interfaces;
using SIPProvider.SIPCore;

namespace SIPProvider.NullValues
{
    internal class NullMediaProxy : IMediaProxyInterface
    {
        #region IMediaProxyInterface Members

        public int playTone(ETones toneId)
        {
            return 1;
        }

        public int stopTone()
        {
            return 1;
        }
        #endregion
    }  
}
