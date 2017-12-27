using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("gupta.nash@gmail.com", "Avinash Gupta"));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress("avinashguptajavvaji@gmail.com", "Avinash Gupta Javvaji")
            };
            msg.AddTos(recipients);

            msg.SetSubject("Testing the SendGrid C# Library");

            msg.AddContent(MimeType.Text, "Hello World plain text!");
            var response = await client.SendEmailAsync(msg);
            //msg.AddContent(MimeType.Html, "<p>Hello World!</p>");
        }
    }
}
