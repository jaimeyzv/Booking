using System;
using WCFReniec.Dominio;
using WCFReniec.Mapper;

namespace WCFReniec
{
    public class ReniecService : IReniecService
    {
        private const string token = "oVz0iUHBaAV4prXuqahVBTN4znt81udOZW2vNZiZ";

        public bool EsDniValido(string dni)
        {
            try
            {
                var api = new Tecactus.Api.Reniec.Dni(token);
                var persona = api.get(dni);
                
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
                var persona = new Mapeo().ConvertirPersonaApiAPersona(personApi);
                return persona;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
