using Microsoft.EntityFrameworkCore;
using Pryanik.Data;
using Pryanik.Entities;

namespace Pryanik.Repositories.OrdersRepo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Order item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Order item)
        {
            _context.Orders.Remove(item);
            _context.SaveChanges();
        }

        public Order GetItem(int id)
        {
           
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetItems(bool includeItems)
        {
            return !includeItems ? 
                _context.Orders.ToList() 
                : _context.Orders.Include(p => p.Items).ToList();
        }
    }
}
