using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Common
{
    public class NegativeIdException:Exception,IBaseException
    {
        public NegativeIdException(){
            ErrorMessage = "Id menfi ola bilmez";
        }
        public NegativeIdException(string message) : base(message) { 
        ErrorMessage=message;
        }

        public string ErrorMessage { get; }

        public int StatusCode => StatusCodes.Status400BadRequest;
    }
}
