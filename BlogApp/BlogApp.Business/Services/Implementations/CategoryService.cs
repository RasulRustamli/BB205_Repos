using BlogApp.Business.DTOs.CategoryDtos;
using BlogApp.Business.Exceptions.Category;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

       

        public async Task<ICollection<Category>> GetAllAsync()
        {
            var categories=await _repo.GetAllAsync();

            return await categories.ToListAsync();
        }
        public async Task<bool> CreateAsync(CategoryCreateDto categoryDto)
        {
            if (categoryDto == null) throw new CategoryNullException();

            Category category = new Category()
            {
                Name = categoryDto.Name,
                LogoUrl = "asdasdas",
                IsDeleted = false
            };

            await _repo.CreateAsync(category);
            int result = await _repo.SaveChangesAsync();

            if(result>0)
            {
                return true;
            }
            return false;
        }
    }
}
