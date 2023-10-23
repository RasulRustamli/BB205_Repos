using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB105_Custom_Generic
{
    internal class CustomGeneric<T>
    {

        T[] items;
        public CustomGeneric()
        {
            items = Array.Empty<T>();
        }

        public void Add(T item)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
        }
        public int Count()
        {
            return items.Length;
        }

        public T FindByIndex(int index)
        {
            return items[index];
        }
    }
}
