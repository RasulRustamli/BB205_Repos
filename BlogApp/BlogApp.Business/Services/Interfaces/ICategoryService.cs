using BlogApp.Business.DTOs.CategoryDtos;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryListItemDto>> GetAllAsync();

        Task<bool> CreateAsync(CategoryCreateDto categoryDto);
        Task<CategoryDetailDto> GetByIdAsync(int id);
        Task<bool> Update(CategoryUpdateDto categoryDto);
        Task Delete(int id);
    }
}
