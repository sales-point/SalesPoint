using SalesPoint.Data;
using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using SalesPoint.Data.Infos;
using SalesPoint.Managers.IManagers;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuItemManager _menuItemManager;

        public OrderManager(IOrderRepository orderRepository, IMenuItemManager menuItemManager)
        {
            _orderRepository = orderRepository;
            _menuItemManager = menuItemManager;
        }

        public void AddOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            _orderRepository.ChangeOrderStep(order, AppInfos.StepInfo.Accepted);
            _orderRepository.AddOrder(order);
            foreach (var item in order.OrderItems)
            {
                item.OrderId = order.OrderId;
            }
            
            _orderRepository.SaveChanges();
        }

        public void AssignOrder(Order order, ApplicationUser managerUser)
        {
            _orderRepository.AssignOrder(order, managerUser);
            _orderRepository.SaveChanges();
        }

        public void ChangeOrderStep(Order order, AppInfos.StepInfo step)
        {
            _orderRepository.ChangeOrderStep(order, step);
            _orderRepository.SaveChanges();
        }

        public Order GetOrder(int orderId)
        {
            var order = _orderRepository.GetOrder(orderId);
            if (order == null)
                throw new Exception($"Не удалось найти заказ с идентификатором {orderId}");
            return order;
        }

        public IQueryable<Order> GetOrders(OrderFilter filter)
        {
            return _orderRepository.GetOrders(filter);
        }

        public decimal CalculateOrderPrice(Order order)
        {
            decimal price = 0;
            foreach (var item in order.OrderItems)
            {
                price += _menuItemManager.GetMenuItem(item.MenuItemId).Price * item.MenuItemCount;
            }
            return price;
        }
    }
}
