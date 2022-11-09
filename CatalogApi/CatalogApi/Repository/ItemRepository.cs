using CatalogApi.Models;
using SharedModel;

namespace CatalogApi.Repository
{
    public class ItemRepository : IItemRepository
    {
        public int AddItem(Item item)
        {
            Data.items.Add(item);

            return item.Id;
        }

        public void UpdateItem(Item item)
        {
            Item existingItem = Data.items.SingleOrDefault(c => c.Id == item.Id);
            existingItem.Name = item.Name;
        }

        public void DeleteItem(int itemId)
        {
            Item existingItem = Data.items.SingleOrDefault(c => c.Id == itemId);

            Data.items.Remove(existingItem);
        }

        public List<Item> GetItems(int categoryId, int pageIndex, int pageSize)
        {
            int skipRecords = (pageIndex - 1) * pageSize;
            return Data.items.Where(x => x.CategoryId == categoryId).Skip(skipRecords).Take(pageSize).ToList();
        }
    }
}
