using SalesPoint.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPoint.Data.Infos
{
    public static class AppInfos
    {
        public static List<string> RolesInfo = new List<string>()
        {
            "Administrator"
        };

        public static List<string> MenuTypesInfo = new List<string>()
        {
            "Суши",
            "Роллы",
            "Темпура",
            "Wok",
            "Соус",
            "Напиток"
        };

        public static List<MenuItem> MenuItems = new List<MenuItem>()
        {
            new MenuItem
            {
                MenuItemId = 1,
                MenuTypeId = (int)MenuTypeEnum.Roll,
                Mixture = "Рис, лосось, сыр",
                Name = "Филодельфия",
                Price = 220,
                Weight = 200,
                Description = "Самые вкусные роллы на свете"
            },
            new MenuItem
            {
                MenuItemId = 2,
                MenuTypeId = (int)MenuTypeEnum.Drink,
                Mixture = "Кислота, какая то химия и ещё что-то",
                Name = "Кола",
                Price = 90,
                Weight = 600,
                Description = "Вкусный напиток"
            }

        };
    }
}
