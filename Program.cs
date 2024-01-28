using Strategy_Pattern_First_Look.Business.Models;
using Strategy_Pattern_First_Look.Business.Strategies.Invoice;
using Strategy_Pattern_First_Look.Business.Strategies.SalesTax;
using System;

namespace Strategy_Pattern_First_Look
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();

            ////Set strategy at run-time based on whatever destination was selected by the user
            ///Approach#1
            //if (destination == "sweden")
            //{
            //    order.SalesTaxStrategy = new SwedenSalesTaxStrategy();
            //}
            //else if (destination == "us")
            //{
            //    order.SalesTaxStrategy = new USASalesTaxStrategy();
            //}
            
            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

            //Approach#1
            //Console.WriteLine(order.GetTax());

            //Approach#2 - Pass strategy directly to method that takes in ISalesTaxStrategy
            Console.WriteLine(order.GetTax(new SwedenSalesTaxStrategy()));

            order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });

            order.InvoiceStrategy = new FileInvoiceStrategy();
            order.FinalizeOrder();
        }
    }
}
