using BlogApp.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDtos
{
    public record CategoryCreateDto
    {
        
        public string? Name { get; set; }
        public IFormFile? Logo { get; set; }
    }
    public class CategoryCreateDtoValidation:AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidation()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Categoryani Bos qoya bilmersiz")
                .NotEmpty()
                .WithMessage("Categoryani Bos qoya bilmersiz")
                .MaximumLength(55)
                .WithMessage("Uzunlugu 55 den cox ola bilmez");
            RuleFor(c => c.Logo)
                .NotNull()
                .WithMessage("Sekli Bos qoya bilmersiz");

        }
    }

}
