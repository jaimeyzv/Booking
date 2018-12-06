using System;
using WCFReniec.Dominio;
using WCFReniec.Mapper;

namespace WCFReniec
{
    public class ReniecService : IReniecService
    {
        //private const string token = "hldnOG3wL7IwPoXjQ6Xw9kzLOF92Rq35IygndbqX";
        //private const string token = "oVz0iUHBaAV4prXuqahVBTN4znt81udOZW2vNZiZ";
        private const string token = "RRilN9PHopYnJMNVXyNLA9ED5tY3gZTZovMdVGaC";


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