using System;
using System.Collections.Generic;
using System.Text;

namespace SIPProvider.CallRecords
{
    internal class CallRecordComparer : IComparer<CCallRecord>
    {
        private static CallRecordComparer _instance = null;
        public static CallRecordComparer Instance
        {
            get
            {
                if (_instance == null) _instance = new CallRecordComparer();
                return _instance;
            }
        }
        #region IComparer<PhoneUser> Members

        public int Compare(CCallRecord x, CCallRecord y)
        {
            try { return y.Time.CompareTo(x.Time); }
            catch { return 0; }
        }

        #endregion
    }
}
