using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FindMyItem.REST.Container
{
    public class RESTInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IRestCommands>()
                .ImplementedBy<RestCommands>()
                    .DependsOn(Dependency.OnAppSettingsValue("webApiUrl", "WebAPI-URL"))
                                .LifeStyle.Singleton);
        }
    }
}
