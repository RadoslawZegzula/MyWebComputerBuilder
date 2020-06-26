using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MyOnlineShop.DataBase;

namespace MyOnlineShop
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<DapperRepository>().As<IRepository>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}