using AutoMapper;
using BlogApp.Business.DTOs.CategoryDtos;
using BlogApp.Business.Exceptions.Category;
using BlogApp.Business.Exceptions.Common;
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
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

       

        public async Task<ICollection<CategoryListItemDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();


            //1 Select
            //ICollection<CategoryListItemDto> categoryListItemDtos = categories.Select(c => new CategoryListItemDto()
            //{
            //    Name = c.Name,
            //});

            //2 maping versiyasi 

            return  _mapper.Map<ICollection<CategoryListItemDto>>(categories);
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

        public async Task<CategoryDetailDto> GetByIdAsync(int id)
        {
          
            await CheckEntity(id);

            return _mapper.Map<CategoryDetailDto>(await _repo.FindById(id));
        }

        public async Task<bool> Update(CategoryUpdateDto categoryDto)
        {
            await CheckEntity(categoryDto.Id);
            Category category = await _repo.FindById(categoryDto.Id);
            _mapper.Map(categoryDto,category);
           var result=await _repo.SaveChangesAsync();
            if (result > 0) return true;
            return false;
        }
        public async Task CheckEntity(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            if (!await _repo.IsExist(id)) throw new CategoryNotFoundException();
            
        }
        public async Task Delete(int id)
        {
            await CheckEntity(id);
            await _repo.Remove(id);
            await _repo.SaveChangesAsync();
        }
    }
}
