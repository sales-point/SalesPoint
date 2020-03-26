using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories.IRepositories
{
    public interface IMenuItemRepository : IRepository
    {
        void AddMenuItem(MenuItem item);

        IQueryable<MenuItem> GetMenuItems(MenuItemFilter filter);

        MenuItem GetMenuItem(int menuItemId);

    }
}
