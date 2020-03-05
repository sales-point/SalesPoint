using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SalesPoint.Data.Infos;

namespace SalesPoint.Data.Seeder
{
    public class DataSeeder
    {
        public static async void InitDefaultUser(DataContext context, UserManager<ApplicationUser> userManager)
        {
            var defaultAdmin = new ApplicationUser()
            {
                FullName = "Admin",
                Email = "Admin@sushi.admin",
                UserName = "Admin"
            };
            var result = await userManager.CreateAsync(defaultAdmin);
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

            //var taskList = new List<Task>();

            foreach (var role in rolesList)
            {
                /*var task = Task.Run(async () => await roleManager.CreateAsync(role));
                taskList.Add(task);*/
                await roleManager.CreateAsync(role);
            }

            /*while (!taskList.All(t => t.IsCompleted))
            {
                taskList.FirstOrDefault(t => t.IsCompleted).Wait();
            }*/
        }
    }
}
