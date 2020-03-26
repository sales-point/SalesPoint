using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using SalesPoint.Filters;
using SalesPoint.Managers.IManagers;
using SalesPoint.Models.ViewModels;

namespace SalesPoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class MenuItemController : Controller
    {
        private readonly IMenuItemManager _menuItemManager;
        public MenuItemController(IMenuItemManager menuItemManager)
        {
            this._menuItemManager = menuItemManager;
        }

        [HttpPost]
        public JsonResult Add(MenuItemInView view)
        {
            try
            {
                var menuItem = new MenuItem
                {
                    Description = view.Description,
                    MenuTypeId = view.MenuTypeId.Value,
                    Mixture = view.Mixture,
                    Name = view.Name,
                    Price = view.Price.Value,
                    Weight = view.Weight.Value
                };

                menuItem = _menuItemManager.AddMenuItem(menuItem);
                var outView = new MenuItemSetOutView
                 {
                     MenuItemId = menuItem.MenuItemId,
                     Description = menuItem.Description,
                     MenuTypeId = menuItem.MenuTypeId,
                     Mixture = menuItem.Mixture,
                     Name = menuItem.Name,
                     Price = menuItem.Price,
                     Weight = menuItem.Weight
                 };

                return new JsonResult(new { success = true, data = menuItem });
            }
            catch (Exception ex)
            {
                return new JsonResult(new {success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetByFilter(MenuItemFilterView filterModel)
        {
            try
            {
                var filter = new MenuItemFilter
                { 
                    MaxPrice = filterModel.MaxPrice,
                    MenuTypeId = filterModel.MenuTypeId,
                    MinPrice = filterModel.MinPrice,
                    Name = filterModel.Name
                };
                var items = _menuItemManager.GetMenuItems(filter);

                var total = items.Count();

                var itemsView = items
                    .Skip((filterModel.Page.Value-1)*filterModel.CountPerPage.Value)
                    .Take(filterModel.CountPerPage.Value)
                    .Select(i=> new MenuItemSetOutView
                    {
                        MenuItemId = i.MenuItemId,
                        Description = i.Description,
                        MenuTypeId = i.MenuTypeId,
                        Mixture = i.Mixture,
                        Name = i.Name,
                        Price = i.Price,
                        Weight = i.Weight
                    });
                return new JsonResult(new { success = true, data = itemsView.ToList(), total});
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetById(int? menuItemId)
        {
            try
            {
                if (!menuItemId.HasValue)
                    throw new Exception("Не указан идентификатор позиции меню");

                var item = _menuItemManager.GetMenuItem(menuItemId.Value);

                var itemView = new MenuItemSetOutView
                    {
                        MenuItemId = item.MenuItemId,
                        Description = item.Description,
                        MenuTypeId = item.MenuTypeId,
                        Mixture = item.Mixture,
                        Name = item.Name,
                        Price = item.Price,
                        Weight = item.Weight
                    };
                return new JsonResult(new { success = true, data = itemView });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

    }
}