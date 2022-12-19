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
    /// <summary>
    /// Query to retrieve product by Id
    /// </summary>
    public class GetProductById
    {
        #region Query
        /// <summary>
        /// QueryRequest GetProductById
        /// </summary>
        public class Query : IRequest<Response<Result>>
        {
            /// <summary>
            /// Id parameter
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// Constructor Query
            /// </summary>
            /// <param name="id"></param>
            public Query(int id)
            {
                Id = id;
            }
        }
        #endregion
        
        #region Result
        /// <summary>
        /// Result GetProduct by Id
        /// </summary>
        public class Result
        {
            /// <summary>
            /// GetProductByIdResponse field
            /// </summary>
            public GetProductByIdResponse ProductResponse { get; set; }
            /// <summary>
            /// Constructor
            /// </summary>
            public Result()
            {
                ProductResponse = new GetProductByIdResponse();
            }
        }
        #endregion

        #region Handler
        /// <summary>
        /// Handler GetProduct by Id
        /// </summary>
        public class Handler : IRequestHandler<Query, Response<Result>>
        {
            private readonly IMapper _mapper;
            private readonly IProductRepository _repository;
            private readonly Response<Result> _response;
            /// <summary>
            /// Contructor Handler
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
            /// Handle method that executes the logic to retrieve product by Id
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<Response<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    _response.Payload.ProductResponse.Product = _mapper.Map<ProductEntity, Product>(_repository.GetProductById(request.Id));
                }
                catch (Exception ex)
                {
                    _response.SetFailureResponse(string.Empty, $"An error was throw trying to get product by id");
                    _response.Payload.ProductResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
                return _response;
            }
        }
        #endregion

        #region Mapper
        /// <summary>
        /// Mapping profile for for GetProductById
        /// </summary>
        public class Mapping : Profile
        {
            /// <summary>
            /// Constructor 
            /// </summary>
            public Mapping() => CreateMap<ProductEntity, Product>();
        }
        #endregion
    }
}
