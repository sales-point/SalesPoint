using SalesPoint.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories.IRepositories
{
    public interface IRoleRepository
    {
        IQueryable<ApplicationRole> GetRoles(string name);
    }
}
