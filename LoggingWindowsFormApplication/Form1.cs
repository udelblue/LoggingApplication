using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LoggingEntities;
using LoggingRepository;
using System.Data.Entity;
using BusinessRulesEntities.MetaEntities;
using System.Configuration;

namespace LoggingWindowsFormApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MetaRepository repository = new MetaRepository();
            List<RuleActionCollection> collection = repository.RuleActionCollection("test");

             var list =  repository.RuleActionCollectionAll();

             foreach (MetaRuleAction item in list)
             {
                 listBox1.Items.Add(item.RuleName);
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           listBox1.Items.Add(ConfigurationManager.AppSettings["RulePath"]);
        }
    }
}
