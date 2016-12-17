using System;
using System.Collections.Generic;
using System.Text;

namespace SIPProvider
{
    public class DataChangeEventArgs
    {
        public string DataName { get; private set; }
        public object OldValue { get; private set; }
        public object NewValue { get; set; }
        public bool CancelEdit { get; set; }
        public DataChangeEventArgs(string DataName, object OldValue, object NewValue)
        {
            this.DataName = DataName;
            this.OldValue = OldValue;
            this.NewValue = NewValue;
        } 

        private string ToString(object value)
        {
            if (value is DateTime) return ((DateTime)value).ToBinary() + "";
            return value + "";
        }

        //public string OldValueString
        //{
        //    get
        //    {
        //        return ToString(OldValue);
        //    }
        //}

        //public string NewValueString
        //{
        //    get
        //    {
        //        return ToString(NewValue);
        //    }
        //}
    }
}
