using AutoMapper;
using BlogApp.Business.DTOs.UserDtos;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Profiles
{
    public class UserMapProfiles:Profile
    {
        public UserMapProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<AuthorDto, AppUser>().ReverseMap();
            CreateMap<AuthorDto, AppUser>();
        }
    }
}
