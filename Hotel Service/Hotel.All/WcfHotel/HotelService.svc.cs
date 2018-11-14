using System.Collections.Generic;
using System.ServiceModel;
using WcfHotel.Dominio;
using WcfHotel.Errores;
using WcfHotel.Persistencia;

namespace WcfHotel
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "HotelService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione HotelService.svc o HotelService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class HotelService : IHotelService
    {
        private HotelDAO dao = new HotelDAO();

        public Hotel ConsultarHotel(string nombre)
        {
            return dao.Consultar(nombre);
        }

        public Hotel CrearHotel(Hotel hotel)
        {
            if (dao.Consultar(hotel.Nombre) != null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "El Hotel ya existe"
                    }, new FaultReason("Error al crear Hotel"));

            return dao.Crear(hotel);
        }

    
        public void EliminarHotel(int idHotel)
        {
            dao.Eliminar(idHotel);
        }

        public List<Hotel> ListarHoteles()
        {
            return dao.Listar();
        }

        public Hotel ModificarHotel(Hotel hotel)
        {
            return dao.Modificar(hotel);
        }
    }
}
