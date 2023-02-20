using Pryanik.Entities;
using Pryanik.Entities.ViewModels;

namespace Pryanik.Services.ItemServices
{
    public interface IItemsService
    {
        IEnumerable<Item> GetItems();
        void CreateItem(ItemViewModel model);
        void DeleteItem(int itemId);
    }
}
