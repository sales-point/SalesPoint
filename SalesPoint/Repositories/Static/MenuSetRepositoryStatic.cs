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
    public class MenuSetRepositoryStatic : IMenuSetRepository
    {
        public void AddMenuSet(MenuSet menuSet)
        {
            menuSet.MenuSetId = AppInfos.MenuSets.Count + 1;
            AppInfos.MenuSets.Add(menuSet);
        }

        public MenuSet GetMenuSet(int menuSetId)
        {
           return AppInfos.MenuSets.Where(ms => ms.MenuSetId == menuSetId).SingleOrDefault();
        }

        public IQueryable<MenuSet> GetMenuSets(MenuSetFilter filter)
        {
            return AppInfos.MenuSets.AsQueryable().Where(ms =>
            (string.IsNullOrEmpty(filter.Name) || ms.Name.ToUpper().Contains(filter.Name.ToUpper())));
        }

        public IQueryable<MenuItem> GetMenuItems(MenuSet menuSet)
        {
            var query = from mi in AppInfos.MenuItems.AsQueryable()
            join mims in menuSet.SetItems on mi.MenuItemId equals mims.MenuItemId
            select mi;
            return query;
        }

        public void SaveChanges()
        {
        }
    }
}
