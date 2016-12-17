using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore;

namespace Softphone
{
    public static class EnumToString
    {
        public static string GetCallType(ECallType type)
        {
            switch (type)
            {
                case ECallType.EDialed: return "Dialed Call";
                case ECallType.EMissed: return "EMissed Call";
                case ECallType.EReceived: return "Received Call";
                case ECallType.EUndefined: return "Undefined Call";
                default: return "";
            }
        }

        public static string GetCallState(EStateId type)
        {
            switch (type)
            {
                case EStateId.ACTIVE: return "Active Call.";
                case EStateId.ALERTING: return "Ringing..";
                case EStateId.CONNECTING: return "Connectiong..";
                case EStateId.HOLDING: return "Waiting..";
                case EStateId.IDLE: return "Idle";
                case EStateId.INCOMING: return "Incoming Call..";
                case EStateId.NULL: return "Ready.";
                case EStateId.RELEASED: return "Released.";
                case EStateId.TERMINATED: return "Terminated.";
                default: return "";
            }
        }

        public static string GetRegisterStatus(pjsip_status_code status)
        {
            switch (status)
            {
                case pjsip_status_code.PJSIP_SC_TRYING : return  "Trying Connect..";
                case pjsip_status_code.PJSIP_SC_RINGING : return  "Ringing..";
                case pjsip_status_code.PJSIP_SC_CALL_BEING_FORWARDED : return  "Call beging forwording.";
                case pjsip_status_code.PJSIP_SC_QUEUED : return  "Queued.";
                case pjsip_status_code.PJSIP_SC_PROGRESS : return  "Process..";
                case pjsip_status_code.PJSIP_SC_OK : return  "Connected.";
                case pjsip_status_code.PJSIP_SC_MULTIPLE_CHOICES : return  "Multible Choices.";
                case pjsip_status_code.PJSIP_SC_MOVED_PERMANENTLY : return  "Moved Permanently.";
                case pjsip_status_code.PJSIP_SC_MOVED_TEMPORARILY : return  "Moved Temporarily.";
                case pjsip_status_code.PJSIP_SC_USE_PROXY : return  "Use Proxy.";
                case pjsip_status_code.PJSIP_SC_ALTERNATIVE_SERVICE : return  "Alternative Service.";
                case pjsip_status_code.PJSIP_SC_BAD_REQUEST : return  "Bad Request.";
                case pjsip_status_code.PJSIP_SC_UNAUTHORIZED : return "UnAuthorized" ;
                case pjsip_status_code.PJSIP_SC_PAYMENT_REQUIRED : return  "Payment Required.";
                case pjsip_status_code.PJSIP_SC_FORBIDDEN : return  "Forbidden.";
                case pjsip_status_code.PJSIP_SC_NOT_FOUND : return  "Not Found.";
                case pjsip_status_code.PJSIP_SC_METHOD_NOT_ALLOWED : return  "Not Allowed.";
                case pjsip_status_code.PJSIP_SC_NOT_ACCEPTABLE : return  "Not Acceptable.";
                case pjsip_status_code.PJSIP_SC_PROXY_AUTHENTICATION_REQUIRED : return  "Proxy Authentication Required.";
                case pjsip_status_code.PJSIP_SC_REQUEST_TIMEOUT : return  "Request Time out.";
                case pjsip_status_code.PJSIP_SC_GONE : return  "Gone.";
                case pjsip_status_code.PJSIP_SC_REQUEST_ENTITY_TOO_LARGE : return  "Request Entity Too Large.";
                case pjsip_status_code.PJSIP_SC_REQUEST_URI_TOO_LONG : return  "Request URI Too Long.";
                case pjsip_status_code.PJSIP_SC_UNSUPPORTED_MEDIA_TYPE : return  "Unsupported Media Type.";
                case pjsip_status_code.PJSIP_SC_UNSUPPORTED_URI_SCHEME : return  "Unsupported URI Scheme.";
                case pjsip_status_code.PJSIP_SC_BAD_EXTENSION : return  "Bad Extention.";
                case pjsip_status_code.PJSIP_SC_EXTENSION_REQUIRED : return  "Extention Required.";
                case pjsip_status_code.PJSIP_SC_INTERVAL_TOO_BRIEF : return  "Interval Too Brief.";
                case pjsip_status_code.PJSIP_SC_TEMPORARILY_UNAVAILABLE : return  "Temporarily Unavailable.";
                case pjsip_status_code.PJSIP_SC_CALL_TSX_DOES_NOT_EXIST : return  "Call TSX does not Exists.";
                case pjsip_status_code.PJSIP_SC_LOOP_DETECTED : return  "Loop Detected.";
                case pjsip_status_code.PJSIP_SC_TOO_MANY_HOPS : return  "Too many Hops.";
                case pjsip_status_code.PJSIP_SC_ADDRESS_INCOMPLETE : return  "Address Incomplete.";
                case pjsip_status_code.PJSIP_AC_AMBIGUOUS : return  "Ambiguous.";
                case pjsip_status_code.PJSIP_SC_BUSY_HERE : return  "Busy Here.";
                case pjsip_status_code.PJSIP_SC_REQUEST_TERMINATED : return  "Resuest Terminated.";
                case pjsip_status_code.PJSIP_SC_NOT_ACCEPTABLE_HERE : return  "Not Acceptable Here.";
                case pjsip_status_code.PJSIP_SC_REQUEST_PENDING : return  "Request Binding.";
                case pjsip_status_code.PJSIP_SC_UNDECIPHERABLE : return  "UnDecipherable.";
                case pjsip_status_code.PJSIP_SC_INTERNAL_SERVER_ERROR : return  "Interval Service Error.";
                case pjsip_status_code.PJSIP_SC_NOT_IMPLEMENTED : return  "Not Implemented.";
                case pjsip_status_code.PJSIP_SC_BAD_GATEWAY : return  "Bad GateWay.";
                case pjsip_status_code.PJSIP_SC_SERVICE_UNAVAILABLE : return  "Unavailable.";
                case pjsip_status_code.PJSIP_SC_SERVER_TIMEOUT : return  "Service Timeout.";
                case pjsip_status_code.PJSIP_SC_VERSION_NOT_SUPPORTED : return  "Version Not Supported.";
                case pjsip_status_code.PJSIP_SC_MESSAGE_TOO_LARGE : return  "Message Too Large.";
                case pjsip_status_code.PJSIP_SC_BUSY_EVERYWHERE : return  "Busy Everywhere.";
                case pjsip_status_code.PJSIP_SC_DECLINE : return  "Decline.";
                case pjsip_status_code.PJSIP_SC_DOES_NOT_EXIST_ANYWHERE : return  "Does not Exist Anywhere.";
                case pjsip_status_code.PJSIP_SC_NOT_ACCEPTABLE_ANYWHERE : return  "Not Acceptable any Where.";
                case pjsip_status_code.PJSIP_SC_TSX_TIMEOUT : return  "TSX Timeout.";
                case pjsip_status_code.PJSIP_SC_TSX_RESOLVE_ERROR : return  "TSX Resolve Error.";
                case pjsip_status_code.PJSIP_SC_TSX_TRANSPORT_ERROR : return  "TSX Transport Error.";
                case (pjsip_status_code)(-1): return "LoggedOff.";
                case (pjsip_status_code)(171111): return "Username or password is not valid."; 
                default: return "UnKnown.";
            }
        }
    }
}
