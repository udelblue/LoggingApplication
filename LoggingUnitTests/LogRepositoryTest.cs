using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using LoggingEntities;
using LoggingRepository;
using System.Data.Entity;



namespace LoggingUnitTests
{
    [TestClass]
    public class LogRepositoryTest
    {
        [TestMethod]
        public void InsertLogTest()
        {
            LogEntry log = new LogEntry() { Title = "Test Log", Message = "Testing the log insert", Category = "test", EventID = "test", Severity = "test", Priority = "urgent" };



            LogRepository repository = new LogRepository();
            repository.Insert(log);
        

            Assert.IsNotNull(log);
            

            
        }
    }
}
