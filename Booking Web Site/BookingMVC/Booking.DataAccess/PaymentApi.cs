using BookingModels;
using RestSharp;

namespace Booking.DataAccess
{
    public class PaymentApi
    {
        public Transaccion Pagar(Purchase purchase)
        {
            //var client = new RestClient("http://localhost:9609/");
            var client = new RestClient("http://localhost:91/");
            var request = new RestRequest("api/payment/pay", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Purchase
            {
                CardNumber = purchase.CardNumber,
                CardType = purchase.CardType,
                CardCvv = purchase.CardCvv,
                CardExpireDate = purchase.CardExpireDate,
                Cost = purchase.Cost,
                Description = purchase.Description
            });
            var queryResult = client.Execute<Transaccion>(request).Data;

            return queryResult;
        }
    }
}