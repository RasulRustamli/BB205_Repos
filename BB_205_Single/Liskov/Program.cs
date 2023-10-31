namespace Liskov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person developer=new Developer();
            Person teacher=new Teacher();
            Person student=new Student();

            developer.GetName();
            developer.GetSurname();
            Console.WriteLine("---------------------");
            teacher.GetName();
            teacher.GetSurname();
            Console.WriteLine("------------------------");
            student.GetSurname();
            student.GetName();

        }
    }
}