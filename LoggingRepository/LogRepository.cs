using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LoggingEntities;
using System.Data.Entity;


namespace LoggingRepository
{
    public class LogRepository
    {

        LoggingApplicationModel repostitory;

        public LogRepository()
        {
            repostitory = new LoggingApplicationModel();
        }

        public LogRepository(string connnectionString)
        {
            repostitory = new LoggingApplicationModel(connnectionString);
        }


        public void Insert(LogEntry log)
        {
            Log dblog = LogEntrytoLog(log);
            repostitory.AddToLogs(dblog);
            repostitory.SaveChanges();

        }

        /// <summary>
        /// convert business object to data model
        /// </summary>
        /// <param name="log"></param>
        /// <returns>Log of the entity model</returns>
        private Log LogEntrytoLog(LogEntry log)
        {

            Log _log = new Log();
            _log.Category = log.Category;
            _log.Message = log.Message;
            _log.Priority = log.Priority;
            _log.Severity = log.Severity;
            _log.Title = log.Title;
            return _log;

        }

    }
}
