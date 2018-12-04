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
    public class BalanceController : ApiController
    {
        private readonly IBalanceBusiness balanceBusiness;
        private readonly IMapper mapper;
        private readonly IApiResponseWrapper apiResponseWrapper;

        public BalanceController(
            IBalanceBusiness balanceBusiness,
            IMapper mapper,
            IApiResponseWrapper apiResponseWrapper)
        {
            this.balanceBusiness = balanceBusiness;
            this.mapper = mapper;
            this.apiResponseWrapper = apiResponseWrapper;
        }

        [HttpGet]
        [Route("~/api/balance/{cardId}")]
        public HttpResponseMessage Get(int cardId)
        {
            try
            {
                var entity = balanceBusiness.GetBalanceByCardId(cardId);
                var model = mapper.MapFromBalanceEntityToBalanceModel(entity);
                
                return Request.CreateResponse<BalanceModel>(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return apiResponseWrapper.Response(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        [Route("~/api/balance/")]
        public HttpResponseMessage Update([FromBody]BalanceModel model)
        {
            try
            {
                var entity = mapper.MapFromBalanceModelToBalanceEntity(model);
                balanceBusiness.UpdateBalance(entity);

                return Request.CreateResponse<BalanceModel>(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return apiResponseWrapper.Response(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}