
namespace ProductCatalogService.Application.Querys.Models
{
    /// <summary>
    /// Model for Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id product
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Stock Keeping Unit
        /// </summary>
        public string Sku { get; }
        /// <summary>
        /// Name product
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Derscription product
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Cost product
        /// </summary>
        public decimal Cost { get; }
        /// <summary>
        /// Category product
        /// </summary>
        public string Category { get; }
        /// <summary>
        /// Quantity in stock
        /// </summary>
        public int NumberInStock { get; }

        /// <summary>
        /// Ctor by product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sku"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        /// <param name="category"></param>
        /// <param name="categoryId"></param>
        /// <param name="numberInStock"></param>

        public Product(int id, string sku, string name, string description, decimal cost, string category, int numberInStock)
        {
            Id = id;
            Sku = sku;
            Name = name;
            Description = description;
            Cost = cost;
            Category = category;
            NumberInStock = numberInStock;
        }
    }
}
