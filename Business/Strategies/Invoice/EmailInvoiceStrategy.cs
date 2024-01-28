using Strategy_Pattern_First_Look.Business.Models;
using System.Net.Mail;
using System.Net;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
    /// <summary>
    /// Inherit from InvoiceStrategy and override generate method. 
    /// Execute the GenerateTextInvoice from InvoiceStrategy abstract class
    /// </summary>
    public class EmailInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using (SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587))
            {
                NetworkCredential credentials = new NetworkCredential("USERNAME", "PASSWORD");
                client.Credentials = credentials;

                MailMessage mail = new MailMessage("YOUR EMAIL", "YOUR EMAIL")
                {
                    Subject = "We've created an invoice for your order",
                    Body = GenerateTextInvoice(order)
                };

                client.Send(mail);
            }
        }
    }
}
