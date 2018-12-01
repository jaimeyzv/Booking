using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using MobilityService.Dominio;
using MobilityService.Errores;
using MobilityService.Persistencia;

namespace MobilityService
{
    public class MobilityServices : IMobilityServices
    {
        MovilidadDAO dao = new MovilidadDAO();

        public List<Movilidad> ListarMovilidades()
        { return dao.Listar(); }

        public Movilidad ObtenerMovilidad(int codigo)
        {
            if(dao.Obtener(codigo) == null)
            {
                throw new WebFaultException<NoExisteException>(
                    new NoExisteException()
                    {
                        Codigo = "101",
                        Descripcion = "No existe movilidad con el código ingresado: " + codigo
                    }, HttpStatusCode.Conflict);
            }

            return dao.Obtener(codigo);
        }

        public Movilidad CrearMovilidad(Movilidad movilidad)
        {
            if (dao.Obtener(movilidad.codigo) != null)
            {
                throw new WebFaultException<DuplicadoException>(
                     new DuplicadoException()
                     {
                         Codigo = "102",
                         Descripcion = "Ya existe movilidad con el código ingresado: " + movilidad.codigo
                     }, HttpStatusCode.Conflict);
            }
            return dao.Crear(movilidad);
        }

        public Movilidad ModificarMovilidad(Movilidad movilidad)
        {
            if (dao.Obtener(movilidad.codigo) == null)
            {
                throw new WebFaultException<NoExisteException>(
                     new NoExisteException()
                     {
                         Codigo = "101",
                         Descripcion = "No existe movilidad con el código ingresado: " + movilidad.codigo
                     }, HttpStatusCode.Conflict);
            }
            return dao.Modificar(movilidad);
        }

        public int EliminarMovilidad(int codigo)
        {
            if (dao.Obtener(codigo) == null)
            {
                throw new WebFaultException<NoExisteException>(
                     new NoExisteException()
                     {
                         Codigo = "103",
                         Descripcion = "No existe movilidad con el código ingresado: " + codigo
                     }, HttpStatusCode.Conflict);
            }
            return dao.Eliminar(codigo);
        }
    }
}
