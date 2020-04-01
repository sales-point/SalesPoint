using SalesPoint.Data;
using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly DataContext _context;

        public MenuItemRepository(DataContext context)
        {
            _context = context;
        }
        public void AddMenuItem(MenuItem item)
        {
            _context.MenuItems.Add(item);
        }

        public MenuItem GetMenuItem(int menuItemId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MenuItem> GetMenuItems(MenuItemFilter filter)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
