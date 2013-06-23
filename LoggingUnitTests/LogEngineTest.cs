using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LoggingRulesEngine;
using LoggingEntities;

using System.IO;

namespace LoggingUnitTests
{
    [TestClass]
    public class LogEngineTest
    {
       
        
        [TestMethod]
        public void TestLogEngineExecuteAction()
        {
            LogEngine engine = new LogEngine();
            LogEntry _log = new LogEntry(){Title = "Test Log",Message = "Testing the log engine", Category= "test", EventID="", Severity="", Priority="urgent"};

            string[] _args = { @"log.txt" };
            bool _value = false;

              _value = engine.ReflectBusinessAction(@"C:\Users\Csommers\Documents\visual studio 2010\Projects\BusinessActionLibrary\BusinessActionLib\bin\Debug\BusinessActionLib.dll", "BusinessActionLib.WritetoFile", _log, _args);

              Assert.IsNotNull(_value);
             

        }

        [TestMethod]
        public void TestLogEngineExecuteRule()
        {
            LogEngine engine = new LogEngine();
            LogEntry _log = new LogEntry() { Title = "Test Log", Message = "Testing the log engine sample", Category = "test", EventID = "", Severity = "", Priority = "urgent" };

            string[] _args = { "Execute" , "Example", "Simple" , "sample"};
            bool _value = false;

            _value = engine.ReflectBusinessAction(@"C:\Users\Csommers\Documents\visual studio 2010\Projects\BusinessRuleLibrary\BusinessRuleLib\bin\Debug\BusinessRuleLib.dll", "BusinessRuleLib.SearchLogMessage", _log, _args);

            Assert.IsNotNull(_value);
           

        }


        [TestMethod]
        public void TestLogEngineProcess()
        {
            
            LogEntry _log = new LogEntry() { Title = "Test Log", Message = "Testing the log engine sample", Category = "test", EventID = "", Severity = "", Priority = "urgent" };

            string[] _args = { "Execute", "Example", "Simple", "sample" };
            bool _value = false;

            LogEngine engine = new LogEngine(_log);
            engine.Process();
            
            //_value = engine.ReflectBusinessAction(@"C:\Users\Csommers\Documents\visual studio 2010\Projects\BusinessRuleLibrary\BusinessRuleLib\bin\Debug\BusinessRuleLib.dll", "BusinessRuleLib.SearchLogMessage", _log, _args);


            Assert.IsInstanceOfType(engine, typeof(LogEngine));

           // Assert.IsNotNull(_value);
           // Assert.IsTrue(_value);

        }




    }
}
