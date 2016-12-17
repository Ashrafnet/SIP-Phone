using System;
using System.Collections.Generic;

using System.Text;
using SIPProvider.SIPCore.Interfaces;

namespace SIPProvider.SIPCore
{
    public class pjsipCallProxy : ICallProxyInterface 
   {
     
       #region Properties
       private IConfiguratorInterface _config;

       private IConfiguratorInterface Config
       {
           get { return _config; }
       }

       private int _sessionId;
       public override int SessionId
       {
           get { return _sessionId; }
           set { _sessionId = value; }
       }
       #endregion

       #region Constructor

       /// <summary>
       /// Constructor called by pjsipWrapper with Config parameter. 
       /// Make sure you set Config in pjsipWrapper before using pjsipCallProxy
       /// </summary>
       /// <param name="config"></param>
       internal pjsipCallProxy(IConfiguratorInterface config)
       {
           _config = config;
       }

       // Static declaration because of CallbackonCollectedDelegate exception!
       static OnCallStateChanged csDel = new OnCallStateChanged(onCallStateChanged);
       static OnCallIncoming ciDel = new OnCallIncoming(onCallIncoming);
       static OnCallHoldConfirm chDel = new OnCallHoldConfirm(onCallHoldConfirm);

       /// <summary>
       /// Static initializer. Call this method to set callbacks from SIP stack. 
       /// </summary>
       public static void initialize()
       {
           // assign callbacks
           PjsipMethods.onCallIncoming(ciDel);
           PjsipMethods.onCallStateCallback(csDel);
           PjsipMethods.onCallHoldConfirmCallback(chDel);
       }

       #endregion Constructor

       #region Public Methods

       /// <summary>
       /// Method makeCall creates call session. Checks the 1st parameter 
       /// format is SIP URI, if not build one.  
       /// </summary>
       /// <param name="dialedNo"></param>
       /// <param name="accountId"></param>
       /// <returns>SessionId chosen by pjsip stack</returns>
       public override  int makeCall(string dialedNo, int accountId)
       {
           string sipuri = "";

           // check if call by URI
           if (dialedNo.IndexOf("sip:") == 0)
           {
               // do nothing...
               sipuri = dialedNo;
           }
           else
           {
               // prepare URI
               sipuri = "sip:" + dialedNo + "@" + Config.Accounts[accountId].HostName;
           }
           // Select configured transport for this account: udp, tcp, tls 
           sipuri = pjsipStackProxy.Instance.SetTransport(accountId, sipuri);

           // Don't forget to convert accontId here!!!
           // Store session identification for further requests
           SessionId = PjsipMethods.dll_makeCall(Config.Accounts[accountId].Index, sipuri);

           return SessionId;
       }

       /// <summary>
       /// End call for a given session
       /// </summary>
       /// <param name="sessionId"></param>
       /// <returns></returns>
       public override  bool endCall()
       {
           PjsipMethods.dll_releaseCall(SessionId);
           return true;
       }

       /// <summary>
       /// Signals sip stack that device is alerted (ringing)
       /// </summary>
       /// <param name="sessionId"></param>
       /// <returns></returns>
       public override  bool alerted()
       {
           PjsipMethods.dll_answerCall(SessionId, 180);
           return true;
       }

       /// <summary>
       /// Signals that user accepts the call (asnwer)
       /// </summary>
       /// <param name="sessionId"></param>
       /// <returns></returns>
       public override  bool acceptCall()
       {
           PjsipMethods.dll_answerCall(SessionId, 200);
           return true;
       }

       /// <summary>
       /// Hold request for a given session
       /// </summary>
       /// <param name="sessionId"></param>
       /// <returns></returns>
       public override  bool holdCall()
       {
           PjsipMethods.dll_holdCall(SessionId);
           return true;
       }

       /// <summary>
       /// Retrieve request for a given session
       /// </summary>
       /// <param name="sessionId"></param>
       /// <returns></returns>
       public override  bool retrieveCall()
       {
           PjsipMethods.dll_retrieveCall(SessionId);
           return true;
       }

       /// <summary>
       /// Trasfer call to number
       /// </summary>
       /// <param name="sessionId"></param>
       /// <param name="number"></param>
       /// <returns></returns>
       public override  bool xferCall(string number)
       {
           string uri = "sip:" + number + "@" + Config.Accounts[Config.DefaultAccountIndex].HostName;
           PjsipMethods.dll_xferCall(SessionId, uri);
           return true;
       }

