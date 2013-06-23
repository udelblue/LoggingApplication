using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRulesEntities.MetaEntities
{
    public class RuleActionCollection
    {
        public MetaRule MetaRule { get; set; }
        public MetaAction MetaAction { get; set; }

        public RuleActionCollection(MetaRule metaRule, MetaAction metaAction)
        {
            this.MetaRule = metaRule;
            this.MetaAction = metaAction;
        }


    }
}
