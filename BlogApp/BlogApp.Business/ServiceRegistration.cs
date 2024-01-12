using BlogApp.Business.ExternalServices.Implementations;
using BlogApp.Business.ExternalServices.Interfaces;
using BlogApp.Business.Services.Implementations;
using BlogApp.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IBlogService,BlogService>();
        }
    }
}
