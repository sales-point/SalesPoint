using SalesPoint.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Managers.IManagers
{
    public interface IMenuTypeManager
    {
        MenuType AddMenuType(string name);

        IQueryable<MenuType> GetMenuTypes(string name, int page, int countPerPage, out int total);
    }
}
