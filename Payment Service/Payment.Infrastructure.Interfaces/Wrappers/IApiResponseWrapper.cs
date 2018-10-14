using System.Net;
using System.Net.Http;

namespace Payment.Infrastructure.Interfaces.Wrappers
{
    public interface IApiResponseWrapper
    {
        HttpResponseMessage Response(HttpStatusCode httpStatusCode, object viewModel);
    }
}