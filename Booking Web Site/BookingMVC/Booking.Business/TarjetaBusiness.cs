using Booking.DataAccess;
using BookingModels;
using System;

namespace Booking.Business
{
    public class TarjetaBusiness
    {
        CardApi cardApi = new CardApi();
        BalanceApi balanceApi = new BalanceApi();

        public bool SonDatosValidos(Pago pago)
        {
            var tarjeta = cardApi.ObtenerPorNumerTarjeta(pago.NumeroTarjeta);
            if (tarjeta.CardId == 0)
                return false;

            return tarjeta.Number == pago.NumeroTarjeta &&
                    String.Equals(tarjeta.Name, pago.NombreTarjeta, StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(tarjeta.ExpireDate.ToString("MM/yyyy"), pago.FechaExpiracion, StringComparison.OrdinalIgnoreCase) &&
                    tarjeta.Cvv == pago.CardCvv;
        }

        public int ObtenerTarjetaIdPorNumero(string numero)
        {
            var tarjeta = cardApi.ObtenerPorNumerTarjeta(numero);
            return tarjeta.CardId;
        }

        public bool HaySaldo(decimal costo, int cardId)
        {
            var saldo = balanceApi.ObtenerSaldoPorCardId(cardId);
            return saldo.Balance >= costo;
        }
    }
}