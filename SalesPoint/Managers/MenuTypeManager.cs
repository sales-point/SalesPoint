using SalesPoint.Data;
using SalesPoint.Data.Data;
using SalesPoint.Managers.IManagers;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Managers
{
    public class MenuTypeManager : IMenuTypeManager
    {
        private readonly DataContext _context;
        private readonly IMenuTypeRepository _menuTypeRepository;

        public MenuTypeManager(DataContext context, IMenuTypeRepository menuTypeRepository)
        {
            _context = context;
            _menuTypeRepository = menuTypeRepository;
        }

        public MenuType AddMenuType(string name)
        {
            if (_menuTypeRepository.GetMenuTypes(name).Any(t=>t.Name.ToUpper() == name.ToUpper()))
                throw new Exception($"Уже существует тип меню с именем {name}");

            var type = new MenuType
            {
                Name = name
            };

            _menuTypeRepository.AddMenuType(type);
            _menuTypeRepository.SaveChanges();
            return type;
        }

        public IQueryable<MenuType> GetMenuTypes(string name, int page, int countPerPage, out int total)
        {
            var query = _menuTypeRepository.GetMenuTypes(name);
            total = query.Count();
            return query.Skip((page - 1) * countPerPage).Take(countPerPage);
        }
    }
}
