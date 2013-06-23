using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LoggingEntities;

namespace BusinessRulesEntities
{
    public class BusinessAction : IBusiness
    {
        public LogEntry _log;
        public List<string> _args;
        public bool _pass = false;

        int _argsCount = 0;

        public BusinessAction()
        {

        }

        public BusinessAction(LogEntry log, string[] Args)
        {
            _log = log;

            foreach (string arg in Args)
            {
                if (!string.IsNullOrEmpty(arg))
                {
                    _args.Add(arg);
                    _argsCount++;
                }
            }
        }

        public virtual bool Invoke(LogEntry log, string[] Args)
        {
            return _pass;
        }


        public void Init(LogEntry log, string[] Args)
        {
            _log = log;

            foreach (string arg in Args)
            {
                if (!string.IsNullOrEmpty(arg))
                {
                    _args.Add(arg);
                    _argsCount++;
                }
            }
        }
    }
}
