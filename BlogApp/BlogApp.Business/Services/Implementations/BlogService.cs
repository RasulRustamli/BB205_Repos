using AutoMapper;
using BlogApp.Business.DTOs.BlogDtos;
using BlogApp.Business.DTOs.CategoryDtos;
using BlogApp.Business.DTOs.UserDtos;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Exceptions.User;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _repository;
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryRepository _categoryRepository;
        private string userId;

        public BlogService(IMapper mapper,IBlogRepository repository,IHttpContextAccessor context
            ,UserManager<AppUser> userManager,ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _context = context;
            this._userManager = userManager;
            this._categoryRepository = categoryRepository;
            userId = context.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
        
        public async Task<bool> CreateAsync(BlogCreateDto blogCreateDto)
        {
            if (userId == null) throw new ArgumentNullException();
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new UserNotFoundException();
            Blog blog = _mapper.Map<Blog>(blogCreateDto);
            blog.AppUserId = userId;
            List<BlogCategory> blogcategories = new();
            foreach(int id in blogCreateDto.CategoriesIds)
            {
                var Category = await _categoryRepository.FindById(id);
                if(Category == null) continue;
                blogcategories.Add(new BlogCategory()
                {
                    Blog=blog,
                    Category=Category
                });
            }
            blog.BlogCategories = blogcategories;
            await _repository.CreateAsync(blog);
            if (await _repository.SaveChangesAsync() > 0) return true;
            return false;
        }

      

       

        public async Task<BlogDetailDto> GetByIdAsync(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            string[] includes = { "AppUser", "BlogCategories", "BlogCategories.Category" };
            Blog blog = await _repository.FindById(id,false,includes);
            if (blog == null) throw new NotFountException<Blog>();
            blog.ViewerCount++;
            BlogDetailDto blogDetail=_mapper.Map<BlogDetailDto>(blog);
            List<CategoryListItemDto> categoryList = new List<CategoryListItemDto>();
            foreach (var item in blog.BlogCategories)
            {
                var CategoryDto = _mapper.Map<CategoryListItemDto>(item.Category);
                categoryList.Add(CategoryDto);
            }
            blogDetail.Categories = categoryList;
            blogDetail.User = _mapper.Map<AuthorDto>(blog.AppUser);
            await _repository.SaveChangesAsync();
            return blogDetail;
        }


        public async Task<ICollection<BlogListItemDto>> GetAllAsync()
        {
            var dto = new List<BlogListItemDto>();
            string[] includes = { "AppUser", "BlogCategories", "BlogCategories.Category" };
            var blogs = await _repository.GetAllAsync(includes: includes);
            var categories = new List<Category>();
            foreach(var item in blogs)
            {
                categories.Clear();
                foreach(var cat in item.BlogCategories)
                {
                    categories.Add(cat.Category);
                }
                var dtoItem = _mapper.Map<BlogListItemDto>(item);
                dtoItem.Categories = _mapper.Map<IEnumerable<CategoryListItemDto>>(categories);
                dtoItem.User=_mapper.Map<AuthorDto>(item.AppUser);
                dto.Add(dtoItem);
            }
            return dto;
   
        }

        public async Task SoftDelete(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            

            var blog = await _repository.FindById(id,includes: "AppUser");
            if (blog == null) throw new NotFountException<Blog>();
            if (blog.AppUserId != userId) throw new UserAuthorizeException();
            await _repository.SoftDelete(id);
            if (await _repository.SaveChangesAsync() < 1) throw new SaveChangesException();

        }

        public async Task ReverseSoftDelete(int id)
        {
            if (id <= 0) throw new NegativeIdException();


            var blog = await _repository.FindById(id,true, "AppUser");
            if (blog == null) throw new NotFountException<Blog>();
            if (blog.AppUserId != userId) throw new UserAuthorizeException();
            await _repository.ReverseSoftDelete(id);
            if (await _repository.SaveChangesAsync() < 1) throw new SaveChangesException();
        }

        public async Task Remove(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            var blog = await _repository.FindById(id, includes:"AppUser");
            if (blog == null) throw new NotFountException<Blog>();
            if (blog.AppUserId != userId) throw new UserAuthorizeException();
            await _repository.Remove(id);
            if (await _repository.SaveChangesAsync() < 1) throw new SaveChangesException();
        }
    }
}
