using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreApp.DataAccess;
using WebStoreApp.Dto;
using WebStoreApp.Services.Contract;
using WedStoreApp.Entities;

namespace WebStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController: ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            return await _categoryService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CategoryDto category)
        {
           return await _categoryService.Create(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            return await _categoryService.GetAll();
        }
    }
}
