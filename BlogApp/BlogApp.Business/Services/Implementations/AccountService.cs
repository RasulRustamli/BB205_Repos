using AutoMapper;
using BlogApp.Business.DTOs.UserDtos;
using BlogApp.Business.Exceptions.User;
using BlogApp.Business.ExternalServices.Interfaces;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<AppUser> userManager,IMapper mapper,ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

       

        public async Task Register(RegisterDto registerDto)
        {
            AppUser user=_mapper.Map<AppUser>(registerDto);
            var result=await _userManager.CreateAsync(user, registerDto.Password);
           
        }


        public async Task<TokenResponseDto> LoginAsync(LoginDto dto)
        {
            var user= await _userManager.FindByNameAsync(dto.UserNameOrEmail)??await _userManager.FindByEmailAsync(dto.UserNameOrEmail);
            if (user == null) throw new UserNotFoundException();
            if (!await _userManager.CheckPasswordAsync(user, dto.Password)) throw new UserNotFoundException();

           return _tokenService.CreateToken(user);
        }
    }
}
