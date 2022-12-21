using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ProductCatalogService.Application.Querys;
using ProductCatalogService.Application.Querys.Models;

namespace ProductCatalogService.Application.Endpoints
{
    /// <summary>
    /// Class to represents the GetProductBySku Endpoint
    /// </summary>
    public class GetProductBySkuEndpoint : ICarterModule
    {
        /// <summary>
        /// Add route for "productCatalog/BySku/{sku}
        /// </summary>
        /// <param name="app"></param>
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/v1/productCatalog/BySku/{sku}", (string sku, IMediator mediator) => {
                return mediator.Send(new GetProductBySku.Query(sku));
            })
                .WithName(nameof(GetProductBySkuEndpoint))
                .Produces<Product>(200);
        }
    }
}
