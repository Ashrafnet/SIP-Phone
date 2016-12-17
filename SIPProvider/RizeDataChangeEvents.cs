using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.SIPCore;

namespace SIPProvider
{
   public class RizeDataChangeEvents
    {
        /// <summary>
        /// Occur when any data field change
        /// </summary>
        internal event DataChanged OnDataChanging, OnDataChanged;

        /// <summary>
        /// return true if data changed accepted
        /// </summary>
        internal bool RiseEvent1(string dataName, object oldData, object newData)
        {
            try
            {
                if (oldData == newData) return false;
                DataChangeEventArgs args = new DataChangeEventArgs(dataName, oldData, newData);
                if (OnDataChanging != null) //begin change value
                    OnDataChanging(this, args);
                return !args.CancelEdit;
            }
            catch { return false; }
        }

        internal void RiseEvent2(string dataName, object oldData, object newData)
        {
            try
            {
                DataChangeEventArgs args = new DataChangeEventArgs(dataName, oldData, newData);
                if (OnDataChanged != null)//value has been changed
                    OnDataChanged(this, args);
            }
            catch { }
        }

    }
}
