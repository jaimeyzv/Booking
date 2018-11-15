using System.Collections.Generic;
using System.ServiceModel;
using WcfHotel.Dominio;
using WcfHotel.Errores;
using WcfHotel.Persistencia;

namespace WcfHotel
{
    public class HotelService : IHotelService
    {
        private HotelDAO dao = new HotelDAO();

        public Hotels ObtenerHotelPorCodigo(string codigo)
        {
            return dao.ObtenerPorCodigo(codigo);
        }

        public Hotels CrearHotel(Hotels hotel)
        {
            if (dao.ObtenerPorCodigo(hotel.Codigo) != null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "El hotel con el código ingresado ya existe."
                    }, new FaultReason("Error al crear hotel."));

            return dao.Crear(hotel);
        }

        public Hotels ModificarHotel(Hotels hotel)
        {
            if (dao.ObtenerPorCodigo(hotel.Codigo) == null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "102",
                        Descripcion = "El hotel ha modificar no existe."
                    }, new FaultReason("Error al modificar hotel."));

            return dao.Modificar(hotel);
        }

        public int EliminarHotel(string codigo)
        {
            if (dao.ObtenerPorCodigo(codigo) == null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "103",
                        Descripcion = "El hotel ha eliminar no existe."
                    }, new FaultReason("Error al modificar hotel."));

            return dao.Eliminar(codigo);
        }

        public List<Hotels> ListarHoteles()
        {
            return dao.Listar();
        }
    }
}