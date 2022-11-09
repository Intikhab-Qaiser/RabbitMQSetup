using CatalogApi.Models;
using SharedModel;

namespace CatalogApi.Repository
{
    public interface ICategoryRepository
    {
        public int AddCategory(Category category);

        public void UpdateCategory(Category category);

        public void DeleteCategory(int categoryId);

        public List<Item> GetItems(int categoryId, int pageIndex, int pageSize);

        public List<Category> GetCategories();
    }
}
