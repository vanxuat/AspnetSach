using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace websach.App_Start
{
    public class SMTPMail
    {
        public bool sendmail(string to, string title, string message, Attachment file)
        {

            SmtpClient client = new SmtpClient();
            string mgs = string.Empty;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("mayt3156@gmail.com", "canhavuive");

                client.Host = "smtp.gmail.com";
                client.Port = 587;
           
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mayt3156@gmail.com");
                mail.To.Add(to);
                if (file != null)
                {
                    mail.Attachments.Add(file);
                }

                mail.Body = message;
                mail.Subject = title;
            try
            {
                client.Send(mail);
            }
            catch(Exception e)
            {
                mgs = e.Message;
            }
         
            return true;
        }
    }
}