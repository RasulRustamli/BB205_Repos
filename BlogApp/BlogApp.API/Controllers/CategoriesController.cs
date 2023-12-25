using BlogApp.Business.DTOs.CategoryDtos;
using BlogApp.Business.Exceptions.Category;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }  
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories= await _service.GetAllAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CategoryCreateDto  categoryDto)
        {
            bool result= await _service.CreateAsync(categoryDto);
            if(result)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status409Conflict);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]CategoryUpdateDto categoryDto)
        {
            try
            {
                if (await _service.Update(categoryDto)) return Ok();
                return StatusCode(StatusCodes.Status502BadGateway);
            }
            catch (NegativeIdException ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (CategoryNotFoundException ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }


        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            try
            {
               await _service.Delete(id);
                return Ok();
            }
            catch (NegativeIdException ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (CategoryNotFoundException ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
