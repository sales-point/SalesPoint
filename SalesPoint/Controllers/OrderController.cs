using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesPoint.Attributes;
using SalesPoint.Data;
using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using SalesPoint.Data.Infos;
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
        private readonly ILogger _logger;

        public OrderController(UserManager<ApplicationUser> userManager, IOrderManager orderManager,
            IMenuItemManager menuItemManager, ILogger<OrderController> logger)
        {
            _userManager = userManager;
            _orderManager = orderManager;
            _menuItemManager = menuItemManager;
            _logger = logger;
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
                return new JsonResult(new { success = false, msg = ex.Message });
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
                    StepId = order.StepId,
                    Address = order.Address,
                    Phone = order.Phone,
                    Comment = order.Comment
                };
                return new JsonResult(new { success = true, data = view });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetByFilter(OrderFilterView filterView)
        {
            try
            {
                var filter = new OrderFilter
                {
                    CustomerId = filterView.CustomerId,
                    endDate = filterView.endDate,
                    ManagerId = filterView.ManagerId,
                    startDate = filterView.startDate,
                    StepIds = filterView.StepIds
                };
                var orders = _orderManager.GetOrders(filter).Skip((filterView.Page-1) * filterView.CountPerPage)
                    .Take(filterView.CountPerPage);

                var resultView = orders.ToList().Select(async order => { 
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
                        StepId = order.StepId,
                        Address = order.Address,
                        Phone = order.Phone,
                        Comment = order.Comment
                    };
                    return view;
                }).Select(r=>r.Result).ToList();
                return new JsonResult(new { success = true, data = resultView });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<JsonResult> AssignOrder(int orderId, Guid managerId)
        {
            try
            {
                var managerUser = await _userManager.FindByIdAsync(managerId.ToString());
                var order = _orderManager.GetOrder(orderId);
                _orderManager.AssignOrder(order, managerUser, true);
                return new JsonResult(new { success = true});
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Manager,Administrator")]
        public async Task<JsonResult> TakeOrder(int orderId)
        {
            try
            {
                var managerUser = await _userManager.GetUserAsync(User);
                var order = _orderManager.GetOrder(orderId);
                _orderManager.AssignOrder(order, managerUser);
                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Manager,Administrator")]
        [Logger(true)]
        public async Task<JsonResult> ChangeStep(int orderId, int stepId)
        {
            var flag = (bool)AttributeHelper.GetAttribute(typeof(OrderController).GetMethod("ChangeStep"));
            var start = DateTime.Now;
            try
            {
                var order = _orderManager.GetOrder(orderId);
                _orderManager.ChangeOrderStep(order, (AppInfos.StepInfo)stepId);
                var end = DateTime.Now;
                if (flag)
                    _logger.LogInformation($"Time {(end-start).TotalMilliseconds} ms");
                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }
    }
}