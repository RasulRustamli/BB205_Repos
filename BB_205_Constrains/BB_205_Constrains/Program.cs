using BB_205_Constrains.Models;

namespace BB_205_Constrains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            AnimalsGeneric<Cat> animals = new AnimalsGeneric<Cat>();

            Cat cat = new Cat()
            {
                Name = "Tom"
            };
            Cat cat2 = new Cat()
            {
                Name = "John"
            };
            Cat cat3 = new Cat()
            {
                Name = "Jerry"
            };

            animals.Add(cat);
            animals.Add(cat2);
            animals.Add(cat3);


            AnimalsGeneric<Bird> animals2 = new AnimalsGeneric<Bird>();





        }
    }
}