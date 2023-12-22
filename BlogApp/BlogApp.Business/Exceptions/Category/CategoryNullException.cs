using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Category
{
    public class CategoryNullException:Exception
    {
        public CategoryNullException():base("Category Null ola bilmez")
        {
        }
        public CategoryNullException(string message):base(message)
        {
        }
    }
}
