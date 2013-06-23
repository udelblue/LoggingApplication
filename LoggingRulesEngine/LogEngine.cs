using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoggingEntities;
using System.Reflection;

using BusinessRulesEntities;
using BusinessRulesEntities.MetaEntities;
using LoggingRepository;
using System.Configuration;


using System.IO;

namespace LoggingRulesEngine
{
    public class LogEngine
    {

        LogEntry _log;
        LogRepository _repository = new LogRepository();
        MetaRepository _metarepository = new MetaRepository();
        //string _assembly = null;
        //string _class = null;
        //string[] _args;

        string _assemblyRulePath = "";
        string _assemblyActionPath = "";

            public LogEngine()
            {
                setPaths();
            }

            public LogEngine(LogEntry log)
            {
                _log = log;
                setPaths();
            }


            public void setPaths() 
            {
          

                _assemblyRulePath = System.Configuration.ConfigurationManager.AppSettings["RulePath"];
                _assemblyActionPath = System.Configuration.ConfigurationManager.AppSettings["ActionPath"];

               _assemblyRulePath = _assemblyRulePath ?? @"C:\Users\Csommers\Documents\visual studio 2010\Projects\LoggingApplication\LoggingRulesEngine\bin\Debug";
               _assemblyActionPath = _assemblyActionPath ?? @"C:\Users\Csommers\Documents\visual studio 2010\Projects\LoggingApplication\LoggingRulesEngine\bin\Debug";
            }
         

        /// <summary>
        /// Method responsible for processing Logs
        /// </summary>
            public void Process()
            {
                try
                {

                    MetaRepository _metarepository = new MetaRepository();
                    List<RuleActionCollection> _rulecollection = _metarepository.RuleActionCollection(_log.Category.ToLower());

                    if (_rulecollection.Count >= 1)
                    {


                        foreach (RuleActionCollection RAC in _rulecollection)
                        { 

                            bool pass = ReflectBusinessRule(_assemblyRulePath + @"\"+ RAC.MetaRule.Assembly, RAC.MetaRule.Class, _log, RAC.MetaRule.Args.ToArray());
                            if (pass == false)
                            {
                                ReflectBusinessAction(_assemblyActionPath + @"\" + RAC.MetaAction.Assembly, RAC.MetaAction.Class, _log, RAC.MetaAction.Args.ToArray());
                            }

                        }

                        _repository.Insert(_log);
                        #region cut code
                        //if (_metarepository.NumberofRules(_log.Category) >= 1)
                        //{
                        //    bool pass = true;
                        //    _assembly = _metarepository.GetRuleAssembly(_log.Category);
                        //    _class =  _metarepository.GetRuleClass(_log.Category);
                        //    _args = _metarepository.GetRuleArgs(_log.Category).ToArray();
                        //    pass = ReflectBusinessRule(_assembly,_class,_log,_args);

                        //    if (!pass)
                        //    {
                        //        _assembly = _metarepository.GetActionAssembly(_log.Category);
                        //        _class = _metarepository.GetActionClass(_log.Category);
                        //        _args = _metarepository.GetActionArgs(_log.Category).ToArray();
                        //        ReflectBusinessAction(_assembly, _class, _log, _args);

                        //    }
                        //    else
                        //    {
                        //        _repository.Insert(_log);
                        //    }
                        //}
                        //else
                        //{
                        //    _repository.Insert(_log);
                        //}
                        #endregion


                    }

                    else
                    {
                        _repository.Insert(_log);
                    }

                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Date: " + DateTime.Now.ToLongDateString());
                    sb.AppendLine("Message: " + ex.Message);
                    sb.AppendLine("Stacktrace: " + ex.StackTrace);
                    sb.AppendLine("-------------------------------------------");

                    WritetoLog(sb);
                }




            }

        /// <summary>
        /// dlls of business rules
        /// </summary>
        /// <param name="assembly"></param> string to dll
        /// <param name="namespaceandclass"></param>string of namespace.class
        /// <param name="log"></param>log
        /// <param name="args"></param> 
        /// <returns></returns>
        public bool ReflectBusinessRule(string assembly, string namespaceandclass,  LogEntry log, string[] args) {

            string[] _args = args;

            string method = "Invoke";

            bool value = false;

            try
            {
                // dynamically load assembly from file Test.dll
                Assembly BussAssembly = Assembly.LoadFile(assembly);

                // get type of class Calculator from just loaded assembly
                Type BussType = BussAssembly.GetType(namespaceandclass);

                // create instance of class Calculator
                object BussInstance = Activator.CreateInstance(BussType);

                // invoke public instance method: public double Add(double number)

                 value = (bool)BussType.InvokeMember(method,
                 BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
                 null, BussInstance, new object[] {log, args});

            }
            catch (Exception ex)
            {
                if (!Directory.Exists(@"C:\LoggingApplication\LogEngine"))
                {
                    Directory.CreateDirectory(@"C:\LoggingApplication\LogEngine");
                }

                using (StreamWriter sw = new StreamWriter(@"C:\LoggingApplication\LogEngine\ExceptionLog.txt"))
                {
                    sw.WriteLine("Exception: " + ex.Message);
                    sw.WriteLine("Message: " + ex.StackTrace);
                    sw.WriteLine("-------------------------");
                }
                
              
            }

            return value;

        }

        /// <summary>
        /// dlls of business actions
        /// </summary>
        /// <param name="assembly"></param> string to dll
        /// <param name="namespaceandclass"></param>string of namespace.class
        /// <param name="log"></param>log
        /// <param name="args"></param> 
        /// <returns></returns>
        public bool ReflectBusinessAction(string assembly, string namespaceandclass, LogEntry log, string[] args)
        {


            string[] _args = args;
            
            string method = "Invoke";

            bool value = false;

            try
            {
                // dynamically load assembly from file Test.dll
                Assembly BussAssembly = Assembly.LoadFile(assembly);

                // get type of class Calculator from just loaded assembly
                Type BussType = BussAssembly.GetType(namespaceandclass);

                // create instance of class Calculator
                object BussInstance = Activator.CreateInstance(BussType);

                // invoke public instance method: public double Add(double number)

                value = (bool)BussType.InvokeMember(method,
                 BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
                 null, BussInstance, new object[] { log, _args });

            }
            catch (Exception ex)
            {
                if (!Directory.Exists(@"C:\LoggingApplication\LogEngine"))
                {
                    Directory.CreateDirectory(@"C:\LoggingApplication\LogEngine");
                }
                    
                using (StreamWriter sw = new StreamWriter(@"C:\LoggingApplication\LogEngine\ExceptionLog.txt"))
                {
                    sw.WriteLine("Exception: " + ex.Message);
                    sw.WriteLine("Message: " + ex.StackTrace);
                    sw.WriteLine("-------------------------");
                }

            }

            return value;

        }


        public void WritetoLog(StringBuilder toLog) 
        {

         

         

            if (!Directory.Exists(@"C:\LoggingApplication\LogEngine\"))
            {
                Directory.CreateDirectory(@"C:\LoggingApplication\LogEngine\");
            }

            using (StreamWriter sw = new StreamWriter(@"C:\LoggingApplication\LogEngine\" + "ExceptionLog.txt", true))
            {
                sw.Write(toLog.ToString());
            }

        
        }

    }
}
