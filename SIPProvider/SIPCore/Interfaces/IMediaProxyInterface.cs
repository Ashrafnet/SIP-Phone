using System;
using System.Collections.Generic;
using System.Text;

namespace SIPProvider.SIPCore.Interfaces
{
    /// <summary>
    /// Media proxy interface for playing tones (todo recording)
    /// </summary>
    public interface IMediaProxyInterface
    {
        /// <summary>
        /// Play give tone 
        /// </summary>
        /// <param name="toneId">tone identification</param>
        /// <returns></returns>
        int playTone(ETones toneId);

        /// <summary>
        /// Stop tone
        /// </summary>
        /// <returns></returns>
        int stopTone();
    }
}
