using SalesPoint.Data;
using SalesPoint.Data.Data;
using SalesPoint.Data.Data.Filters;
using SalesPoint.Data.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesPoint.Repositories.IRepositories
{
    public interface IOrderRepository : IRepository
    {
        void AddOrder(Order order);
        Order GetOrder(int orderId);
        IQueryable<Order> GetOrders(OrderFilter filter);
        void ChangeOrderStep(Order order, AppInfos.StepInfo step);
        void AssignOrder(Order order, ApplicationUser manager);
    }
}
