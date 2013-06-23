using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LoggingEntities;

namespace BusinessRulesEntities
{
    interface IBusiness
    {
        //void Init(LogEntry log, string[] Args);
        bool Invoke(LogEntry log, string[] Args);
    }
}
