using SalesPoint.Data;
using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using SalesPoint.Data.Infos;
using SalesPoint.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories.Static
{
    public class OrderRepositoryStatic : IOrderRepository
    {
        public void AddOrder(Order order)
        {
            order.OrderId = AppInfos.Orders.Count + 1;
            AppInfos.Orders.Add(order);
        }

        public void AssignOrder(Order order, ApplicationUser manager)
        {
            order.ManagerUserId = manager.Id;
        }

        public void ChangeOrderStep(Order order, AppInfos.StepInfo step)
        {
            order.StepId = (int)step;
        }

        public Order GetOrder(int orderId)
        {
            return AppInfos.Orders.SingleOrDefault(o=>o.OrderId == orderId);
        }

        public IQueryable<Order> GetOrders(OrderFilter filter)
        {
            var query = AppInfos.Orders.AsQueryable().Where(o =>
            (!filter.CustomerId.HasValue || o.CustomerUserId == filter.CustomerId)
            && (!filter.ManagerId.HasValue || o.ManagerUserId == filter.ManagerId)
            && (!filter.endDate.HasValue || o.OrderDate <= filter.endDate)
            && (!filter.startDate.HasValue || o.OrderDate >= filter.startDate)
            && (filter.StepIds == null || filter.StepIds.Contains(o.StepId)));
            return query;
        }

        public void SaveChanges()
        {
        }
    }
}
