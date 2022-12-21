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
    /// Class to represents the GetProductById Endpoint
    /// </summary>
    public class GetProductByIdEndpoint : ICarterModule
    {
        /// <summary>
        /// Add route for "productCatalog/ById/{id:int}
        /// </summary>
        /// <param name="app"></param>
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/v1/productCatalog/ById/{id:int}", (int id, IMediator mediator) => {
                return mediator.Send(new GetProductById.Query(id));
            })
                .WithName(nameof(GetProductByIdEndpoint))
                .Produces<Product>(200);
        }
    }
}
