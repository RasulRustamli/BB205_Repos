using BlogApp.Business.Exceptions.Category;
using BlogApp.Business.Exceptions.Common;
using Microsoft.AspNetCore.Diagnostics;

namespace BlogApp.API.Utils
{
    public static class GlobalExceptionHandler
    {
        public static void UseException(this WebApplication app)
        {
            app.UseExceptionHandler(handler =>
            {
                handler.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();

                    if (feature?.Error is IBaseException ex)
                    {
                        context.Response.StatusCode = ex.StatusCode;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode=ex.StatusCode,
                            Message =ex.ErrorMessage
                        });
                    }

                    if (feature?.Path == "/")
                    {
                        await context.Response.WriteAsync(" Page: Home.");
                    }
                });
            });
        }
    }
}
