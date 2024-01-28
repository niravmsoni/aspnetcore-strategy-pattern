using Strategy_Pattern_First_Look.Business.Models;
using System;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
    /// <summary>
    /// Base class that is going to be shared by the child classes
    /// </summary>
    public abstract class InvoiceStrategy : IInvoiceStrategy
    {
        /// <summary>
        /// Code to actually generate invoice would sit in child classes
        /// </summary>
        /// <param name="order"></param>
        public abstract void Generate(Order order);

        /// <summary>
        /// Common methods used by Email and FileInvoice strategies
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public string GenerateTextInvoice(Order order)
        {
            var invoice = $"INVOICE DATE: {DateTimeOffset.Now}{Environment.NewLine}";

            invoice += $"ID|NAME|PRICE|QUANTITY{Environment.NewLine}";

            foreach (var item in order.LineItems)
            {
                invoice += $"{item.Key.Id}|{item.Key.Name}|{item.Key.Price}|{item.Value}{Environment.NewLine}";
            }

            invoice += Environment.NewLine + Environment.NewLine;

            var tax = order.GetTax();
            var total = order.TotalPrice + tax;

            invoice += $"TAX TOTAL: {tax}{Environment.NewLine}";
            invoice += $"TOTAL: {total}{Environment.NewLine}";

            return invoice;
        }
    }
}
