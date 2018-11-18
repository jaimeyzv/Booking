using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using WFCMiembros.Dominio;
using WFCMiembros.Errores;
using WFCMiembros.Persistencia;

namespace WFCMiembros
{
    public class MiembroServices : IMiembroServices
    {
        MiembroADO dao = new MiembroADO();

        public Miembro CrearMiembro(Miembro miembro)
        {
            if (dao.Obtener(miembro.Dni) != null)
            {
                throw new WebFaultException<DuplicadoException>(
                     new DuplicadoException()
                     {
                         Codigo = "103",
                         Descripcion = "Ya existe miembro con el dni ingresado: " + miembro.Dni
                     }, HttpStatusCode.Conflict);
            }

            return dao.Crear(miembro);
        }

        public int EliminarMiembro(string dni)
        {
            if (dao.Obtener(dni) == null)
            {
                throw new WebFaultException<NoExisteException>(
                     new NoExisteException()
                     {
                         Codigo = "102",
                         Descripcion = "No existe miembro con el dni ingresado: " + dni
                     }, HttpStatusCode.Conflict);
            }

            return dao.Eliminar(dni);
        }

        public List<Miembro> ListarMiembros()
        {
            return dao.Listar();
        }

        public Miembro ModificarMiembro(Miembro miembro)
        {
            if (dao.Obtener(miembro.Dni) == null)
            {
                throw new WebFaultException<NoExisteException>(
                     new NoExisteException()
                     {
                         Codigo = "101",
                         Descripcion = "No existe miembro con el dni ingresado: " + miembro.Dni
                     }, HttpStatusCode.Conflict);
            }

            return dao.Modificar(miembro);
        }

        public Miembro ObtenerMiembro(string dni)
        {
            if (dao.Obtener(dni) == null)
            {
                throw new WebFaultException<NoExisteException>(
                     new NoExisteException()
                     {
                         Codigo = "101",
                         Descripcion = "No existe miembro con el dni ingresado: " + dni
                     }, HttpStatusCode.Conflict);
            }

            return dao.Obtener(dni);
        }
    }
}