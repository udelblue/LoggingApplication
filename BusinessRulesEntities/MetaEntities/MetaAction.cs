using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRulesEntities.MetaEntities
{
    public class MetaAction
    {
        public string Name { get; set; }
        public string Assembly { get; set; }
        public string Class { get; set; }
        public List<string> Args { get; set; }

    }
}
