

using BB205_test.Services.Interfaces;

namespace BB205_test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
      
        private readonly ICategoryRepository _repository;
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryRepository repository,ICategoryService service)
        {
           
           _repository = repository;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAll();

            return StatusCode(StatusCodes.Status200OK,categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categories = await _service.GetById(id);

            return StatusCode(StatusCodes.Status200OK, categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDto categoryDto)
        {
            var category= await _service.Create(categoryDto);
            return StatusCode(StatusCodes.Status201Created,category);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDto categoryDto)
        {
            if (categoryDto.Id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var categories = await _repository.GetByIdAsync(categoryDto.Id);

            if (categories == null) return StatusCode(StatusCodes.Status404NotFound);

            categories.Name = categoryDto.Name;
            _repository.Update(categories);
            await _repository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK,categories);
        }
    }
}
