using Strategy_Pattern_First_Look.Business.Models;

namespace Strategy_Pattern_First_Look.Business.Strategies.SalesTax
{
    /// <summary>
    /// Interface that is going to act as a strategy contract
    /// </summary>
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}
