using BlogApp.Business.DTOs.BlogDtos;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService service;

        public BlogsController(IBlogService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await service.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]BlogCreateDto dto)
        {
              if (await service.CreateAsync(dto)) return Ok();
                return BadRequest();
            
           
        }
        [HttpDelete("[Action]")]
        public async Task<IActionResult> SoftDelete(int Id)
        {
            await service.SoftDelete(Id);
            return Ok();
        }
        [HttpDelete("[Action]")]
        public async Task<IActionResult> ReverseDelete(int Id)
        {
            await service.ReverseSoftDelete(Id);
            return Ok();
        }
        [HttpDelete("[Action]")]
        public async Task<IActionResult> Remove(int Id)
        {
            await service.Remove(Id);
            return Ok();
        }
    }
}
