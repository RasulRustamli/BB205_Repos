using BlogApp.Business.DTOs.UserDtos;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _service;

        public AuthController(IAccountService service)
        {
            _service = service;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
           await _service.Register(dto);
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result=await _service.LoginAsync(dto);
            return Ok(result);
        }
    }
}
