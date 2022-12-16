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
    /// Class to represents the GetProduct Endpoint
    /// </summary>
    public class GetProductEndpoint : ICarterModule
    {
        /// <summary>
        /// Add route for "productCatalog/AllProducts"
        /// </summary>
        /// <param name="app"></param>
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/v1/productCatalog/AllProducts", (IMediator mediator) =>
            {
                return mediator.Send(new GetProduct.Query());
            })
                .WithName(nameof(GetProductEndpoint))
                .Produces<List<Product>>();
        }
    }
}
