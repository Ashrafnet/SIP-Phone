using System;
using System.Collections.Generic;
using System.Text;

namespace Softphone.SmsFolder
{
   public class SmsMsg
    {
       public long Id { get; set; }
       public string Message { get; set; }
       public int Reads { get; set; }
       public string subject { get; set; }
       public string Date { get; set; }
    }
}
