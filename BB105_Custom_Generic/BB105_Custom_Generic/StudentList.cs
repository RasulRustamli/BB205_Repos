using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB105_Custom_Generic
{
    internal class StudentList
    {

        Student[] Students;
        public StudentList()
        {
            Students=Array.Empty<Student>();
        }

        public void Add(Student item)
        {
            Array.Resize(ref Students, Students.Length+1);
            Students[Students.Length-1]=item;
        }
        public int Count()
        {
            return Students.Length;
        }

        public Student FindByIndex(int index)
        {
            return Students[index];
        }
    }
}
