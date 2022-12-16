using AutoMapper;
using MediatR;
using ProductCatalogService.Application.Querys.Models;
using ProductCatalogService.Application.Querys.Request;
using ProductCatalogService.Application.Querys.Response;
using ProductCatalogService.Application.Utils;
using ProductCatalogService.Domain.Models;
using ProductCatalogService.Repository.Repository.Persistance;
using System.Net;

namespace ProductCatalogService.Application.Querys
{
    /// <summary>
    /// Query to retieve all Products
    /// </summary>
    public class GetProduct
    {
        #region Query
        /// <summary>
        /// QueryRequest GetProduct
        /// </summary>
        public class Query : IRequest<Response<Result>>
        {
            /// <summary>
            /// GetProductRequest field
            /// </summary>
            public GetProductRequest? Request { get; set; }
        }
        #endregion 

        #region Result
        /// <summary>
        /// Result GetProduct
        /// </summary>
        public class Result
        {
            /// <summary>
            /// GetProductResponse field
            /// </summary>
            public GetProductResponse GetProductResponse { get; set; }
            /// <summary>
            /// Ctor Result
            /// </summary>
            public Result(){
                GetProductResponse = new GetProductResponse();
            }
        }
        #endregion 

        #region Handler
        /// <summary>
        /// Handler GetProduct
        /// </summary>
        public class Handler : IRequestHandler<Query, Response<Result>>
        {
            private readonly IMapper _mapper;
            private readonly IProductRepository _repository;
            private readonly Response<Result> _response;
            /// <summary>
            /// Ctor Handler
            /// </summary>
            /// <param name="mapper"></param>
            /// <param name="repository"></param>
            public Handler(IMapper mapper, IProductRepository repository)
            {
                _mapper= mapper;
                _repository= repository;
                _response= new Response<Result>
                {
                    Payload= new Result()
                };
            }
            /// <summary>
            /// Handle method that executes the logic to retrieve all products
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<Response<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    _response.Payload.GetProductResponse.Products = _mapper.Map<List<ProductEntity>, List<Product>>(_repository.GetAllProducts());
                }
                catch (Exception ex)
                {
                    _response.SetFailureResponse(string.Empty, $"An error was throw trying to get all the products");
                    _response.Payload.GetProductResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    throw;
                }

                return _response;
            }
        }
        #endregion

        #region Mapper
        /// <summary>
        /// Mapping profile for GetProduct
        /// </summary>
        public class Mapping : Profile
        {
            /// <summary>
            /// Ctor that initialize all mappings for GetProduct
            /// </summary>
            public Mapping() => CreateMap<ProductEntity, Product>();
        }
        #endregion

    }
}
