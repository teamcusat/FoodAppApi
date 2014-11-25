// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Suyati Technologies Pvt. Ltd.">
//   Copyright(c) Suyati Technologies Pvt. Ltd. All rights reserved.
// </copyright>
// <summary>
//   The bootstrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FoodApp.Core
{
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;
    using FoodApp.Services.Account;
    using FoodApp.Data.Account;


    /// <summary>
    ///     The bootstrapper.
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        /// <returns>
        /// The <see cref="ILifetimeScope"/>.
        /// </returns>
        public static ILifetimeScope Initialize(Assembly assembly)
        {
            var builder = new ContainerBuilder();

            // register controllers
            builder.RegisterControllers(assembly);

            builder.RegisterApiControllers(assembly);

            // register services
            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // register repositories
            builder.RegisterAssemblyTypes(typeof(AccountRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // register Identity helper
            builder.RegisterType<IdentityHelper>().As<IdentityHelper>().InstancePerRequest();

            // register the filter providers
            builder.RegisterFilterProvider();

            // build the container
            IContainer container = builder.Build();

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);

            // set dependency resolver for web api .
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }

        /// <summary>
        /// The register web api.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public static void RegisterWebApi(ILifetimeScope container)
        {
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}