namespace BB205_Delegate
{


    //internal delegate bool CheckNum(int item);
    //internal delegate void PrintString<in T>(T str);
    internal class Program
    {
        static void Main(string[] args)
        {

            //int[] arr = {1,2,3,4, 5, 6, 7};

            //////int result=Sum(arr,CheckPositive);
            //////Console.WriteLine(result);


            //////Capitalize(word);

            //////print(word);
            //////print += PrintToUpper;
            //////print += Capitalize;
            //////print -= PrintToLower;
            ////string word = "saLAm";
            //////PrintString print= delegate (string item)
            //////{
            //////    Console.WriteLine(item[0]);
            //////};
            //////print += PrintToUpper;

            ////PrintString<string> print = PrintToLower;


            ////print += (item) => Console.WriteLine(item);


            ////CheckNum check=n=>n % 3 == 0;

            //Action<string> str = PrintToLower;
            //int result=Sum(arr, n => n  > 0);


            
            //Console.WriteLine(result);



            List<string> list = new List<string>();

            list.Add("salam");
            list.Add("Hello");
            list.Add("BB205");

            //list.ForEach(s => Console.WriteLine(s));

            list.FindAll(s => s.Contains("l")).ForEach(s => Console.WriteLine(s));

        }

        public static void PrintToLower(string word)
        {
            Console.WriteLine(word.ToLower());
        }
        public static void PrintToUpper(string word)
        {
            Console.WriteLine(word.ToUpper());
        }
        public static void Capitalize(string word)
        {
            Console.WriteLine(Char.ToUpper(word[0])+word.Substring(1).ToLower());
        }






























        public static int Sum(int[] arr,Func<int,bool> a)
        {
            
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (a(arr[i]))
                {
                    sum += arr[i];
                }
            }
            return sum;
        }



       






       public  static bool CheckPositive(int num)
        {
            return num > 0;
        }
        public static bool CheckOdd(int number)
        {
            return number % 2 != 0;
        }
        public static bool CheckEven(int number)
        {
            return number % 2 == 0;
        }

    }
}