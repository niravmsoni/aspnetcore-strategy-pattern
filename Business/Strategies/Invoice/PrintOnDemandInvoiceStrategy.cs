using Newtonsoft.Json;
using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Net.Http;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
    /// <summary>
    /// Within this class, we are implementing IInvoiceStrategy directly since the text we are going to generate is going to be Json
    /// We are going to serialize object and print it
    /// </summary>
    public class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(order);

                client.BaseAddress = new Uri("https://pluralsight.com");

                client.PostAsync("/print-on-demand", new StringContent(content));
            }
        }
    }
}
