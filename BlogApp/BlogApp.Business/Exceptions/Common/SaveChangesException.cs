using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Common
{
    public class SaveChangesException : Exception, IBaseException
    {
        public SaveChangesException()
        {
            ErrorMessage = "Deyisiklikler  Save olunmadi";
        }

        public SaveChangesException(string? message) : base(message)
        {
            ErrorMessage = message;
        }

        public string ErrorMessage { get; }

        public int StatusCode => StatusCodes.Status500InternalServerError;
    }
}
