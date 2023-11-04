using BB205_Ado.net.DataBase;
using BB205_Ado.net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB205_Ado.net.Services
{
    internal class StudentsService
    {
        private Sql _database;

        public StudentsService()
        {
            _database = new Sql();
        }

        public void Add(Student student)
        {
            string commandSelect = $"INSERT INTO Students Values('{student.Name}',{student.Age})";
            int result=_database.NonQueryProsses(commandSelect);
            if(result>0)
            {
                Console.WriteLine("Data base elave olundu");
            }
            else
            {
                Console.WriteLine("Problem bas verdi");
            }
        }
        public void Delete(int id)
        {
            string command = $"DELETE FROM Students Where Id={id}";
            int result = _database.NonQueryProsses(command);
            if (result > 0)
            {
                Console.WriteLine($"Idsi-{id} Data silindi");
            }
            else
            {
                Console.WriteLine("Problem bas verdi");
            }
        }

        public List<Student> GetAll()
        {
            string command = "SELECT * FROM Students";
            DataTable table=_database.Query(command);
            List<Student> students = new List<Student>();
            foreach (DataRow item in table.Rows)
            {
                Student student = new Student()
                {
                    Id = Convert.ToInt32(item["Id"]),
                    Name = item["Name"].ToString(),
                    Age = Convert.ToInt32(item["Age"])
                };
                students.Add(student);
            }
            return students;
        }

    }
}
