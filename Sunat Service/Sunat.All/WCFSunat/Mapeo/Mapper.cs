using Tecactus.Api.Reniec;
using WCFSunat.Dominio;

namespace WCFSunat.Mapeo
{
    public class Mapper
    {
        public Persona ConvertirPersonaApiAPersona(Person persona)
        {
            return new Persona() {
                Dni = persona.dni,
                Nombres = persona.nombres,
                ApellidoPaterno = persona.apellido_paterno,
                ApellidoMaterno = persona.apellido_materno
            };
        }
    }
}