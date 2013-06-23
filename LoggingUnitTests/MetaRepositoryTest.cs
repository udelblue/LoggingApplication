using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LoggingEntities;
using LoggingRepository;
using System.Data.Entity;
using BusinessRulesEntities.MetaEntities;

namespace LoggingUnitTests
{
    [TestClass]
    public class MetaRepositoryTest
    {
        [TestMethod]
        public void RuleActionCollection()
        {
            MetaRepository repository = new MetaRepository();
           List<RuleActionCollection> collection = repository.RuleActionCollection("test");
           Assert.IsNotNull(collection);

        }

        [TestMethod]
        public void RuleActionCollectionNotZero()
        {
            
            MetaRepository repository = new MetaRepository();
            List<RuleActionCollection> collection = repository.RuleActionCollection("test");
            Assert.AreNotSame(0, collection.Count);

        }
    }
}
