using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.NullValues;
using SIPProvider.SIPCore.Interfaces;

namespace SIPProvider.SIPCore.NullValues
{
    public class NullVoipProxy : IVoipProxy
    {
        #region ICommonProxyInterface Members

        public override int initialize()
        {
            return 1;
        }

        public override int shutdown()
        {
            return 1;
        }


        public override void setCodecPriority(string item, int p)
        {
        }
        public override int getNoOfCodecs() { return 0; }

        public override string getCodec(int i) { return ""; }

        public override bool IsInitialized
        {
            get
            {
                return false;
            }
            set
            {
                ;
            }
        }

        public override ICallProxyInterface createCallProxy()
        {
            return new NullCallProxy();
        }
        #endregion

    }
}
