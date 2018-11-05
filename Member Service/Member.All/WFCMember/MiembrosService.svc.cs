using System.Collections.Generic;
using System.ServiceModel;
using WCFMember.Dominio;
using WCFMember.Errores;
using WCFMember.Persistencia;

namespace WFCMember
{
    public class MiembrosService : IMiembrosService
    {
        private MiembroDAO dao = new MiembroDAO();

        public Miembro ObtenerMiembro(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new FaultException<RepetidoException>(
                     new RepetidoException()
                     {
                         Codigo = "104",
                         Descripcion = "El dni ingresado no es válido."
                     }, new FaultReason("Error al obtener miembro."));
            }

            return dao.Obtener(dni);
        }

        public Miembro CrearMiembro(Miembro miembro)
        {
            if (dao.Obtener(miembro.Dni) != null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "El miembro ya existe"
                    }, new FaultReason("Error al crear miembro."));

            return dao.Crear(miembro);
        }

        public Miembro ModificarMiembro(Miembro miembro)
        {
            var miemrbo = dao.Obtener(miembro.Dni);
            if (miembro == null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "103",
                        Descripcion = "El dni del miembro a modificar no existe."
                    }, new FaultReason("Error al modificar miembro."));
            }

            return dao.Modificar(miembro);
        }

        public void EliminarMiembro(string dni)
        {
            var miembro = dao.Obtener(dni);
            if (miembro.Activo)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "102",
                        Descripcion = "No se puede eliminar miember si está activo."
                    }, new FaultReason("Error al eliminar miembro."));
            }

            dao.Eliminar(dni);
        }

        public List<Miembro> ListarMiembros()
        {
            return dao.Listar();
        }
    }
}