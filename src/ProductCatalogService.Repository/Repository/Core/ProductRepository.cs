using ProductCatalogService.Domain.Models;
using ProductCatalogService.Repository.Repository.Persistance;

namespace ProductCatalogService.Repository.Repository.Core
{
    /// <summary>
    /// Repository for Products
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Method that retrieves all products by db
        /// </summary>
        /// <returns></returns>
        public List<ProductEntity> GetAllProducts()
        {
            return products;
        }

        public ProductEntity GetProductBySku(string sku)
        {
            return products.FirstOrDefault(s => s.Sku.ToUpper() == sku.ToUpper());
        }

        public static List<ProductEntity> products = new()
        {
            new ProductEntity(1, "Sku1", "Product 1", "Product 1", 10, "Category 1", 100),
            new ProductEntity(2, "Sku2", "Product 2", "Product 2", 20, "Category 1", 200),
            new ProductEntity(3, "Sku3", "Product 3", "Product 3", 30, "Category 2", 300),
            new ProductEntity(4, "Sku4", "Product 4", "Product 4", 40, "Category 3", 400),
            new ProductEntity(5, "Sku5", "Product 5", "Product 5", 50, "Category 4", 500),
            new ProductEntity(6, "Sku6", "Product 6", "Product 6", 60, "Category 4", 600)
        };
    }
}
