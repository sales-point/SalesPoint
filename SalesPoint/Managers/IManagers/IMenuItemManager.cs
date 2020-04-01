using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Managers.IManagers
{
    public interface IMenuItemManager
    {
        MenuItem AddMenuItem(MenuItem menuItem);

        MenuItem GetMenuItem(int menuItemId);

        IQueryable<MenuItem> GetMenuItems(MenuItemFilter filter);
    }
}
