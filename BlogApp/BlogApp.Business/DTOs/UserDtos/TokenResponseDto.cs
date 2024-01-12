using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.UserDtos
{
    public record TokenResponseDto
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
