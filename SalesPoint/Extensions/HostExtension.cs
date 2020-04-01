using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesPoint.Data;
using SalesPoint.Data.Infos;
using SalesPoint.Data.Seeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Extensions
{
    public static class HostExtension
    {
        public static IHost Migrate(this IHost webHost)
        {
            using (var serviceScope = webHost.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                try
                {
                    context.Database.Migrate();
                }
                catch
                {

                }
            }

            return webHost;
        }

        public static IHost SeedingData(this IHost webHost)
        {
            var serviceScope = webHost.Services.CreateScope();
                var services = serviceScope.ServiceProvider;
                var context = services.GetService<DataContext>();
                var hostingEnvironment = services.GetService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>();
                var userManager = services.GetService<UserManager<ApplicationUser>>();
                var rolesManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

                if (hostingEnvironment.EnvironmentName == "Development")
                {
                    context.Database.BeginTransaction();
                try
                {
                    if (context.Roles.Select(r => r.Name).All(r => AppInfos.RolesInfo.Contains(r)))
                    {
                        var t = Task.Run(async () => await DataSeeder.InitRoles(context, rolesManager));
                        t.Wait();
                    }

                    if (!context.Users.Any())
                    { 
                        var t = Task.Run(async () => await DataSeeder.InitDefaultUser(context, userManager));
                        t.Wait();
                    }

                    if (context.MenuTypes.Select(mt => mt.Name).All(mt => AppInfos.MenuTypesInfo.Contains(mt)))
                        DataSeeder.InitMenuTypes(context);

                    context.SaveChanges();
                    context.Database.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        context.Database.RollbackTransaction();
                    }
                }

            return webHost;
        }
    }
}
