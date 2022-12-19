using ProductCatalogService.Domain.Models;


namespace ProductCatalogService.Repository.Repository.Persistance
{
    /// <summary>
    /// Interface for ProductRepository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Method that retrieves all products by db
        /// </summary>
        /// <returns></returns>
        List<ProductEntity> GetAllProducts();
        /// <summary>
        /// Method that performs product search
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sku"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        List<ProductEntity> SearchProduct(int id, string sku, string name, string description, decimal cost, string category);
    }
}
