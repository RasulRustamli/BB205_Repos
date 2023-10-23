using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB105_Custom_Generic
{
    internal class IntList
    {

        int[] items;
        public IntList()
        {
            items = Array.Empty<int>();
        }

        public void Add(int item)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
        }
        public int Count()
        {
            return items.Length;
        }

        public int FindByIndex(int index)
        {
            return items[index];
        }
    }
}
