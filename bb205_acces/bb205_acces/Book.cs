using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb205_acces
{
    internal class Book:Product
    {
        public string Genre { get; set; }
        public Book(string name, double price, int count,string genre) : base(name, price, count)
        {
            Genre = genre;
        }

        
    }
}
