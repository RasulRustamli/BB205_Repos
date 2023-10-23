using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB105_Custom_Generic
{
    internal class Student
    {
        static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Student()
        {
            _id++;
            Id = _id;
        }
        
        public override string ToString()
        {
            return $"Id :{Id}  Name :{Name}";
        }



    }
}
