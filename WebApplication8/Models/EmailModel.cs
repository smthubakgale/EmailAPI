using System; 
using System.Net.Mail;
using System.Net;
using Send_Email.Database;
using System.Web.Script.Serialization;

namespace Send_Email.Models
{
    public class EmailModel
    {
        // Variables
           SmtpClient MyServer;
           string myemail = "computer.system.4a@gmail.com";
           string mypass = "compsysy4A";
        // Constructor
           public EmailModel() 
           {
                MyServer = new SmtpClient()
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587 ,
                    Credentials = new NetworkCredential( myemail , mypass),
                    
           };
           }
        // Methods
           public string sendEmail(EmailTable em) 
           {
              var a = new JavaScriptSerializer().Serialize(em); 

              var body = em.body + " " + DateTime.UtcNow.ToString(); 
            
              try
              {
                  MyServer.Send(myemail, em.email, em.subject, body);
              }
              catch(Exception ex) 
              {
                a = ex.Message; 
              }

              return a;
           }
        //

        /*
         https://support.google.com/mail/thread/146949535/the-server-response-was-5-7-0-authentication-required?hl=en

         https://learningjquery.com/2017/09/3-jqueryjavascript-plugins-for-push-notifications-2
         */
    }
}
