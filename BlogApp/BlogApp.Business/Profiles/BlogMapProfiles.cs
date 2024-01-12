using AutoMapper;
using BlogApp.Business.DTOs.BlogDtos;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Profiles
{
    public class BlogMapProfiles : Profile
    {
        public BlogMapProfiles()
        {
            CreateMap<BlogCreateDto, Blog>();
            CreateMap<Blog, BlogListItemDto>().ReverseMap();
            CreateMap<Blog, BlogDetailDto>().ReverseMap();
        }
    }
}
