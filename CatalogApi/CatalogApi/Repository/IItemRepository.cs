using CatalogApi.Models;
using SharedModel;

namespace CatalogApi.Repository
{
    public interface IItemRepository
    {
        public int AddItem(Item item);

        public void UpdateItem(Item item);

        public void DeleteItem(int itemId);

        public List<Item> GetItems(int categoryId, int pageIndex, int pageSize);
    }
}
