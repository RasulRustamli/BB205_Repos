using AutoMapper;
using BlogApp.Business.DTOs.CategoryDtos;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Profiles
{
    public class CategoryMapProfiles:Profile
    {
        public CategoryMapProfiles()
        {
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryDetailDto, Category>().ReverseMap();
            CreateMap<CategoryDetailDto, Category>();
            CreateMap<CategoryListItemDto, Category>().ReverseMap();
            CreateMap<CategoryListItemDto, Category>();
        }

    }
}
