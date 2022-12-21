using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ProductCatalogService.Application.Commands;
using ProductCatalogService.Application.Commands.Request;
using ProductCatalogService.Application.Models.Common;

namespace ProductCatalogService.Application.Endpoints
{
    /// <summary>
    /// Class to represents the PostSearch Endpoint
    /// </summary>
    public class SearchEndpoint : ICarterModule
    {
        /// <summary>
        /// Add route for "productCatalog/search"
        /// </summary>
        /// <param name="app"></param>
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/v1/productCatalog/search", ([FromBody] PostSearchProductRequest product, IMediator mediator) =>
            {
                return mediator.Send(new PostSearchProduct.Command(product));
            })
                .WithName(nameof(SearchEndpoint))
                .Accepts<PostSearchProductRequest>("application/json")
                .Produces<IEnumerable<Product>>(200);
        }
    }
}
