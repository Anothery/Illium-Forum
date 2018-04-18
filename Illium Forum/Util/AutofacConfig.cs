using Autofac;
using Autofac.Integration.Mvc;
using Domain.Content;
using System.Web.Mvc;

namespace Illium_Forum.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MySQLContentRepository>().As<IContentRepository>();
            builder.RegisterType<ContentContext>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }   
    }
}