using Pryanik.Entities;

namespace Pryanik.Repositories.OrdersRepo
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetItems(bool includeItems);
        Order GetItem(int id);
        void Add(Order item);
        void Delete(Order item);
    }
}
