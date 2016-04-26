using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FindMyItem.Managers.Container;
using FindMyItem.REST.Container;
using FindMyItem.WebUI.Controllers;

namespace FindMyItem.WebUI.Container
{
    public class UiWebInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Classes.FromThisAssembly()
            //    .Where(type => type.Name.EndsWith("Manager"))
            //    .WithServiceDefaultInterfaces()
            //        .Configure(c => c.LifestyleTransient()));

            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn(typeof(BaseController))
                    // .WithServices(typeof(BaseController))
                    .LifestyleTransient());

            container.Install(new RESTInstaller());
            container.Install(new ManagersInstaller());
        }
    }
}