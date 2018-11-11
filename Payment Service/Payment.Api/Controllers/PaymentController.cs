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
    public class PaymentController : ApiController
    {
        private readonly IPaymentBusiness paymentBusiness;
        private readonly IMapper mapper;
        private readonly IApiResponseWrapper apiResponseWrapper;

        public PaymentController(
            IPaymentBusiness paymentBusiness,
            IMapper mapper,
            IApiResponseWrapper apiResponseWrapper)
        {
            this.paymentBusiness = paymentBusiness;
            this.mapper = mapper;
            this.apiResponseWrapper = apiResponseWrapper;
        }

        [HttpPost]
        [Route("~/api/payment/pay")]
        public HttpResponseMessage Pay([FromBody]PurchaseModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var purchaseEntity = mapper.MapPurchaseFromModelToEntity(model);
                    var transaction = paymentBusiness.Pay(purchaseEntity);

                    return apiResponseWrapper.Response(HttpStatusCode.OK, transaction);
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