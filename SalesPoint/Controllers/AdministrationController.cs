using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesPoint.Data;
using SalesPoint.Filters;
using SalesPoint.Managers.IManagers;
using SalesPoint.Models.ViewModels;
using SalesPoint.Repositories.IRepositories;

namespace SalesPoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ActionFilterValidation]
   // [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        private readonly IMenuTypeManager _menuTypeManager;
        public AdministrationController(IMenuTypeManager menuTypeManager)
        {
            _menuTypeManager = menuTypeManager;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<JsonResult> GetMenuItems()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<JsonResult> AddMenuItem()
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<JsonResult> AddMenuType(MenuTypeInView menuType)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<JsonResult> GetMenuTypes(MenuTypeInView menuType)
        {
            try 
            {
                var total = 0;
                var menuTypes = _menuTypeManager.GetMenuTypes(menuType.Name ?? "", menuType.Page.Value,
                    menuType.CountPerPage.Value, out total)
                    .ToList()
                    .Select(t =>
                    {
                        return new MenuTypeOutView()
                        {
                            MenuTypeId = t.MenuTypeId,
                            MenuTypeName = t.Name
                        };
                    });
                return new JsonResult(new { success = true, total, menuTypes });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, 
                    message = $"Во время получения списка типов позиций меню была получена ошибка. {ex.Message}"});
            }
        }
    }
}