using System;
using System.Collections.Generic;
using System.Text;

namespace SIPProvider.PhoneBookSaver
{
    internal class PhoneUserComparer1 : IComparer<PhoneUser>
    {
        private static PhoneUserComparer1 _instance = null;
        public static PhoneUserComparer1 Instance
        {
            get
            {
                if (_instance == null) _instance = new PhoneUserComparer1();
                return _instance;
            }
        }
        #region IComparer<PhoneUser> Members

        public int Compare(PhoneUser x, PhoneUser y)
        {
            try { return x.UserName.CompareTo(y.UserName); }
            catch { return 0; }
        }

        #endregion
    }
}
