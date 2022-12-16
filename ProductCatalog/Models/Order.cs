namespace ProductCatalog.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public DateTime? OrderDate { get; set; }

        public Order() { }

        public Order(int id, int productId, string description, DateTime? orderDate)
        {
            Id = id;
            ProductId = productId;
            Description = description;
            OrderDate = orderDate;
        }
    }
}
