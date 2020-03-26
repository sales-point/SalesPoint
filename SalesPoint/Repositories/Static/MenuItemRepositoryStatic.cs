using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using SalesPoint.Data.Infos;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories.Static
{
    public class MenuItemRepositoryStatic : IMenuItemRepository
    {
        public void AddMenuItem(MenuItem item)
        {
            item.MenuItemId = AppInfos.MenuItems.Count + 1;
            AppInfos.MenuItems.Add(item);
        }

        public MenuItem GetMenuItem(int menuItemId)
        {
            return AppInfos.MenuItems.Where(mi => mi.MenuItemId == menuItemId).FirstOrDefault();
        }

        public IQueryable<MenuItem> GetMenuItems(MenuItemFilter filter)
        {
            return AppInfos.MenuItems.AsQueryable().Where(mi =>
            (string.IsNullOrEmpty(filter.Name) || mi.Name.ToUpper().Contains(filter.Name.ToUpper())) &&
            (!filter.MenuTypeId.HasValue || mi.MenuTypeId == filter.MenuTypeId) &&
            (!filter.MinPrice.HasValue || mi.Price >= filter.MinPrice) &&
            (!filter.MaxPrice.HasValue || mi.Price <= filter.MaxPrice));
        }

        public void SaveChanges()
        {
            
        }
    }
}
