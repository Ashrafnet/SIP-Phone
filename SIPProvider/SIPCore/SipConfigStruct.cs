using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SIPProvider.SIPCore
{
    /// <summary>
    /// Sip Config structure. 
    /// BE CAREFUL!
    /// SYNCHRONIZE FIELDS WITH C-STRUCTURE IN PJSIPDLL.H!!!!!
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class SipConfigStruct
    { 
        private static SipConfigStruct _instance = null;
        public static SipConfigStruct Instance
        {
            get
            {
                if (_instance == null) _instance = new SipConfigStruct();
                return _instance;
            }
        }

        public int listenPort = 5060;
        [MarshalAs(UnmanagedType.I1)]   // warning:::Marshal managed bool type to unmanaged (C) bool !!!!
        public bool noUDP = false;
        [MarshalAs(UnmanagedType.I1)]
        public bool noTCP = true;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string stunServer;
        [MarshalAs(UnmanagedType.I1)]
        public bool publishEnabled = false;

        public int expires = 1200;

        [MarshalAs(UnmanagedType.I1)]
        public bool VADEnabled = true;

        public int ECTail = 256;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string nameServer;

        [MarshalAs(UnmanagedType.I1)]
        public bool pollingEventsEnabled = false;

        public int logLevel = 0;

        // IMS specifics
        [MarshalAs(UnmanagedType.I1)]
        public bool imsEnabled = false; // secAgreement rfc 3329
        [MarshalAs(UnmanagedType.I1)]
        public bool imsIPSecHeaders = false;
        [MarshalAs(UnmanagedType.I1)]
        public bool imsIPSecTransport = false;
    }
}
