using SalesPoint.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories.IRepositories
{
    public interface IMenuTypeRepository : IRepository
    {
        IQueryable<MenuType> GetMenuTypes(string name);
        void AddMenuType(MenuType type);
    }
}