       /// <summary>
       /// Transfer call to other session
       /// </summary>
       /// <param name="sessionId"></param>
       /// <param name="session"></param>
       /// <returns></returns>
       public override  bool xferCallSession(int session)
       {
           PjsipMethods.dll_xferCallWithReplaces(SessionId, session);
           return true;
       }

       /// <summary>
       /// Make conference with given session
       /// </summary>
       /// <param name="sessionId"></param>
       /// <param name="session"></param>
       /// <returns></returns>
       public override  bool threePtyCall(int session)
       {
           PjsipMethods.dll_serviceReq(SessionId, (int)EServiceCodes.SC_3PTY, "");
           return true;
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="sessionId"></param>
       /// <param name="code"></param>
       /// <param name="dest"></param>
       /// <returns></returns>
       public override  bool serviceRequest(int code, string dest)
       {
           string destUri = "<sip:" + dest + "@" + Config.Accounts[Config.DefaultAccountIndex].HostName + ">";
           PjsipMethods.dll_serviceReq(SessionId, (int)code, destUri);
           return true;
       }

       /// <summary>
       /// Send dtmf digit
       /// </summary>
       /// <param name="sessionId"></param>
       /// <param name="digits"></param>
       /// <param name="mode"></param>
       /// <returns></returns>
       public override  bool dialDtmf(string digits, EDtmfMode mode)
       {
           int status = PjsipMethods.dll_dialDtmf(SessionId, digits, (int)mode);
           return true;
       }

       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       public override  string getCurrentCodec()
       {
           StringBuilder codec = new StringBuilder(256);
           int status = PjsipMethods.dll_getCurrentCodec(SessionId, codec);
           return codec.ToString();
       }

       /// <summary>
       /// Make a conference call
       /// </summary>
       /// <returns></returns>
       public override  bool conferenceCall()
       {
           int status = PjsipMethods.dll_makeConference(SessionId);
           return status == 1 ? true : false;
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="message"></param>
       /// <returns></returns>
       public override  bool sendCallMessage(string message)
       {
           int status = PjsipMethods.dll_sendCallMessage(SessionId, message);
           return (status == 1) ? true : false;
       }

       #endregion Methods

       #region Callbacks

       /// <summary>
       /// 
       /// </summary>
       /// <param name="callId"></param>
       /// <param name="callState"></param>
       /// <returns></returns>
       private static int onCallStateChanged(int callId, ESessionState callState)
       {
           BaseCallStateChanged(callId, callState, "");
           return 0;
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="callId"></param>
       /// <param name="sturi"></param>
       /// <returns></returns>
       private static int onCallIncoming(int callId, string sturi)
       {
           string uri = sturi;
           string display = "";
           string number = "";

           if (null != uri)
           {
               // get indices
               int startNum = uri.IndexOf("<sip:");
               int atPos = uri.IndexOf('@');
               // search for number
               if ((startNum >= 0) && (atPos > startNum))
               {
                   number = uri.Substring(startNum + 5, atPos - startNum - 5);
               }

               // extract display name if exists
               if (startNum >= 0)
               {
                   display = uri.Remove(startNum, uri.Length - startNum).Trim();
               }
               else
               {
                   int semiPos = display.IndexOf(';');
                   if (semiPos >= 0)
                   {
                       display = display.Remove(semiPos, display.Length - semiPos);
                   }
                   else
                   {
                       int colPos = display.IndexOf(':');
                       if (colPos >= 0)
                       {
                           display = display.Remove(colPos, display.Length - colPos);
                       }
                   }

               }
           }
           // invoke callback
           BaseIncomingCall(callId, number, display);
           return 1;
       }

       /// <summary>
       /// Not used
       /// </summary>
       /// <param name="callId"></param>
       /// <returns></returns>
       private static int onCallHoldConfirm(int callId)
       {
           //if (sm != null) sm.getState().onHoldConfirm();
           // TODO:::implement proper callback
           BaseCallNotification(callId, ECallNotification.CN_HOLDCONFIRM, "");
           return 1;
       }
       #endregion
   }
}
