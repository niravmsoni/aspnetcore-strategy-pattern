using Strategy_Pattern_First_Look.Business.Models;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
    /// <summary>
    /// To be used to generate invoice using different variants
    /// </summary>
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}
