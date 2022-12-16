using ProductCatalogService.Application.Querys.Models;
using ProductCatalogService.Application.Utils;

namespace ProductCatalogService.Application.Querys.Response
{
    /// <summary>
    /// Response for GetProduct
    /// </summary>
    public  class GetProductResponse : ResponseBase
    {
        /// <summary>
        /// List of products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }
    }

}
