using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using SalesPoint.Managers.IManagers;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Managers.Managers
{
    public class MenuItemManager : IMenuItemManager
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemManager(IMenuItemRepository menuItemRepository)
        {
            this._menuItemRepository = menuItemRepository;
        }

        public MenuItem AddMenuItem(MenuItem menuItem)
        {
            MenuItemFilter filter = new MenuItemFilter 
            {
                Name = menuItem.Name
            };
            if (GetMenuItems(filter).Any())
                throw new Exception($"Позиция с таким названием {menuItem.Name} уже есть в меню");

            _menuItemRepository.AddMenuItem(menuItem);
            _menuItemRepository.SaveChanges();
            return menuItem;
        }

        public MenuItem GetMenuItem(int menuItemId)
        {
            var item = _menuItemRepository.GetMenuItem(menuItemId);
            if (item == null)
                throw new Exception("Не удалось найти позицию меню");
            return item;
        }

        public IQueryable<MenuItem> GetMenuItems(MenuItemFilter filter)
        {
            return _menuItemRepository.GetMenuItems(filter);
        }
    }
}
