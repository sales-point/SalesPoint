using SalesPoint.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesPoint.Data.Infos
{
    public static class AppInfos
    {
        public static List<string> RolesInfo = new List<string>()
        {
            "Administrator",
            "Manager",
            "Customer",
            "Delivery"
        };

        public enum StepInfo
        {
            Accepted = 1,
            Assigned = 2,
            Confirmed = 3,
            Cooking = 4,
            ReadyForDeliver = 5,
            Delivering = 6,
            Delivered = 7,
            Closed = 8
        }

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
            },
            new MenuItem
            {
                MenuItemId = 3,
                MenuTypeId = (int)MenuTypeEnum.Drink,
                Mixture = "Филодельфия, что-то там ещё",
                Name = "Сет №1",
                Price = 600,
                Weight = 1000,
                Description = "Самый вкусный сет"
            }
        };

        public static List<MenuSet> MenuSets = new List<MenuSet>()
        {
            new MenuSet
            {
                MenuSetId = 1,
                Name = "Наруто и Сакура",
                Description = "Самый выгодный сет для двоих",
                SetItems = new List<MenuItemMenuSet>
                {
                    new MenuItemMenuSet 
                    {
                        MenuItemId = 1,
                        MenuItemCount = 2
                    },
                    new MenuItemMenuSet
                    {
                        MenuItemId = 2,
                        MenuItemCount = 2
                    },
                }
            }
        };

        public static List<OrderItem> OrderItems = new List<OrderItem>
        {
            new OrderItem 
            {
                MenuItemId = 1,
                MenuItemCount = 3,
                OrderId = 1,
                OrderItemId = 1
            },
            new OrderItem
            {
                MenuItemId = 3,
                MenuItemCount = 1,
                OrderId = 1,
                OrderItemId = 2
            },
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                Address = "Калуга, ул.Тугрика, д.1, кв.1",
                Comment = "Комментарий",
                CustomerUserId = new Guid("b5f5d742-8bdc-4923-9e4e-a4fe7aff5aca"),
                ManagerUserId = new Guid("4656998b-11f2-4ac3-969e-8e374022fbd8"),
                OrderDate = DateTime.Now,
                Paid = false,
                StepId = (int)StepInfo.Accepted,
                OrderItems = OrderItems.Where(oi=>oi.OrderId==1).ToList()
            }
        };
    }
}
