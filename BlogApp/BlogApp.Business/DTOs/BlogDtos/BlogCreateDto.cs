using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.BlogDtos
{
    public class BlogCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? File { get; set; }
        public IEnumerable<int> CategoriesIds { get; set; }

    }
    public class BlogCreateDtoValidator : AbstractValidator<BlogCreateDto>
    {
        public BlogCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty()
                .MaximumLength(70);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(b => b.CategoriesIds)
                .NotEmpty()
                .Must(b => CheckEmpty(b))
                .WithMessage("Categoryalari duzgun sec");
                
        }
        public bool CheckEmpty(IEnumerable<int> ids)
        {
            
            foreach (int id in ids)
            {
                if(id<=0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
