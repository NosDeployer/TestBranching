using System;
using System.Net.Mail;


namespace LiquiForce.LFSLive.WebUI.Common.Tools
{
    /// <summary>
    /// Mail
    /// </summary>
    public class Mail : System.Web.UI.Page
    {
        // ///////////////////////////////////////////////////////////
        // PRIVATE FIELDS
        //

        private static MailAddress _mailFrom = null;
        private static SmtpClient _smtpClient = null;






        // ///////////////////////////////////////////////////////////
        // PRIVATE FIELDS
        //

        public static MailAddress MailFrom
        {
            get
            {
                if (_mailFrom == null)
                {
                    throw new Exception("You have to call Mail.Instantiate() before accessing the Mail.MailFrom property");
                }
                return _mailFrom;
            }
        }


        
        public static SmtpClient SmtpClient
        {
            get
            {
                if (_smtpClient == null)
                {
                    throw new Exception("You have to call Mail.Instantiate() before accessing the Mail.SmtpClient property");
                }
                return _smtpClient;
            }
        }





        
        // ///////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        public static bool SendMail(string to, string subject, string body, bool IsBodyHtml, out string error)
        {
            // initialize SmtpClient & MailMessage
            error = "";
            Instantiate();
            MailMessage mailMessage = SetParameters(to, subject, body, out error);
            mailMessage.IsBodyHtml = IsBodyHtml;
        
            // send message
            if (error == "")
            {
                try
                {
                    SmtpClient.Send(mailMessage);
                }
                catch
                {
                    error = "The Mail Server generate a error, the mail was not sended.";
                }
            }

            // check error
            if (error == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static bool SendMail(string to, string cc, string subject, string body, bool IsBodyHtml, out string error)
        {
            // initialize SmtpClient & MailMessage
            error = "";
            Instantiate();
            MailMessage mailMessage = SetParameters(to, cc, subject, body, out error);
            mailMessage.IsBodyHtml = IsBodyHtml;
            
            // send message
            if (error == "")
            {
                try
                {
                    SmtpClient.Send(mailMessage);
                }
                catch
                {
                    error = "The Mail Server generate a error, the mail was not sended.";
                }
            }

            // check error
            if (error == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static bool SendMailLabourHours(string to, string cc, string subject, string body, bool IsBodyHtml, out string error)
        {
            // initialize SmtpClient & MailMessage
            error = "";
            InstantiateLabourHours();
            System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
            _mailFrom = new MailAddress(appSettingReader.GetValue("MailFromAddress", typeof(System.String)).ToString(), appSettingReader.GetValue("MailFromNameLabourHours", typeof(System.String)).ToString());
            MailMessage mailMessage = SetParameters(to, cc, subject, body, out error);
            mailMessage.IsBodyHtml = IsBodyHtml;

            // send message
            if (error == "")
            {
                try
                {
                    SmtpClient.Send(mailMessage);
                }
                catch
                {
                    error = "The Mail Server generate a error, the mail was not sended.";
                }
            }

            // check error
            if (error == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static bool SendMailVacations(string to, string cc, string subject, string body, bool IsBodyHtml, out string error)
        {
            // initialize SmtpClient & MailMessage
            error = "";
            InstantiateVacations();
            System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
            _mailFrom = new MailAddress(appSettingReader.GetValue("MailFromAddress", typeof(System.String)).ToString(), appSettingReader.GetValue("MailFromNameVacations", typeof(System.String)).ToString());
            MailMessage mailMessage = SetParameters(to, cc, subject, body, out error);
            mailMessage.IsBodyHtml = IsBodyHtml;

            // send message
            if (error == "")
            {
                try
                {
                    SmtpClient.Send(mailMessage);
                }
                catch
                {
                    error = "The Mail Server generate a error, the mail was not sended.";
                }
            }

            // check error
            if (error == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static bool SendMailSupportTicketSystem(string to, string cc, string subject, string body, bool IsBodyHtml, out string error)
        {
            // initialize SmtpClient & MailMessage
            error = "";
            InstantiateSupportTicketSystem();
            System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
            _mailFrom = new MailAddress(appSettingReader.GetValue("MailFromAddress", typeof(System.String)).ToString(), "Support Ticket System");
            MailMessage mailMessage = SetParameters(to, cc, subject, body, out error);
            mailMessage.IsBodyHtml = IsBodyHtml;

            // send message
            if (error == "")
            {
                try
                {
                    SmtpClient.Send(mailMessage);
                }
                catch
                {
                    error = "The Mail Server generate a error, the mail was not sended.";
                }
            }

            // check error
            if (error == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }






        // ///////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private static void Instantiate()
        {
            if (_mailFrom == null)
            {
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();

                try
                {
                    _mailFrom = new MailAddress(appSettingReader.GetValue("MailFromAddress", typeof(System.String)).ToString(), appSettingReader.GetValue("MailFromName", typeof(System.String)).ToString());
                }
                catch
                {
                    throw new Exception("Error in MailFrom instantiation process");
                }
            }

            if (_smtpClient == null)
            {
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                _smtpClient = new SmtpClient();

                if (appSettingReader.GetValue("MailHost", typeof(System.String)).ToString() == "")
                {
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                }
                else
                {
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    _smtpClient.Host = appSettingReader.GetValue("MailHost", typeof(System.String)).ToString();
                    _smtpClient.Credentials = new System.Net.NetworkCredential(appSettingReader.GetValue("MailUsername", typeof(System.String)).ToString(), appSettingReader.GetValue("MailPassword", typeof(System.String)).ToString());
                }
            }
        }



        private static void InstantiateLabourHours()
        {
            if (_mailFrom == null)
            {
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();

                try
                {
                    _mailFrom = new MailAddress(appSettingReader.GetValue("MailFromAddress", typeof(System.String)).ToString(), appSettingReader.GetValue("MailFromNameLabourHours", typeof(System.String)).ToString());
                }
                catch
                {
                    throw new Exception("Error in MailFrom instantiation process");
                }
            }

            if (_smtpClient == null)
            {
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                _smtpClient = new SmtpClient();

                if (appSettingReader.GetValue("MailHost", typeof(System.String)).ToString() == "")
                {
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                }
                else
                {
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    _smtpClient.Host = appSettingReader.GetValue("MailHost", typeof(System.String)).ToString();
                    _smtpClient.Credentials = new System.Net.NetworkCredential(appSettingReader.GetValue("MailUsername", typeof(System.String)).ToString(), appSettingReader.GetValue("MailPassword", typeof(System.String)).ToString());
                }
            }
        }



        private static void InstantiateVacations()
        {
            if (_mailFrom == null)
            {
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();

                try
                {
                    _mailFrom = new MailAddress(appSettingReader.GetValue("MailFromAddress", typeof(System.String)).ToString(), appSettingReader.GetValue("MailFromNameVacations", typeof(System.String)).ToString());
                }
                catch
                {
                    throw new Exception("Error in MailFrom instantiation process");
                }
            }

            if (_smtpClient == null)
            {
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                _smtpClient = new SmtpClient();

                if (appSettingReader.GetValue("MailHost", typeof(System.String)).ToString() == "")
                {
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                }
                else
                {
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    _smtpClient.Host = appSettingReader.GetValue("MailHost", typeof(System.String)).ToString();
                    _smtpClient.Credentials = new System.Net.NetworkCredential(appSettingReader.GetValue("MailUsername", typeof(System.String)).ToString(), appSettingReader.GetValue("MailPassword", typeof(System.String)).ToString());
                }
            }
        }



        private static void InstantiateSupportTicketSystem()
        {
            if (_mailFrom == null)
            {
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();

                try
                {
                    _mailFrom = new MailAddress(appSettingReader.GetValue("MailFromAddress", typeof(System.String)).ToString(), "Support Ticket System");
                }
                catch
                {
                    throw new Exception("Error in MailFrom instantiation process");
                }
            }

            if (_smtpClient == null)
            {
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                _smtpClient = new SmtpClient();

                if (appSettingReader.GetValue("MailHost", typeof(System.String)).ToString() == "")
                {
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                }
                else
                {
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    _smtpClient.Host = appSettingReader.GetValue("MailHost", typeof(System.String)).ToString();
                    _smtpClient.Credentials = new System.Net.NetworkCredential(appSettingReader.GetValue("MailUsername", typeof(System.String)).ToString(), appSettingReader.GetValue("MailPassword", typeof(System.String)).ToString());
                }
            }
        }



        private static MailMessage SetParameters(string to, string subject, string body, out string error)
        {
            MailMessage mailMessage = new MailMessage();
            error = "";
            
            // set parameters
            mailMessage.From = Tools.Mail.MailFrom;
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            try
            {
                mailMessage.To.Add(to);
            }
            catch
            {
                error = "The TO address has an error, the mail was not sended.";
            }

            // return
            return mailMessage;
        }



        private static MailMessage SetParameters(string to, string cc, string subject, string body, out string error)
        {
            MailMessage mailMessage = new MailMessage();
            error = "";
            
            // set parameters
            mailMessage.From = Tools.Mail.MailFrom;
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            try
            {
                mailMessage.To.Add(to);
            }
            catch
            {
                error = "The TO address has an error, the mail was not sended.";
            }

            try
            {
                mailMessage.Bcc.Add(cc);
            }
            catch
            {
                if (error != "")
                {
                    error = "The TO addres and CC address has an error, the mail was not sended.";
                }
                else
                {
                    error = "The BCC address has an error, the mail was not sended.";
                }
            }

            // return
            return mailMessage;
        }



    }
}