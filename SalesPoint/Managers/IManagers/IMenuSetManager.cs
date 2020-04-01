using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Managers.IManagers
{
    public interface IMenuSetManager
    {
        MenuSet AddMenuSet(MenuSet menuSet);
        MenuSet GetMenuSet(int setId);
        IQueryable<MenuSet> GetMenuSets(MenuSetFilter filter);
        IQueryable<MenuItem> GetMenuItems(MenuSet menuSet);
    }
}
