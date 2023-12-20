namespace BB205_test.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Create(CreateCategoryDto createCategoryDto);
    }
}
