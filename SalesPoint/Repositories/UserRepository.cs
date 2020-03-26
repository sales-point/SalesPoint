using SalesPoint.Data;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationUser> GetPagedUsers(int page, int countPerPage)
        {
            return _context.Users
               .Skip(page * countPerPage)
               .Take(countPerPage);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
