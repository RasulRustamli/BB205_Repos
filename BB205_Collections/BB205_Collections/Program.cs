using System.Collections;

namespace BB205_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ArrayList
            //ArrayList arrayList = new ArrayList();

            //arrayList.Add("Hello");
            //arrayList.Add("Hello1");
            //arrayList.Add("Hello2");
            //arrayList.Add("Hello3");
            //arrayList.Add("Hello4");
            //arrayList.Add("Hello5");
            //arrayList.Add("Hello6");
            //arrayList.Add("Hello7");
            //arrayList.Add("Hello8");



            //foreach (var i in arrayList)
            //{
            //    Console.WriteLine(i);
            //}
            ////arrayList.Sort();
            //Console.WriteLine("-------------------");


            ////Console.WriteLine(arrayList.Capacity);

            ////Console.WriteLine(arrayList.Count);
            //arrayList.RemoveRange(3,1);
            //foreach (var i in arrayList)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion

            #region Queue

            //Queue queue = new Queue();
            //queue.Enqueue("salam");
            //queue.Enqueue(1);
            //queue.Enqueue("Hello");
            //queue.Enqueue(1.5);

            //foreach (var item in queue)
            //{
            //    Console.WriteLine(item);
            //}
            //queue.Dequeue();

            //Console.WriteLine("------------------");
            //foreach (var item in queue)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("sirada olan " +queue.Peek());
            //Console.WriteLine(queue.Peek());

            #endregion
            #region Stack

            //Stack stack = new Stack();
            //stack.Push("salam");
            //stack.Push("sagol");
            //stack.Push(3);

            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("siradaki object " +stack.Peek());
            //stack.Pop();
            //Console.WriteLine("siradaki object " + stack.Peek());


            #endregion

            #region HashTable
            //Hashtable ht = new Hashtable();
            //ht.Add("sagol", "hello");

            //ht.Add(1, "world");
            //ht.Add("hello", "world");
            //foreach (var key in ht.Values)
            //{
            //    Console.WriteLine(key);
            //}


            #endregion

            #region SortedList

            SortedList sortedList = new SortedList();

            sortedList.Add(2, "salam");
            sortedList.Add(1, 3);
            sortedList.Add(3, 12);

            foreach (var i in sortedList.Values)
            {
                Console.WriteLine(i);
            }
            #endregion
        }
    }
}