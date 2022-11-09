using CatalogApi.Models;
using SharedModel;

namespace CatalogApi.Repository
{
    public static class Data
    {
        public static List<Item> items = new List<Item>
        {
            new Item { Id = 1, Name = "Item1", CategoryId = 1 },
            new Item { Id = 2, Name = "Item2", CategoryId = 1 },
            new Item { Id = 3, Name = "Item3", CategoryId = 1 },
            new Item { Id = 4, Name = "Item4", CategoryId = 2 },
            new Item { Id = 5, Name = "Item5", CategoryId = 2 },
        };

        public static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Category1" },
            new Category { Id = 2, Name = "Category2" }
        };
    }
}
