using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


	

namespace LoggingWebFrontEndApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            LogServiceReference.Log log = new LogServiceReference.Log();
            log.Title = TextBoxTitle.Text;
            log.Message = TextBoxMessage.Text;
            log.Priority = DropDownListPriority.SelectedValue;
            log.Category = TextBoxCategory.Text;
            log.Severity = null;


            LogServiceReference.LoggingServiceClient ServiceReference = new LogServiceReference.LoggingServiceClient("basic");
            
           
            ServiceReference.SubmitLog(log);
            

            ClearContent();

            NotifyLabel.Text = "Your data has been submitted. Thank you!";
        }

        protected void TextBoxMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearContent() 
        {
            TextBoxTitle.Text = "";
            TextBoxMessage.Text = "";
            TextBoxCategory.Text = "";
  
        
        }

    }
}
