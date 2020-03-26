using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using SalesPoint.Managers.IManagers;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Managers
{
    public class MenuSetManager : IMenuSetManager
    {
        private readonly IMenuSetRepository _menuSetReporitory;
        private readonly IMenuItemRepository _menuItemRepository;
        public MenuSetManager(IMenuSetRepository menuSetRepository, IMenuItemRepository menuItemRepository)
        {
            _menuSetReporitory = menuSetRepository;
            _menuItemRepository = menuItemRepository;
        }
        public MenuSet AddMenuSet(MenuSet menuSet)
        {
            _menuSetReporitory.AddMenuSet(menuSet);
            _menuSetReporitory.SaveChanges();
            return menuSet;
        }

        public MenuSet GetMenuSet(int setId)
        {
            var menuSet = _menuSetReporitory.GetMenuSet(setId);
            if (menuSet == null)
                throw new Exception("Не удалось найти сет с таким идентификатором");
            return menuSet;
        }

        public IQueryable<MenuSet> GetMenuSets(MenuSetFilter filter)
        {
            var sets = _menuSetReporitory.GetMenuSets(filter);
            return sets;
        }

        public IQueryable<MenuItem> GetMenuItems(MenuSet menuSet)
        {
            return _menuSetReporitory.GetMenuItems(menuSet);
        }
    }
}
