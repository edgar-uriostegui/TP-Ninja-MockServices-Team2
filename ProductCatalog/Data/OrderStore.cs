using ProductCatalog.Models;

namespace ProductCatalog.Data
{
    public class OrderStore
    {
        public static List<Order> orders = new()
        {
            new Order(1, 1, "Order 1", DateTime.Now),
            new Order(2, 2, "Order 2", DateTime.Now),
            new Order(3, 3, "Order 3", DateTime.Now)
        };
    }
}
