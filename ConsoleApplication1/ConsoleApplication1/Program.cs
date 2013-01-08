using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //application starts...
            var container = new WindsorContainer();

            // adds and configures all components using WindsorInstallers from executing assembly
            container.Install(FromAssembly.This());

            // instantiate and configure root component and all its dependencies and their dependencies and...
            var someApi = container.Resolve<ISomeApi>();
            var str = someApi.TheBestMethod();

            System.Console.Write(str);
            // clean up, application exits
            container.Dispose();
            System.Console.ReadKey();
        }
    }

    public class SomeApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                   .Where(Component.IsInSameNamespaceAs<SomeApi>())
                                   .WithService.DefaultInterfaces()
                                   .LifestyleTransient());

        }
    }
}
