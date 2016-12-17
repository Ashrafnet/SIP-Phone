using System;
using System.Collections.Generic;

using System.Text;
using System.Collections.Specialized;

namespace SIPProvider.SIPCore.Interfaces
{
    /// <summary>
    /// IConfiguratorInterface defines data access interface.
    /// </summary>
    public interface IConfiguratorInterface
    {
        /// <summary>
        /// Do Not Disturb Property
        /// </summary>
        bool DNDFlag { get; set; }
        /// <summary>
        /// Auto Answer property
        /// </summary>
        bool AutoAnswer { get; set; }
        /// <summary>
        /// Call Forwarding Unconditional property
        /// </summary>
        bool CFUFlag { get; set; }
        /// <summary>
        /// Call Forwarding Unconditional Number property
        /// </summary>
        string CFUNumber { get; set; }
        /// <summary>
        /// Call Forwarding No Reply property
        /// </summary>
        bool CFNRFlag { get; set; }
        /// <summary>
        /// Call Forwarding No Reply Number property
        /// </summary>
        string CFNRNumber { get; set; }
        /// <summary>
        /// Call Forwarding Busy property
        /// </summary>
        bool CFBFlag { get; set; }
        /// <summary>
        /// Call Forwarding Busy Number property
        /// </summary>
        string CFBNumber { get; set; }
        /// <summary>
        /// Sip listening port property
        /// </summary>
        int SIPPort { get; set; }
        /// <summary>
        /// Internal representation of account identification. Assigned by voip stack.
        /// </summary>
        int DefaultAccountIndex { get; }
        /// <summary>
        /// List of all codecs
        /// </summary>
        StringCollection CodecList { get; set; }
        /// <summary>
        /// Flag to enable publish method (user status)
        /// </summary>
        bool PublishEnabled { get; set; }

        List<IAccount> Accounts { get; }

        bool IsNull { get; }

        EDtmfMode DtmfMode { get; set; }
        string StunServerAddress { get; set; }
        #region Public Methods

        /// <summary>
        /// Save settings 
        /// </summary>
        void Save();
        #endregion Methods
    }
}
