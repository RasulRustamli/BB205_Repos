using BB205_test.DAL;
using BB205_test.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BB205_test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            return StatusCode(StatusCodes.Status200OK,categories);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id<=0) return StatusCode(StatusCodes.Status400BadRequest);
            var categories = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if(categories == null) return StatusCode(StatusCodes.Status404NotFound);
            
            return StatusCode(StatusCodes.Status200OK, categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created,category);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id,string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var categories = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (categories == null) return StatusCode(StatusCodes.Status404NotFound);

            categories.Name = name;

            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK,categories);

        }

    }
}
