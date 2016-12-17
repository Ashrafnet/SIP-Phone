using System;
using System.Collections.Generic;
using System.Text;
using SIPProvider.Common;
using SIPProvider.CallRecords;



namespace SIPProvider.SIPCore.Interfaces
{
    /// <summary>
    /// Container providing call log functionality
    /// </summary>
    public interface ICallLogInterface
    {
        /// <summary>
        /// Add call to call log
        /// </summary>
        /// <param name="type">call mode</param>
        /// <param name="number">calling/called number</param>
        /// <param name="name">calling/called name</param>
        /// <param name="time">time of call</param>
        /// <param name="duration">duration of call</param>
        void addCall(ECallType type, string number, string name, System.DateTime time, System.TimeSpan duration);

        /// <summary>
        /// get list of logged calls
        /// </summary>
        /// <returns>Call log list</returns>
        List<CCallRecord> getList();

        /// <summary>
        /// get list of logged calls by call mode
        /// </summary>
        /// <param name="type">call mode</param>
        /// <returns>Call log list</returns>
        List<CCallRecord> getList(ECallType type);

        List<CCallRecord> SearchList(ECallType type, Predicate<CCallRecord> match);
        /// <summary>
        /// Delete single record
        /// </summary>
        /// <param name="record">record to delete</param>
        void deleteRecord(long recordId);
    }
}
