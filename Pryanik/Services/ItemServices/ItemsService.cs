using Mapster;
using Pryanik.Entities;
using Pryanik.Entities.Exceptions;
using Pryanik.Entities.ViewModels;
using Pryanik.Repositories.ItemsRepo;

namespace Pryanik.Services.ItemServices
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository _itemsRepository;

        public ItemsService(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public void CreateItem(ItemViewModel model)
        {
            Item item = model.Adapt<Item>();
            _itemsRepository.Add(item);
        }

        public void DeleteItem(int itemId)
        {
            var item = _itemsRepository.GetItem(itemId);
            if (item is null)
                throw new NotFoundException($"Item with id - {itemId} not found");
            _itemsRepository.Delete(item);

        }

        public IEnumerable<Item> GetItems()
        {
            var items = _itemsRepository.GetItems();

            return items;
        }
    }
}
