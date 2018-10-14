using System.Net;

namespace Stamping.Api.ViewModels
{
    public class ApiResponse
    {
        public string Date { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public object Response { get; set; }
    }
}