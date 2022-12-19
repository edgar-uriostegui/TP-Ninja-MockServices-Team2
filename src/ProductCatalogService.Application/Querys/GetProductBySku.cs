using AutoMapper;
using MediatR;
using ProductCatalogService.Application.Querys.Models;
using ProductCatalogService.Application.Querys.Response;
using ProductCatalogService.Application.Utils;
using ProductCatalogService.Domain.Models;
using ProductCatalogService.Repository.Repository.Persistance;
using System.Net;

namespace ProductCatalogService.Application.Querys
{
    public class GetProductBySku
    {
        #region Query
        /// <summary>
        /// QueryRequest GetProductBySku
        /// </summary>
        public class Query : IRequest<Response<Result>>
        {
            /// <summary>
            /// Id parameter
            /// </summary>
            public string Sku { get; set; }
            /// <summary>
            /// Constructor Query
            /// </summary>
            /// <param name="id"></param>
            public Query(string sku)
            {
                Sku = sku;
            }
        }
        #endregion

        #region Result
        /// <summary>
        /// Result GetProductBySku
        /// </summary>
        public class Result
        {
            /// <summary>
            /// GetProductBySkuResponse field
            /// </summary>
            public GetProductBySkuResponse ProductSkuResponse { get; set; }
            /// <summary>
            /// Constructor Result
            /// </summary>
            public Result()
            {
                ProductSkuResponse = new GetProductBySkuResponse();
            }
        }
        #endregion

        #region Handler
        /// <summary>
        /// Handler GetProduct by Sku
        /// </summary>
        public class Handler : IRequestHandler<Query, Response<Result>>
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
                _response = new Response<Result>()
                {
                    Payload = new Result()
                };
            }
            /// <summary>
            /// Handle method that executes the logic to retrieve product by sku
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<Response<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    _response.Payload.ProductSkuResponse.Product = _mapper.Map<ProductEntity,Product>(_repository.GetProductBySku(request.Sku));
                }
                catch (Exception ex)
                {
                    _response.SetFailureResponse(string.Empty, $"An error was throw trying to get product by sku");
                    _response.Payload.ProductSkuResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
                return _response;
            }
        }
        #endregion

        #region Mapper
        public class Mapping : Profile 
        {
            public Mapping() => CreateMap<ProductEntity, Product>();
        }
        #endregion
    }
}
