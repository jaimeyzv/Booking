namespace Reniec.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // instanciar un objecto de la clase Dni
            var dni = new Tecactus.Api.Reniec.Dni("oVz0iUHBaAV4prXuqahVBTN4znt81udOZW2vNZiZ");

            // el método 'get' devuelve un objeto de la clase Person.
            // Caso contrario lanza una excepción cuyo mensaje describe el error sucitado.
            var  person = dni.get("47470738");
        }
    }
}
