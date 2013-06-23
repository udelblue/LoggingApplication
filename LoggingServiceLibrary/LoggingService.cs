using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LoggingEntities;
using LoggingRulesEngine;

namespace LoggingServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class LoggingService : ILoggingService
    {


      

        public void SubmitLog(Log log)
        {
            LogEntry logentry = new LogEntry();

            logentry.Category = log.Category;
            logentry.EventID = log.EventID;
            logentry.Message = log.Message;
            logentry.Priority = log.Priority;
            logentry.Severity = log.Severity; 
            logentry.Title = log.Title; 

            LogEngine logengine = new LogEngine(logentry);
            logengine.Process();

        }
    }
}