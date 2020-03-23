using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SalesPoint.Data.Data;
using SalesPoint.Data.Infos;

namespace SalesPoint.Data.Seeder
{
    public class DataSeeder
    {
        public static async Task InitDefaultUser(DataContext context, UserManager<ApplicationUser> userManager)
        {
            var defaultAdmin = new ApplicationUser()
            {
                FullName = "Admin",
                Email = "Admin@sushi.admin",
                UserName = "Admin"
            };
            var result = await userManager.CreateAsync(defaultAdmin, "123456Admin!");
            if (!result.Succeeded)
                throw new Exception("Unable to create default user!");
            
            var newUser = await userManager.FindByNameAsync("Admin");
            await userManager.AddToRoleAsync(newUser, "Administrator");
            
        }

        public static async Task InitRoles(DataContext context, RoleManager<ApplicationRole> roleManager)
        {
            var rolesList = new List<ApplicationRole>();

            foreach (var role in AppInfos.RolesInfo)
            {
                if (context.Roles.Any(r => r.Name.ToUpper() == role.ToUpper()))
                    continue;

                rolesList.Add(new ApplicationRole()
                {
                    Name = role,
                    NormalizedName = role
                });
            }

            foreach (var role in rolesList)
            {
                await roleManager.CreateAsync(role);
            }
        }

        public static void InitMenuTypes(DataContext context)
        {
            var menuTypesList = new List<MenuType>();

            foreach (var type in AppInfos.MenuTypesInfo)
            {
                if (context.MenuTypes.Any(r => r.Name.ToUpper() == type.ToUpper()))
                    continue;

                menuTypesList.Add(new MenuType()
                {
                    Name = type,
                });
            }

            foreach (var type in menuTypesList)
            {
                context.MenuTypes.Add(type);
            }
        }
    }
}
