
namespace FoodApp.Framework
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    ///     The mailer.
    /// </summary>
    public class Mailer
    {
        /// <summary>
        ///     The base path.
        /// </summary>
        private readonly string basePath = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data/MailTemplates/");

        /// <summary>
        /// The smtp Host
        /// </summary>
        private string SMTP_HOST = ConfigurationManager.AppSettings["SMTP_HOST"];

        /// <summary>
        /// The User Name
        /// </summary>
        private string SMTP_USERNAME = ConfigurationManager.AppSettings["SMTP_USERNAME"];

        /// <summary>
        /// The User Name
        /// </summary>
        private string SMTP_DOMAIN = ConfigurationManager.AppSettings["SMTP_DOMAIN"];

        /// <summary>
        /// The Passwor
        /// </summary>
        private string SMTP_PASSWORD = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

        /// <summary>
        /// The User Name
        /// </summary>
        private int SMTP_PORT = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);

        private SmtpClient smtpClient;
        /// <summary>
        ///     Initializes a new instance of the <see cref="Mailer" /> class.
        /// </summary>
        public Mailer()
        {
            smtpClient = new SmtpClient
            {
                Host = SMTP_HOST,
                EnableSsl = false,
                DeliveryMethod =
                    SmtpDeliveryMethod.Network,
                Credentials =
                    new NetworkCredential(
                    SMTP_USERNAME,
                    SMTP_PASSWORD),
                Port = SMTP_PORT
            };

        }


        public void SendMail(
            ListDictionary replacements,
            string templateName,
            string email,
            string subject,
            string savedFileName = null)
        {
            using (this.smtpClient)
            {
                var mailDefinition = new MailDefinition
                {
                    Priority = MailPriority.Normal,
                    BodyFileName = this.basePath+templateName,
                    Subject = subject,
                    IsBodyHtml = true,
                    From=SMTP_USERNAME
                };
                MailMessage mailMessage = mailDefinition.CreateMailMessage(email, replacements, new Control());

                smtpClient.Send(mailMessage);
            }
        }
    }

}