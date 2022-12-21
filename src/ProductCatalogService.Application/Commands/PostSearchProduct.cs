using AutoMapper;
using MediatR;
using ProductCatalogService.Application.Commands.Request;
using ProductCatalogService.Application.Commands.Response;
using ProductCatalogService.Application.Models.Common;
using ProductCatalogService.Application.Utils;
using ProductCatalogService.Domain.Models;
using ProductCatalogService.Repository.Repository.Persistance;
using System.Net;

namespace ProductCatalogService.Application.Commands
{
    /// <summary>
    /// Search command
    /// </summary>
    public class PostSearchProduct
    {
        #region Command
        /// <summary>
        /// CommandRequest
        /// </summary>
        public class Command : IRequest<Response<Result>>
        {
            /// <summary>
            /// Product field
            /// </summary>
            public PostSearchProductRequest Product { get; }
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="product"></param>
            public Command(PostSearchProductRequest product)
            {
                Product = product;
            }
        }
        #endregion

        #region Result
        /// <summary>
        ///  Result PostSearchProduct
        /// </summary>
        public class Result
        {
            /// <summary>
            /// PostProductResponse field
            /// </summary>
            public PostProductResponse PostProductResponse { get; set; }
            /// <summary>
            /// Constructor
            /// </summary>
            public Result()
            {
                PostProductResponse = new PostProductResponse();
            }
        }
        #endregion

        #region Handler
        /// <summary>
        /// Handler PostSearchProduct
        /// </summary>
        public class Handler : IRequestHandler<Command, Response<Result>>
        {
            private readonly IMapper _mapper;
            private readonly IProductRepository _repository;
            private readonly Response<Result> _response;
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="mapper"></param>
            /// <param name="repository"></param>
            public Handler(IMapper mapper, IProductRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
                _response = new Response<Result>
                {
                    Payload = new Result()
                };
            }
            /// <summary>
            /// Handle method that executes the logic for searches
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<Response<Result>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    _response.Payload.PostProductResponse.Products = _mapper.Map<List<ProductEntity>, List<Product>>(
                        _repository.SearchProduct(
                            request.Product.Id, request.Product.Sku, request.Product.Name,
                            request.Product.Description, request.Product.Cost, request.Product.Category)
                        );
                }
                catch (Exception ex)
                {
                    _response.SetFailureResponse(string.Empty, $"An error was throw trying to search products");
                    _response.Payload.PostProductResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    throw;
                }
                return _response;
            }
        }

        #endregion

        #region Mapper
        /// <summary>
        /// Mapping profile for SearchProduct
        /// </summary>
        public class Mapping : Profile
        {
            /// <summary>
            /// Ctor that initialize all mappings for PostSearch
            /// </summary>
            public Mapping() => CreateMap<ProductEntity, Product>();
        }
        #endregion
    }
}
