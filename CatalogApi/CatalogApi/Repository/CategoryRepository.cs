using CatalogApi.Models;
using SharedModel;

namespace CatalogApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public int AddCategory(Category category)
        {
            Data.categories.Add(category);

            return category.Id;
        }

        public void UpdateCategory(Category category)
        {
            Category existingCategory = Data.categories.SingleOrDefault(c => c.Id == category.Id);
            existingCategory.Name = category.Name;
        }

        public void DeleteCategory(int categoryId)
        {
            Category existingCategory = Data.categories.SingleOrDefault(c => c.Id == categoryId);

            Data.items.RemoveAll(c => existingCategory.Id == categoryId);

            Data.categories.Remove(existingCategory);
        }

        public List<Item> GetItems(int categoryId, int pageIndex, int pageSize)
        {
            int skipRecords = (pageIndex - 1) * pageSize;
            return Data.items.Where(x => x.Id == categoryId).Skip(skipRecords).Take(pageSize).ToList();
        }

        public List<Category> GetCategories()
        {
            return Data.categories.ToList();
        }
    }
}
