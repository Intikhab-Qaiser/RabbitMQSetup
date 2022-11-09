using BasketApi.Repository;
using MassTransit;
using SharedModel;

namespace BasketApi
{
    public class ItemConsumer : IConsumer<Item>
    {
        public async Task Consume(ConsumeContext<Item> context)
        {
            var data = context.Message;
            var carts = Data.CartItems.Where(x => x.ItemId == data.Id);
            
            foreach(var cart in carts)
            {
                if(cart.ItemId == data.Id)
                {
                    cart.UnitPrice = data.Price;
                }
            }
        }
    }
}
