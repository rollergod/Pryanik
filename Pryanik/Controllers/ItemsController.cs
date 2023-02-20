using Microsoft.AspNetCore.Mvc;
using Pryanik.Entities.ViewModels;
using Pryanik.Services.ItemServices;

namespace Pryanik.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;

        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet(Name = "GetItems")]
        public IActionResult GetItems()
        {
            var values = _itemsService.GetItems();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateItem(ItemViewModel model)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _itemsService.CreateItem(model);
            return RedirectToRoute("GetItems");
        }

        [HttpDelete]
        public IActionResult DeleteItem(int itemId)
        {
            _itemsService.DeleteItem(itemId);
            return NoContent();
        }
    }
}