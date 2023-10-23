using BB205_Static_class.Helper;
using BB205_Static_class.Models;

namespace BB205_Static_class
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person();
            person.Name = "Ismayil";
            //Person person2 = new Person();

            //Person person3 = new Person();


            //Person person4 = new Person();

            Console.WriteLine("Reverse olunacaq sozu daxil edin");
            string input = Console.ReadLine();
            Console.WriteLine(input.ReverseString('d',"salam"));

            person.GetFullName();
            
            
        }

       

    }
}