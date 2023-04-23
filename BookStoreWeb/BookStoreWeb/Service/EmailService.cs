using BookStoreWeb.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWeb.Service
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"EmailTemplates/{0}.html";

        private readonly SmtpConfigVM _optionSmtpConfig;

        public EmailService(IOptions<SmtpConfigVM> optionSmtpConfig)
        {
            _optionSmtpConfig = optionSmtpConfig.Value;
        }
        public async Task SendTestMail(TestMailOptionsVM testMailOptionsVM)
        {
            testMailOptionsVM.mailSubject = "Main Subject";
            testMailOptionsVM.mailObject = AddPlaceHoldrsToEmail(GetEmailBody("TestMail"), testMailOptionsVM.placeHolder);
            await SendEmail(testMailOptionsVM);
        }
        private async Task SendEmail(TestMailOptionsVM testMailOptionsVM)
        {
            MailMessage mail = new MailMessage
            {
                Subject = testMailOptionsVM.mailSubject,
                Body = testMailOptionsVM.mailObject,
                From = new MailAddress(_optionSmtpConfig.SenderMail, _optionSmtpConfig.SenderName),
                IsBodyHtml = _optionSmtpConfig.IsBodyHtml,
            };
            //....spesific to mails
            foreach (var toMail in testMailOptionsVM.mailToAddresses)
            {
                mail.To.Add(toMail);
            }
            //...to send username and password
            NetworkCredential networkCredential = new NetworkCredential(_optionSmtpConfig.UserName, _optionSmtpConfig.Password);

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _optionSmtpConfig.Host,
                Port = _optionSmtpConfig.Port,
                EnableSsl = _optionSmtpConfig.EnableSSl,
                UseDefaultCredentials = _optionSmtpConfig.UseDefaultCredentials,
                Credentials = networkCredential,
            };

            mail.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mail);
        }
        private string GetEmailBody(string templateName)
        {
            //....to ready the body of template
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }
        private string AddPlaceHoldrsToEmail(string text, List<KeyValuePair<string, string>> placeHolders)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text) && placeHolders != null)
            {
                foreach (var placeHolder in placeHolders)
                {
                    if (text.Contains(placeHolder.Key))
                    {
                        text = text.Replace(placeHolder.Key, placeHolder.Value);
                    }
                }
            }
            return text;
        }
    }
}
