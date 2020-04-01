using SalesPoint.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories.IRepositories
{
    public interface IUserRepository : IRepository
    {
        public IQueryable<ApplicationUser> GetPagedUsers(int page, int countPerPage);
    }
}
