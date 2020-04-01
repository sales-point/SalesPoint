using SalesPoint.Data;
using SalesPoint.Data.Data;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories
{
    public class MenuTypeRepository : IMenuTypeRepository
    {
        private readonly DataContext _context;

        public MenuTypeRepository(DataContext context)
        {
            _context = context;
        }

        public void AddMenuType(MenuType type)
        {
            _context.MenuTypes.Add(type);
        }

        public IQueryable<MenuType> GetMenuTypes(string name)
        {
            return _context.MenuTypes.Where(mt => mt.Name.ToUpper().Contains(name.ToUpper()));
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
