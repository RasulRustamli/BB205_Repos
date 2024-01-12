using BlogApp.Business.Exceptions.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.User
{
    public class UserAuthorizeException : Exception, IBaseException
    {
        public UserAuthorizeException()
        {
            ErrorMessage = "Blogu sile bilmersiz";
        }

        public UserAuthorizeException(string? message) : base(message)
        {
            ErrorMessage = message;
        }

        public string ErrorMessage { get; }

        public int StatusCode => StatusCodes.Status401Unauthorized;
    }
}
