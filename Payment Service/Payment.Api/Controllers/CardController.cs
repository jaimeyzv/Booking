using Payment.Business.Interfaces;
using Payment.Infrastructure.Interfaces.Mappers;
using Payment.Infrastructure.Interfaces.Wrappers;
using System.Web.Http;

namespace Payment.Api.Controllers
{
    public class CardController : ApiController
    {
        private readonly ICardBusiness cardBusiness;
        private readonly IMapper mapper;
        private readonly IApiResponseWrapper apiResponseWrapper;

        public CardController(
            ICardBusiness cardBusiness,
            IMapper mapper,
            IApiResponseWrapper apiResponseWrapper)
        {
            this.cardBusiness = cardBusiness;
            this.mapper = mapper;
            this.apiResponseWrapper = apiResponseWrapper;
        }
    }
}