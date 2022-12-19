using ProductCatalogService.Application.Commands.Models;
using ProductCatalogService.Application.Utils;

namespace ProductCatalogService.Application.Commands.Response
{
    /// <summary>
    /// Response for PostProducts
    /// </summary>
    public class PostProductResponse : ResponseBase
    {
        /// <summary>
        /// List of products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }
    }
}
