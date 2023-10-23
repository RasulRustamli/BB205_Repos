using Bb205_Exception.Exceptions;

namespace Bb205_Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student();
                student.Age = 12;

            }
            catch(FormatException ex)
            {
                throw new Exception("elvida");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("salam");






        }
    }
}