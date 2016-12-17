using System;
using System.Collections.Generic;

using System.Text;

namespace SIPProvider.SIPCore.Interfaces
{
    /// <summary>
    /// IAccount interface
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Account enabled/disabled flag
        /// </summary>
        bool Enabled { get; set; }
        /// <summary>
        /// Represents a value assigned to an account by a sip stack.   
        /// </summary>
        int Index { get; set; }
        /// <summary>
        /// Account name
        /// </summary>
        string AccountName { get; set; }
        /// <summary>
        /// Account host name
        /// </summary>
        string HostName { get; set; }
        /// <summary>
        /// Account Id = Username
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// Account username
        /// </summary>
        string UserName { get; set; }
        /// <summary>
        /// Account password
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// Account display
        /// </summary>
        string DisplayName { get; set; }
        /// <summary>
        /// Account Domain name
        /// </summary>
        string DomainName { get; set; }
        /// <summary>
        /// Account current state (temporary data)
        /// </summary>
        int RegState { get; set; }
        /// <summary>
        /// Account Proxy Address (optional)
        /// </summary>
        string ProxyAddress { get; set; }
        /// <summary>
        /// VoIP Transport mode
        /// </summary>
        ETransportMode TransportMode { get; set; }

        bool IsLoggedin { get; set; }
    }
}
