using Strategy_Pattern_First_Look.Business.Models;

namespace Strategy_Pattern_First_Look.Business.Strategies.Shipping
{
    /// <summary>
    /// Controls shipping strategy
    /// </summary>
    public interface IShippingStrategy
    {
        void Ship(Order order);
    }
}
