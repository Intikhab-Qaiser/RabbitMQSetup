using CatalogApi.Models;
using CatalogApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetCategories")]
        public IEnumerable<Category> Get()
        {
            return _categoryRepository.GetCategories();
        }

        [HttpPost]
        [Route("AddCategory")]
        public int Post([FromBody] Category category)
        {
            return _categoryRepository.AddCategory(category);
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public void Put([FromBody] Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }

        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        public void Delete([FromQuery] int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }
    }
}