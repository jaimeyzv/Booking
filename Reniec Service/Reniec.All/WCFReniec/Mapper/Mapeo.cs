using Tecactus.Api.Reniec;
using WCFReniec.Dominio;

namespace WCFReniec.Mapper
{
    public class Mapeo
    {
        public Persona ConvertirPersonaApiAPersona(Person persona)
        {
            return new Persona()
            {
                Dni = persona.dni,
                Nombres = persona.nombres,
                ApellidoPaterno = persona.apellido_paterno,
                ApellidoMaterno = persona.apellido_materno
            };
        }
    }
}