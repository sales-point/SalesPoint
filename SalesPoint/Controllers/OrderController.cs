using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesPoint.Data;
using SalesPoint.Data.Data;
using SalesPoint.Filters;
using SalesPoint.Managers.IManagers;
using SalesPoint.Models.ViewModels;

namespace SalesPoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ActionFilterValidation]
    public class OrderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderManager _orderManager;
        private readonly IMenuItemManager _menuItemManager;

        public OrderController(UserManager<ApplicationUser> userManager, IOrderManager orderManager,
            IMenuItemManager menuItemManager)
        {
            _userManager = userManager;
            _orderManager = orderManager;
            _menuItemManager = menuItemManager;
        }
        [HttpPost]
        //[Authorize(Roles = "Customer")]
        public async Task<JsonResult> Add([FromBody]OrderInView orderView)
        {
            try
            {
                ApplicationUser user = null;
                if (User.Identity.Name != null)
                    user = await _userManager.FindByNameAsync(User.Identity.Name);

                var order = new Order
                {
                    Address = orderView.Address,
                    Comment = orderView.Comment,
                    CustomerUserId = user?.Id,
                    Phone = user?.PhoneNumber ?? orderView.PhoneNumber,
                    OrderItems = orderView.Items.Select(ov => new OrderItem
                    {
                        MenuItemId = ov.ItemId.Value,
                        MenuItemCount = ov.Count.Value,
                    })
                };

                _orderManager.AddOrder(order);

                return new JsonResult(new { success = true, data = order.OrderId });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false });
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetById(int id)
        {
            try
            {
                var order = _orderManager.GetOrder(id);
                var managerUser = order.ManagerUserId == null ? 
                     null : await _userManager.FindByIdAsync(order.ManagerUserId.ToString());
                var view = new OrderOutView
                {
                    ManagerName = managerUser?.FullName,
                    OrderId = order.OrderId,
                    OrderItems = order.OrderItems.Select(oi =>
                    {
                        var item = _menuItemManager.GetMenuItem(oi.MenuItemId);
                        return new OrderItemOutView
                        {
                            Count = oi.MenuItemCount,
                            MenuItemId = oi.MenuItemId,
                            Description = item.Description,
                            MenuSetId = item.MenuSetId,
                            MenuTypeId = item.MenuTypeId,
                            Mixture = item.Mixture,
                            Name = item.Name,
                            Price = item.Price,
                            Weight = item.Weight
                        };
                    }),
                    Price = _orderManager.CalculateOrderPrice(order),
                    StepId = order.StepId
                };
                return new JsonResult(new { success = true, data = view });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false });
            }
        }

        /*public JsonResult Add()
        {
            try
            {
                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false });
            }
        }*/
    }
}