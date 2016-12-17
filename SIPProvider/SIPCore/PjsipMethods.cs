using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;

namespace SIPProvider.SIPCore
{
   internal static class PjsipMethods
    {

      //static void cc()
      // {
      //     DllImportAttribute c = new DllImportAttribute(PJSIP_DLL);
      //    Assembly
      // }
#if LINUX
		internal const string PJSIP_DLL = "libpjsipDll.so"; 
#elif MOBILE
		internal const string PJSIP_DLL = "pjsipdll_mobile.dll"; 
#elif TLS
		internal const string PJSIP_DLL = "pjsipdll_tls.dll"; 
#else
    internal const string PJSIP_DLL = "pjsipDll.dll";
#endif

    //main methods
    [DllImport(PJSIP_DLL, EntryPoint = "dll_init")]
    internal static extern int dll_init();
    [DllImport(PJSIP_DLL, EntryPoint = "dll_main")]
    internal static extern int dll_main();
    [DllImport(PJSIP_DLL, EntryPoint = "dll_shutdown")]
    internal static extern int dll_shutdown();
    [DllImport(PJSIP_DLL, EntryPoint = "dll_setSipConfig")]
    internal static extern void dll_setSipConfig(SipConfigStruct config);

    [DllImport(PJSIP_DLL, EntryPoint = "dll_getCodec")]
    internal static extern int dll_getCodec(int index, StringBuilder codec);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_getNumOfCodecs")]
    internal static extern int dll_getNumOfCodecs();
    [DllImport(PJSIP_DLL, EntryPoint = "dll_setCodecPriority")]
    internal static extern int dll_setCodecPriority(string name, int prio);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_setSoundDevice")]
    internal static extern int dll_setSoundDevice(string playbackDeviceId, string recordingDeviceId);

    [DllImport(PJSIP_DLL, EntryPoint = "dll_callRecording_start")]
    internal static extern int dll_callRecording_start(int callId,string strPath);

    [DllImport(PJSIP_DLL, EntryPoint = "dll_callRecording_stop")]
    internal static extern int dll_callRecording_stop(int callId);

    // call API
    [DllImport(PJSIP_DLL, EntryPoint = "dll_makeCall")]
    internal static extern int dll_makeCall(int accountId, string uri);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_releaseCall")]
    internal static extern int dll_releaseCall(int callId);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_answerCall")]
    internal static extern int dll_answerCall(int callId, int code);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_holdCall")]
    internal static extern int dll_holdCall(int callId);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_retrieveCall")]
    internal static extern int dll_retrieveCall(int callId);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_xferCall")]
    internal static extern int dll_xferCall(int callId, string uri);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_xferCallWithReplaces")]
    internal static extern int dll_xferCallWithReplaces(int callId, int dstSession);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_serviceReq")]
    internal static extern int dll_serviceReq(int callId, int serviceCode, string destUri);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_dialDtmf")]
    internal static extern int dll_dialDtmf(int callId, string digits, int mode);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_getCurrentCodec")]
    internal static extern int dll_getCurrentCodec(int callId, StringBuilder codec);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_makeConference")]
    internal static extern int dll_makeConference(int callId);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_sendMessage")]
    internal static extern int dll_sendCallMessage(int callId, string message);

    //pjsipRegistrar
    [DllImport(PJSIP_DLL, EntryPoint = "dll_registerAccount")]
    internal static extern int dll_registerAccount(string uri, string reguri, string domain, string username, string password, string proxy, bool isdefault);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_removeAccounts")]
    internal static extern int dll_removeAccounts();

    //pjsipPresenceAndMessaging
    [DllImport(PJSIP_DLL, EntryPoint = "dll_addBuddy")]
    internal static extern int dll_addBuddy(string uri, bool subscribe);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_removeBuddy")]
    internal static extern int dll_removeBuddy(int buddyId);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_sendMessage")]
    internal static extern int dll_sendMessage(int buddyId, string uri, string message);
    [DllImport(PJSIP_DLL, EntryPoint = "dll_setStatus")]
    internal static extern int dll_setStatus(int accId, int presence_state);

    #region Callback Declarations
    // passing delegates to unmanaged code (.dll)
    [DllImport(PJSIP_DLL)]
    internal static extern int onCallStateCallback(OnCallStateChanged cb);
    [DllImport(PJSIP_DLL)]
    internal static extern int onCallIncoming(OnCallIncoming cb);
    [DllImport(PJSIP_DLL)]
    internal static extern int onCallHoldConfirmCallback(OnCallHoldConfirm cb);

    [DllImport(PJSIP_DLL, EntryPoint = "onDtmfDigitCallback")]
    internal static extern int onDtmfDigitCallback(OnDtmfDigitCallback cb);
    [DllImport(PJSIP_DLL, EntryPoint = "onMessageWaitingCallback")]
    internal static extern int onMessageWaitingCallback(OnMessageWaitingCallback cb);
    //[DllImport(PJSIP_DLL, EntryPoint = "onCallReplaced")]
    //internal static extern int onCallReplacedCallback(OnCallReplacedCallback cb);

    //pjsipRegistrar
    [DllImportAttribute(PJSIP_DLL, EntryPoint = "onRegStateCallback")]
    internal static extern int onRegStateCallback(OnRegStateChanged cb);

    //pjsipPresenceAndMessaging
    [DllImport(PJSIP_DLL)]
    internal static extern int onMessageReceivedCallback(OnMessageReceivedCallback cb);
    [DllImport(PJSIP_DLL)]
    internal static extern int onBuddyStatusChangedCallback(OnBuddyStatusChangedCallback cb);
    #endregion
    }
}
