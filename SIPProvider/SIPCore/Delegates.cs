using System;
using System.Collections.Generic;

using System.Text;

namespace SIPProvider.SIPCore
{
    // callback delegates
   internal delegate int OnCallStateChanged(int callId, ESessionState stateId);
   internal delegate int OnCallIncoming(int callId, string number);
   internal delegate int OnCallHoldConfirm(int callId);
   internal delegate int OnDtmfDigitCallback(int callId, int digit);
   internal delegate int OnMessageWaitingCallback(int mwi, string info);
   //internal delegate int OnCallReplacedCallback(int oldid, int newid);

   // event methods prototypes
   public delegate void DDtmfDigitReceived(int callId, int digit);
   public delegate void DMessageWaitingNotification(int mwi, string text);
   public delegate void DCallReplaced(int oldid, int newid);

   #region CallProxy interface

   public delegate void DCallStateChanged(int callId, ESessionState callState, string info);
   public delegate void DCallIncoming(int callId, string number, string info);
   public delegate void DCallNotification(int callId, ECallNotification notFlag, string text);

   #endregion

   /// <summary>
   /// Account state change delegate
   /// </summary>
   /// <param name="accountId">account identification</param>
   /// <param name="accState">account status</param>
   public delegate void DAccountStateChanged(int accountId, int accState);

   // registration state change delegate
  internal  delegate int OnRegStateChanged(int accountId, int regState);

  //PresenceAndMessaging
  public delegate void DMessageReceived(string from, string text);
  public delegate void DBuddyStatusChanged(int buddyId, int status, string text);

 internal delegate int OnMessageReceivedCallback(string from, string message);
 internal delegate int OnBuddyStatusChangedCallback(int buddyId, int status, string statusText);

 /// <summary>
 /// Timer expiration callback
 /// </summary>
 /// <param name="sender"></param>
 /// <param name="e"></param>
 public delegate void TimerExpiredCallback(object sender, EventArgs e);

 //for CCallManager class
 public delegate void DCallStateRefresh(int sessionId);
 public delegate void DIncomingCallNotification(int sessionId, string number, string info);

 /// <summary> 
 /// delegate for data changed events
 /// </summary>
 /// <param name="dataName"></param>
 /// <param name="valueString"></param>
 public delegate void DataChanged(object sender, DataChangeEventArgs e);
 /// <summary>
 /// delegate for Item Removed events
 /// </summary>
 /// <param name="sender"></param>
 public delegate void ItemRemoved(object sender);
 /// <summary>
 /// delegate for Item added events
 /// </summary>
 /// <param name="sender"></param>
 public delegate void ItemAdded(object sender); 
}
