using Payment.Injector;
using System.Web.Http;
using Unity.WebApi;

namespace Payment.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new BootStrapper();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container.RegisterComponents());
        }
    }
}