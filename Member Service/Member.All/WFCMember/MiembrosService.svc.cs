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
                    }, new FaultReason("Error al crear miembro"));

            return dao.Crear(miembro);
        }

        public Miembro ModificarMiembro(Miembro miembro)
        {
            return dao.Modificar(miembro);
        }

        public void EliminarMiembro(string dni)
        {
            dao.Eliminar(dni);
        }

        public List<Miembro> ListarMiembros()
        {
            return dao.Listar();
        }
    }
}