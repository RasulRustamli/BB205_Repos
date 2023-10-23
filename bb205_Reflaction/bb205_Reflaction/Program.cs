using bb205_Reflaction.Models;
using System.Reflection;

namespace bb205_Reflaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Assembly assembly= Assembly.GetExecutingAssembly();

            //foreach (Type type in assembly.GetTypes())
            //{
            //    Console.WriteLine("---------------------------------");
            //    Console.WriteLine(type.Name);
            //    Console.WriteLine("\t Constructor:");
            //    foreach (ConstructorInfo ctor in type.GetConstructors())
            //    {
            //        Console.WriteLine(ctor);
            //    }
            //    Console.WriteLine("\t Properties:");
            //    foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            //    {
            //        Console.WriteLine(prop);
            //    }

            //    Console.WriteLine("\t Fields");
            //    foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.Instance|BindingFlags.NonPublic))
            //    {
            //        Console.WriteLine(field);
            //    }

            //}

            Student student = new Student();

            Type type = typeof(Student);

            FieldInfo field = type.GetField("id",BindingFlags.NonPublic|BindingFlags.Instance);

            Console.WriteLine();
            field.SetValue(student, 76);
            Console.WriteLine(field.GetValue(student));


        }
    }
}