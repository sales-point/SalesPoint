using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories.IRepositories
{
    public interface IMenuSetRepository : IRepository
    {
        void AddMenuSet(MenuSet menuSet);
        MenuSet GetMenuSet(int menuSetId);
        IQueryable<MenuSet> GetMenuSets(MenuSetFilter filter);
        IQueryable<MenuItem> GetMenuItems(MenuSet menuSet);
    }
}
