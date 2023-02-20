using Pryanik.Data;
using Pryanik.Entities;
using Pryanik.Entities.ViewModels;

namespace Pryanik.Repositories.ItemsRepo
{
    public class ItemRepository : IItemsRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public Item GetItem(int id)
        {
            return _context.Items.SingleOrDefault(i => i.Id == id); 
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }
    }
}
