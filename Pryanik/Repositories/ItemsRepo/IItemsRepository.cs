using Pryanik.Entities;

namespace Pryanik.Repositories.ItemsRepo
{
    public interface IItemsRepository 
    {
        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        void Add(Item item);
        void Delete(Item item);
    }
}
