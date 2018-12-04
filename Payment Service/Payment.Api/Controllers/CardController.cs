using Payment.Api.Models;
using Payment.Business.Interfaces;
using Payment.Infrastructure.Interfaces.Mappers;
using Payment.Infrastructure.Interfaces.Wrappers;
using System;
using System.Net;
using System.Net.Http;
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

        [HttpGet]
        [Route("~/api/card/{cardNumber}")]
        public HttpResponseMessage Get(string cardNumber)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = cardBusiness.GetByCardNumber(cardNumber);
                    var model = mapper.MapFromCardEntityToCardModel(entity);

                    //return apiResponseWrapper.Response(HttpStatusCode.OK, model);

                    return Request.CreateResponse<CardModel>(HttpStatusCode.OK, model);
                }

                return apiResponseWrapper.Response(HttpStatusCode.InternalServerError, null);
            }
            catch (Exception ex)
            {
                return apiResponseWrapper.Response(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}