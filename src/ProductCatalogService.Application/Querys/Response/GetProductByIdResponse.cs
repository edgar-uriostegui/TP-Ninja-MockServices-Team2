using ProductCatalogService.Application.Querys.Models;
using ProductCatalogService.Application.Utils;

namespace ProductCatalogService.Application.Querys.Response
{
    /// <summary>
    /// Response for GetProduct by Id
    /// </summary>
    public class GetProductByIdResponse : ResponseBase
    {
        /// <summary>
        /// Product
        /// </summary>
        public Product Product { get; set; }
    }
}
