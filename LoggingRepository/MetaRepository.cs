using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessRulesEntities.MetaEntities;

namespace LoggingRepository
{
    public class MetaRepository
    {

        LoggingApplicationModel repository;

        public MetaRepository()
        {
            repository = new LoggingApplicationModel();
        }

        public MetaRepository(string connectionString)
        {
            repository = new LoggingApplicationModel(connectionString);
        }

        public IEnumerable<MetaRuleAction> RuleActionCollectionAll()
        {

            return repository.MetaRuleActions.ToList();
        }

        public List<RuleActionCollection> RuleActionCollection(string logCategory)
        {
           
            
            
            List<RuleActionCollection> collection = new List<RuleActionCollection>();
            IEnumerable<MetaRuleAction> result = repository.MetaRuleActions.Where(a => logCategory == a.LogCategory);

            foreach (MetaRuleAction mra in result)
            {
                MetaRule mr = new MetaRule();
                mr.Name = mra.RuleName;
                mr.Assembly = mra.RuleAssembly;
                mr.Class = mra.RuleClass;

                mr.Args = repository.BusinessRulesArgs.Where(a => a.MetaFK == mra.MetaID).Select(a => a.Args).ToList();

                MetaAction ma = new MetaAction();
                ma.Name = mra.ActionName;
                ma.Assembly = mra.ActionAssembly;
                ma.Class = mra.ActionClass;

                ma.Args = repository.BusinessActionArgs.Where(a => a.MetaFK == mra.MetaID).Select(a => a.Args).ToList();

                RuleActionCollection rac = new RuleActionCollection(mr, ma);
                collection.Add(rac);

            }



            return collection;
        }

        public int NumberofRules(string logCategory)
        {

            return repository.MetaRuleActions.Where(a => a.LogCategory == logCategory).Count();

        }

        public List<string> GetActionArgs(string logCategory)
        {
            int id = repository.MetaRuleActions.Where(a => a.LogCategory == logCategory).Select(a => a.MetaID).Single();
            List<string> list = repository.BusinessActionArgs.Where(a => a.MetaFK == id).Select(a => a.Args).ToList();
            return list;
        }

        public List<string> GetRuleArgs(string logCategory)
        {
            int id = repository.MetaRuleActions.Where(a => a.LogCategory == logCategory).Select(a => a.MetaID).Single();
            List<string> list = repository.BusinessRulesArgs.Where(a => a.MetaFK == id).Select(a => a.Args).ToList();
            return list;
        }

        public string GetRuleAssembly(string logCategory)
        {
            string assembly = repository.MetaRuleActions.Where(a => a.LogCategory == logCategory).Select(a => a.RuleAssembly).Single();
            return assembly;
        }

        public string GetRuleClass(string logCategory)
        {
            string assembly = repository.MetaRuleActions.Where(a => a.LogCategory == logCategory).Select(a => a.RuleClass).Single();
            return assembly;
        }

        public string GetActionAssembly(string logCategory)
        {
            string assembly = repository.MetaRuleActions.Where(a => a.LogCategory == logCategory).Select(a => a.ActionAssembly).Single();
            return assembly;
        }

        public string GetActionClass(string logCategory)
        {
            string assembly = repository.MetaRuleActions.Where(a => a.LogCategory == logCategory).Select(a => a.ActionClass).Single();
            return assembly;
        }

    }
}
