using System;
using WCFSunat.Dominio;
using WCFSunat.Mapeo;

namespace WCFSunat
{
    public class SunatService : ISunatService
    {
        private const string token = "oVz0iUHBaAV4prXuqahVBTN4znt81udOZW2vNZiZ";

        public bool EsDniValido(string dni)
        {
            try
            {
                var api = new Tecactus.Api.Reniec.Dni(token);
                var persona = api.get(dni);

                var api2 = new Tecactus.Api.Sunat.Ruc(token);

                var persona2 = api2.get(dni);
                return persona != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Persona ObtenerPersonaPorDni(string dni)
        {
            try
            {
                var api = new Tecactus.Api.Reniec.Dni(token);
                var personApi = api.get(dni);
                var persona = new Mapper().ConvertirPersonaApiAPersona(personApi);
                return persona;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
