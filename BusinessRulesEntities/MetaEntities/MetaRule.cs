using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace BusinessRulesEntities.MetaEntities
{
    public class MetaRule
    {
        public string Name { get; set; }
        public string Assembly { get; set ; }
        public string Class { get; set; }
        public List<string> Args { get; set; }


    }
}
