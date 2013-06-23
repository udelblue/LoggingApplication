using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggingEntities
{
    public class LogEntry
    {
        public string Category { get; set; }
        public string Priority { get; set; }
        public string EventID { get; set; }
        public string Severity { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

    }
}
