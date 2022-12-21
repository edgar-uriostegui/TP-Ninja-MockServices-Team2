using ProductCatalogService.Application.Querys.Models;
using ProductCatalogService.Application.Utils;

namespace ProductCatalogService.Application.Querys.Response
{
    /// <summary>
    /// Response for GetProduct by Sku
    /// </summary>
    public class GetProductBySkuResponse : ResponseBase
    {
        /// <summary>
        /// Product
        /// </summary>
        public Product Product { get; set; }
    }
}
