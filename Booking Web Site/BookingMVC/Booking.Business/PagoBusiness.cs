using Booking.DataAccess;
using BookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Business
{
    public class PagoBusiness
    {
        public bool Pagar(Pago pago)
        {
            var mes = pago.FechaExpiracion.Substring(0, 2);
            var anio = pago.FechaExpiracion.Substring(5, 2);

            var purchase = new Purchase()
            {
                CardNumber = pago.NumeroTarjeta,
                CardType = "CREDIT",
                CardCvv = pago.CardCvv,
                CardExpireDate = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), 1),
                Cost = pago.Costo,
                Description = pago.Descripcion
            };

            var paymentApi = new PaymentApi();

            try
            {
                paymentApi.Pagar(purchase);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}