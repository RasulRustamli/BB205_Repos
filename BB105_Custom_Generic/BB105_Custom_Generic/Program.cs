namespace BB105_Custom_Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Student student = new Student()
            {
                Name = "Ismayil"
            };
            Student student1 = new Student()
            {
                Name = "Ziver"
            };
            Student student2 = new Student()
            {
                Name = "Cavidan"
            };





            CustomGeneric<Student> studentList = new CustomGeneric<Student>();

            CustomGeneric<string> intList=new CustomGeneric<string>();


            


        }
    }
}