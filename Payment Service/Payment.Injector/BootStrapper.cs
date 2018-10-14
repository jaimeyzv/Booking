using Unity;

namespace Payment.Injector
{
    public class BootStrapper
    {
        public IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();
            RegisterInsfrastructure(container);
            RegisterRepositories(container);
            RegisterBusiness(container);
            SvcLocator.Container = container;

            return container;
        }

        private void RegisterInsfrastructure(UnityContainer container)
        {
        }

        private void RegisterRepositories(UnityContainer container)
        {
        }

        private void RegisterBusiness(UnityContainer container)
        {
        }
    }
}