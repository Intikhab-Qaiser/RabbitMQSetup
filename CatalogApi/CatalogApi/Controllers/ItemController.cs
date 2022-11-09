using CatalogApi.Models;
using CatalogApi.Repository;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModel;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemRepository _itemRepository;
        private readonly IBus _bus;

        public ItemController(ILogger<ItemController> logger, IItemRepository itemRepository, IBus bus)
        {
            _logger = logger;
            _itemRepository = itemRepository;
            _bus = bus;
        }

        [HttpPost]
        [Route("GetItems")]
        public IEnumerable<Item> Get([FromBody] ItemsFilterDto categoryDto)
        {
            return _itemRepository.GetItems(categoryDto.CategoryId, categoryDto.PageIndex, categoryDto.PageSize);
        }

        [HttpPost]
        [Route("AddItem")]
        public int Post([FromBody] Item item)
        {
            return _itemRepository.AddItem(item);
        }

        [HttpPut]
        [Route("UpdateItem")]
        public void Put([FromBody] Item item)
        {
            _itemRepository.UpdateItem(item);

            PublishItemPrice(item);
        }

        [HttpDelete]
        [Route("DeleteItem/{itemId}")]
        public void Delete([FromQuery] int itemId)
        {
            _itemRepository.DeleteItem(itemId);
        }

        private async void PublishItemPrice(Item item)
        {
            Uri uri = new Uri("rabbitmq://localhost:15672/itemQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(item);
        }
    }
}