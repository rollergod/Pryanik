using Mapster;
using Pryanik.Entities;
using Pryanik.Entities.Exceptions;
using Pryanik.Entities.ViewModels;
using Pryanik.Repositories.ItemsRepo;
using Pryanik.Repositories.OrdersRepo;

namespace Pryanik.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IItemsRepository _itemsRepository;
        public OrderService(IOrderRepository orderRepository, IItemsRepository itemsRepository)
        {
            _orderRepository = orderRepository;
            _itemsRepository = itemsRepository;
        }

        public void CreateOrder(OrderViewModel model)
        {
            var order = model.Adapt<Order>();

            if(model.itemIds.Count() > 0)
            {
                order.Items = new List<Item>();
                foreach (var itemId in model.itemIds)
                {
                    var item = _itemsRepository.GetItem(itemId); //can be null

                    if (item is null)
                        throw new NotFoundException(message: $"Item with id - {itemId} not found");

                    order.Items.Add(item);
                }
            }

            _orderRepository.Add(order);
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orderRepository.GetItem(orderId);

            if (order is null)
                throw new NotFoundException($"Order with id - {orderId} not found");

            _orderRepository.Delete(order);
        }

        public IEnumerable<Order> GetOrders(bool includeItems)
        {
            return _orderRepository.GetItems(includeItems);
        }
    }
}
