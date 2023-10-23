using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_205_Constrains.Models
{
    internal class AnimalsGeneric<T> where T:Animal,new()
                                      
    {
        T[] animals;
        public AnimalsGeneric()
        {
            animals=Array.Empty<T>();
        }

        public void Add(T item)
        {
            Array.Resize(ref animals, animals.Length+1);
            animals[^1] = item;
        }

        public T GetAnimal(int index)
        {
            return animals[index];  
        }
    }
}
