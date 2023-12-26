using AutoMapper;
using BlogApp.Business.DTOs.UserDtos;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task Register(RegisterDto registerDto)
        {
            AppUser user=_mapper.Map<AppUser>(registerDto);
            var result=await _userManager.CreateAsync(user, registerDto.Password);
           
        }
    }
}
