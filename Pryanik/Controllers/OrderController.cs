using Microsoft.AspNetCore.Mvc;
using Pryanik.Entities.ViewModels;
using Pryanik.Services.OrderService;

namespace Pryanik.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet(Name = "GetOrders")]
        public IActionResult GetOrders(bool includeItems)
        {
            return Ok(_orderService.GetOrders(includeItems));
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _orderService.CreateOrder(model);
            return RedirectToRoute("GetOrders",new {includeItems = true});
        }

        [HttpDelete]
        public IActionResult DeleteOrder(int orderId)
        {
            _orderService.DeleteOrder(orderId);
            return NoContent();
        }
    }
}
