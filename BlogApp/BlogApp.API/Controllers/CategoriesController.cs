using BlogApp.Business.DTOs.CategoryDtos;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }  
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories= await _service.GetAllAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CategoryCreateDto  categoryDto)
        {
            bool result= await _service.CreateAsync(categoryDto);
            if(result)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status409Conflict);
        }
    }
}
