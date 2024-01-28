using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.IO;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
    /// <summary>
    /// Inherit from InvoiceStrategy and override generate method. 
    /// Execute the GenerateTextInvoice from InvoiceStrategy abstract class
    /// </summary>
    public class FileInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using (var stream = new StreamWriter($"invoice_{Guid.NewGuid()}.txt"))
            {
                stream.Write(GenerateTextInvoice(order));

                stream.Flush();
            }
        }
    }
}
