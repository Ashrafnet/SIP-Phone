using System;
using System.Collections.Generic;

using System.Text;

namespace SIPProvider.SIPCore
{

   
    #region Enums

    public enum ESessionState : int
    {
        SESSION_STATE_NULL,	   //Before INVITE is sent or received
        SESSION_STATE_CALLING,	    // After INVITE is sent
        SESSION_STATE_INCOMING,	    // After INVITE is received.
        SESSION_STATE_EARLY,	   // After response with To tag.
        SESSION_STATE_CONNECTING,	   // After 2xx is sent/received.
        SESSION_STATE_CONFIRMED,	    // After ACK is sent/received.
        SESSION_STATE_DISCONNECTED,   // Session is terminated.
    }


    /// <summary>
    /// List of user status modes.
    /// Do NOT change the order of enums. It should be synchronized with 
    /// native stack implementation!!!
    /// </summary>
    public enum EUserStatus : int
    {
        AVAILABLE,
        BUSY,
        OTP,
        IDLE,
        AWAY,
        BRB,
        OFFLINE,
        OPT_MAX
        // add new enum here
    }

    /// <summary>
    /// List of supported service codes.
    /// Do NOT change the order of enums. It should be synchronized with 
    /// native stack implementation!!!
    /// </summary>
    public enum EServiceCodes : int
    {
        SC_CD,
        SC_CFU,
        SC_CFNR,
        SC_DND,
        SC_3PTY,
        SC_CFB
        // add new enum here
    }


    public enum ECallNotification : int
    {
        CN_HOLDCONFIRM
    }

    /// <summary>
    /// Dtmf modes
    /// </summary>
    public enum EDtmfMode : int
    {
        DM_Outband,
        DM_Inband,
        DM_Transparent
    }


    public enum ETransportMode : int
    {
        TM_UDP,
        TM_TCP,
        TM_TLS
    }

    /// <summary>
    /// Call state Ids
    /// </summary>
    public enum EStateId : int
    {
        NULL = 0x0,
        IDLE = 0x1,
        CONNECTING = 0x2,
        ALERTING = 0x4,
        ACTIVE = 0x8,
        RELEASED = 0x10,
        INCOMING = 0x20,
        HOLDING = 0x40,
        TERMINATED = 0x80,
    }

    /// <summary>
    /// Tone modes
    /// </summary>
    public enum ETones : int
    {
        EToneDial = 0,
        EToneCongestion,
        EToneRingback,
        EToneRing,
    }

    /// <summary>
    /// Call control timer types
    /// </summary>
    public enum ETimerType
    {
        ENOREPLY,
        ERELEASED,
        ENORESPONSE,
    }
    /// <summary>
    /// Call modes
    /// </summary>
    public enum ECallType : int
    {
        EDialed,
        EReceived,
        EMissed,
        EAll,
        EUndefined
    }

    /// <summary>
    /// Action definitions for pending events.
    /// </summary>
    internal enum EPendingActions : int
    {
        EUserAnswer,
        ECreateSession,
        EUserHold
    }


   public enum pjsip_status_code
    {
        PJSIP_SC_TRYING = 100,
        PJSIP_SC_RINGING = 180,
        PJSIP_SC_CALL_BEING_FORWARDED = 181,
        PJSIP_SC_QUEUED = 182,
        PJSIP_SC_PROGRESS = 183,
        PJSIP_SC_OK = 200,
        PJSIP_SC_MULTIPLE_CHOICES = 300,
        PJSIP_SC_MOVED_PERMANENTLY = 301,
        PJSIP_SC_MOVED_TEMPORARILY = 302,
        PJSIP_SC_USE_PROXY = 305,
        PJSIP_SC_ALTERNATIVE_SERVICE = 380,
        PJSIP_SC_BAD_REQUEST = 400,
        PJSIP_SC_UNAUTHORIZED = 401,
        PJSIP_SC_PAYMENT_REQUIRED = 402,
        PJSIP_SC_FORBIDDEN = 403,
        PJSIP_SC_NOT_FOUND = 404,
        PJSIP_SC_METHOD_NOT_ALLOWED = 405,
        PJSIP_SC_NOT_ACCEPTABLE = 406,
        PJSIP_SC_PROXY_AUTHENTICATION_REQUIRED = 407,
        PJSIP_SC_REQUEST_TIMEOUT = 408,
        PJSIP_SC_GONE = 410,
        PJSIP_SC_REQUEST_ENTITY_TOO_LARGE = 413,
        PJSIP_SC_REQUEST_URI_TOO_LONG = 414,
        PJSIP_SC_UNSUPPORTED_MEDIA_TYPE = 415,
        PJSIP_SC_UNSUPPORTED_URI_SCHEME = 416,
        PJSIP_SC_BAD_EXTENSION = 420,
        PJSIP_SC_EXTENSION_REQUIRED = 421,
        PJSIP_SC_INTERVAL_TOO_BRIEF = 423,
        PJSIP_SC_TEMPORARILY_UNAVAILABLE = 480,
        PJSIP_SC_CALL_TSX_DOES_NOT_EXIST = 481,
        PJSIP_SC_LOOP_DETECTED = 482,
        PJSIP_SC_TOO_MANY_HOPS = 483,
        PJSIP_SC_ADDRESS_INCOMPLETE = 484,
        PJSIP_AC_AMBIGUOUS = 485,
        PJSIP_SC_BUSY_HERE = 486,
        PJSIP_SC_REQUEST_TERMINATED = 487,
        PJSIP_SC_NOT_ACCEPTABLE_HERE = 488,
        PJSIP_SC_REQUEST_PENDING = 491,
        PJSIP_SC_UNDECIPHERABLE = 493,
        PJSIP_SC_INTERNAL_SERVER_ERROR = 500,
        PJSIP_SC_NOT_IMPLEMENTED = 501,
        PJSIP_SC_BAD_GATEWAY = 502,
        PJSIP_SC_SERVICE_UNAVAILABLE = 503,
        PJSIP_SC_SERVER_TIMEOUT = 504,
        PJSIP_SC_VERSION_NOT_SUPPORTED = 505,
        PJSIP_SC_MESSAGE_TOO_LARGE = 513,
        PJSIP_SC_BUSY_EVERYWHERE = 600,
        PJSIP_SC_DECLINE = 603,
        PJSIP_SC_DOES_NOT_EXIST_ANYWHERE = 604,
        PJSIP_SC_NOT_ACCEPTABLE_ANYWHERE = 606,
        PJSIP_SC_TSX_TIMEOUT = 701,
        PJSIP_SC_TSX_RESOLVE_ERROR = 702,
        PJSIP_SC_TSX_TRANSPORT_ERROR = 703,
    }
    #endregion
}
