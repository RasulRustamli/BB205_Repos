using BlogApp.Business.DTOs.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface IBlogService
    {
        Task<ICollection<BlogListItemDto>> GetAllAsync();

        Task<bool> CreateAsync(BlogCreateDto blogCreateDto);
        Task<BlogDetailDto> GetByIdAsync(int id);
       
        Task SoftDelete(int id);
        Task ReverseSoftDelete(int id);
        Task Remove(int id);
    }
}
