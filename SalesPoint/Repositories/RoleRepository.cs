using SalesPoint.Data;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationRole> GetRoles(string name)
        {
            return _context.Roles.Where(r => r.NormalizedName.Contains(name.ToUpper()));
        }
    }
}
