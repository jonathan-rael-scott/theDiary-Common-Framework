using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Routing;
namespace System.Web.Mvc.Hosting
{
    public static partial class HostingExtensions
    {
        internal static void RegisterControllers(this Assembly moduleAssembly, RouteCollection routeCollection, string hostedApplicationName)
        {
            moduleAssembly.GetTypes().Where(a => a.IsSubclassOf(typeof(Controller))).Select<Type, string>(a => a.Namespace).Distinct().ForEachAsParallel(a => routeCollection.RegisterControllerNamespace(a, hostedApplicationName));
        }

        public static void RegisterControllerNamespace(this RouteCollection routeCollection, string controllerNamespace, string hostedApplicationName)
        {
            string routeName = string.Format("{0}_Controllers", hostedApplicationName);
            string routePath = hostedApplicationName + "/{controller}/{action}/{id}";
            routeCollection.MapRoute(name: routeName,
                    url: routePath,
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index",
                        id = UrlParameter.Optional
                    },
                    constraints: null,
                    namespaces: new string[] { controllerNamespace });
        }

        public static void RegisterController(this RouteCollection routeCollection, Type controllerType, string hostedApplicationName)
        {
            string controllerName = controllerType.Name.Replace("Controller", string.Empty);
            string routeName = controllerType.FullName.Replace(".", "_").Replace("Controller", "Views");
            string routePath = hostedApplicationName + "/" + controllerName + "/{action}/{id}";
            routeCollection.MapRoute(name: routeName,
                    url: routePath,
                    defaults: new
                    {
                        controller = controllerName,
                        action = "Index",
                        id = UrlParameter.Optional
                    },
                    constraints: null,
                    namespaces: new string[] { controllerType.Namespace });
        }

        #region Hosted Application Validation Methods & Functions
        /// <summary>
        /// Determines if a Hosted Application is configured correctly.
        /// </summary>
        /// <param name="hostedApplication">A <see cref="IHostedApplication"/> instance to validate.</param>
        /// <returns><c>True</c> if the <paramref name="hostedApplication"/> is not configured; otherwise <c>False</c>.</returns>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="hostedApplication"/> is <c>Null</c>.</exception>
        public static bool IsInvalid(this IHostedApplication hostedApplication)
        {
            if (hostedApplication.IsNull())
                throw new ArgumentNullException("hostedApplication");

            return hostedApplication.Identifier.IsNullEmptyOrWhiteSpace()
                 || !hostedApplication.HasDbContextType();
        }

        public static bool HasDbContextType(this IHostedApplication hostedApplication)
        {
            if (hostedApplication.IsNull())
                throw new ArgumentNullException("hostedApplication");

            return hostedApplication.ApplicationContextType.IsNotNull();
        }

        public static bool HasMigrationConfigurationType(this IHostedApplication hostedApplication)
        {
            if (hostedApplication.IsNull())
                throw new ArgumentNullException("hostedApplication");

            return hostedApplication.MigrationConfigurationType.IsNotNull();
        }

        public static bool HasMigrationConfiguration(this IHostedApplication hostedApplication)
        {
            if (hostedApplication.IsNull())
                throw new ArgumentNullException("hostedApplication");

            return hostedApplication.GetMigrationConfiguration().IsNotNull();
        }
        #endregion

        public static void RegisterHostedApplication(this IHostedApplication hostedApplication)
        {
            hostedApplication.RegisterHostedApplication(RouteTable.Routes);
        }

        public static void RegisterHostedApplication(this IHostedApplication hostedApplication, RouteCollection routeCollection)
        {
            var pathProvider = new EmbeddedViewVirtualPathProvider(hostedApplication.ApplicationName, hostedApplication.ApplicationContextType.Assembly);
            HostingEnvironment.RegisterVirtualPathProvider(pathProvider);

            hostedApplication.ApplicationContextType.Assembly.GetTypes().Where(a => a.IsSubclassOf(typeof(Controller))).ForEachAsParallel(a =>
            {
                string controllerName = a.Name.Replace("Controller", string.Empty);
                string routeName = string.Format("{0}_{1}", hostedApplication.ApplicationName, controllerName);
                string routeUrl = hostedApplication.ApplicationName + "/" + controllerName + "/{action}/{id}";
                routeCollection.MapRoute(name: routeName,
                    url: routeUrl,
                    defaults: new
                    {
                        controller = controllerName,
                        action = "Index",
                        id = UrlParameter.Optional
                    },
                    constraints: null,
                    namespaces: new string[] { a.Namespace });
            });
        }

        public static void InitializeContext(this IHostedApplication hostedApplication, Type configurationType, Type databaseInitializerType, Type databaseContainerType)
        {
            try
            {
                if (hostedApplication.IsNull())
                    throw new ArgumentNullException("hostedApplication");

                var context = hostedApplication.CreateApplicationContext(configurationType);

                if (hostedApplication.HasMigrationConfigurationType())
                {
                    Type migType = databaseInitializerType.MakeGenericType(hostedApplication.ApplicationContextType, context.GetType());
                    var migration = System.Activator.CreateInstance(migType);

                    var mi = databaseContainerType.GetMethods().Where(a => a.Name == "SetInitializer" && a.GetGenericArguments().Length == 1).FirstOrDefault();
                    var method = mi.MakeGenericMethod(hostedApplication.ApplicationContextType);

                    method.Invoke(null, new[] { migration });
                }
            }
            catch (Exception ex)
            {
                throw new System.Data.EntityException("Error Initializing Hosted Application", ex);
            }
        }

        public static void InitializeMigration(this IHostedApplication hostedApplication)
        {
            if (hostedApplication.HasMigrationConfiguration())
            {
                DbMigrationsConfiguration migrationConfiguration = hostedApplication.GetMigrationConfiguration() as DbMigrationsConfiguration;
                var migrator = new DbMigrator(migrationConfiguration);
                migrator.Update();
            }
        }
        public static object CreateApplicationContext(this IHostedApplication hostedApplication, Type configurationType)
        {
            return System.Activator.CreateInstance(configurationType.MakeGenericType(hostedApplication.ApplicationContextType));
        }
    }
}
