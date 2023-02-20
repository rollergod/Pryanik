using Pryanik.Entities;
using Pryanik.Entities.ViewModels;
using System.Collections.Generic;

namespace Pryanik.Services.OrderService
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders(bool includeItems);
        void DeleteOrder(int orderId);
        void CreateOrder(OrderViewModel model);
    }
}
