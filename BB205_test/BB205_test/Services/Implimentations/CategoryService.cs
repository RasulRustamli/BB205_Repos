using AutoMapper;
using BB205_test.Services.Interfaces;

namespace BB205_test.Services.Implimentations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

      

        public async Task<IQueryable<Category>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");

            var category= await _repository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not found");
            return category;
        }
        public async Task<Category> Create(CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null) throw new Exception("Not null");

            //Category category = new Category()
            //{
            //    Name = createCategoryDto.Name,
            //    Description=createCategoryDto.Description,
            //    Tag=createCategoryDto.Tag
            //};

            Category category=_mapper.Map<Category>(createCategoryDto);

             await _repository.Create(category);
            await _repository.SaveChangesAsync();
            return category;
        }
    }
}
