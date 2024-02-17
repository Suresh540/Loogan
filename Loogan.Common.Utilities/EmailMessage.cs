using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Loogan.Common.Utilities
{
    public class EmailMessage : IEmailMessage
    {
        public bool SendEmail(SmtpDetails details)
        {
            bool isSendEmail = false;
            using (SmtpClient client = new SmtpClient(details.Host,details.Port))
            {
                client.Credentials = new NetworkCredential(details.UserName, details.Password);
                MailAddress from = new MailAddress(details.FromAddress, details.FromAddressDisplayName, Encoding.UTF8);
                MailAddress to = new MailAddress(details.ToAddress);

                MailMessage message = new MailMessage(from, to);
                message.Body = details.Body;
                message.IsBodyHtml = details.IsHtmlBody;
                message.BodyEncoding = Encoding.UTF8;
                message.Subject = details.Subject;
                message.SubjectEncoding = Encoding.UTF8;

                if(details.Attachements != null && details.Attachements.Count > 0)
                {
                    foreach(var attach in details.Attachements)
                    {
                        message.Attachments.Add(new Attachment(SerializeToStream(attach), nameof(attach)));
                    }
                }
                client.Send(message);
                isSendEmail = true;
            }
            return isSendEmail;
        }

        public MemoryStream SerializeToStream(object data)
        {
            MemoryStream stream = new MemoryStream();
            var resultBytes = JsonSerializer.SerializeToUtf8Bytes(data,
                    new JsonSerializerOptions { WriteIndented = false, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});
            stream.Read(resultBytes);
            return stream;
        }
    }

    public interface IEmailMessage
    {
        public bool SendEmail(SmtpDetails details);
    }

    public class SmtpDetails
    {
        public string? Host { get; set; } = "";
        public string? UserName { get; set; } = "";
        public string? Password { get; set; } = "";
        public int Port { get; set; } = 0;
        public string? Subject { get; set; } = "";
        public string? Body { get; set; } = "";
        public string? ToAddress { get; set; } = "";
        public string? FromAddress { get; set; } = "";
        public string? FromAddressDisplayName { get; set; } = "";
        public bool IsHtmlBody { get; set; } = false;
        public List<object>? Attachements { get; set; } = new List<object>();

    }
}
