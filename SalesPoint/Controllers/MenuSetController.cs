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
    public class MenuSetController : Controller
    {
        private readonly IMenuSetManager _menuSetManager;
        private readonly IMenuItemManager _menuItemManager;
        public MenuSetController(IMenuSetManager menuSetManager, IMenuItemManager menuItemManager)
        {
            _menuSetManager = menuSetManager;
            _menuItemManager = menuItemManager;
        }

        [HttpPost]
        public JsonResult Add([FromBody]MenuSetInView menuSetClient)
        {
            try
            {
                if (menuSetClient.Items.Count() == 0)
                    throw new Exception("Набор позиций не может быть пустым");

                var setItems = new List<MenuItemMenuSet>();
                foreach (var item in menuSetClient.Items)
                {
                    setItems.Add(new MenuItemMenuSet
                    {
                        MenuItemId = item.MenuItemId,
                        MenuItemCount = item.ItemCount,
                        MenuItem = _menuItemManager.GetMenuItem(item.MenuItemId)
                    });
                }
                var menuSet = new MenuSet
                {
                    Description = menuSetClient.Description,
                    Name = menuSetClient.Name,
                    Price = menuSetClient.Price.Value,
                    SetItems = setItems
                };
                _menuSetManager.AddMenuSet(menuSet);

                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetMenuSet(int id)
        {
            try
            {
                var menuSet = _menuSetManager.GetMenuSet(id);
                var result = new MenuSetOutView
                {
                    Description = menuSet.Description,
                    Name = menuSet.Name,
                    MenuSetId = menuSet.MenuSetId,
                    Price = menuSet.Price,
                    Items = _menuSetManager.GetMenuItems(menuSet)
                        .Select(mi => new MenuItemSetOutView
                        {
                            Description = mi.Description,
                            Mixture = mi.Mixture,
                            MenuItemId = mi.MenuItemId,
                            MenuTypeId = mi.MenuTypeId,
                            Name = mi.Name,
                            Price = mi.Price,
                            Weight = mi.Weight,
                            Count = menuSet.SetItems.Where(ms => ms.MenuItemId == mi.MenuItemId)
                                .SingleOrDefault().MenuItemCount
                        }).ToList()
                };
                return new JsonResult(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetMenuSets(MenuSetFilterView filterView)
        {
            try
            {
                var filter = new MenuSetFilter
                {
                    Name = filterView.Name,
                    MaxPrice = filterView.MaxPrice,
                    MinPrice = filterView.MinPrice
                };

                var menuSets = _menuSetManager.GetMenuSets(filter).Skip((filterView.Page - 1)*filterView.CountPerPage)
                    .Take(filterView.CountPerPage);

                var result = menuSets.Select(ms => new MenuSetOutView
                {
                    Description = ms.Description,
                    Name = ms.Name,
                    MenuSetId = ms.MenuSetId,
                    Price = ms.Price,
                    Items = _menuSetManager.GetMenuItems(ms)
                        .Select(mi => new MenuItemSetOutView
                        {
                            Description = mi.Description,
                            Mixture = mi.Mixture,
                            MenuItemId = mi.MenuItemId,
                            MenuTypeId = mi.MenuTypeId,
                            Name = mi.Name,
                            Price = mi.Price,
                            Weight = mi.Weight,
                            Count = ms.SetItems.Where(ms => ms.MenuItemId == mi.MenuItemId)
                                .SingleOrDefault().MenuItemCount
                        }).ToList()
                }).ToList();

                return new JsonResult(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }
    }
}