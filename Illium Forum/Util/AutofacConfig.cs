using Autofac;
using Autofac.Integration.Mvc;
using Domain.Content;
using Domain.MySQLIdentity;
using RestSharp;
using System.Web;
using System.Web.Mvc;

namespace Illium_Forum.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ApiClient>().InstancePerRequest();
            builder.RegisterType<ApiContentRepository>().As<IContentRepository>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }   
    }
}