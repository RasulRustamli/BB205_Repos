namespace bb205_method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] arr1 = { 2, 3, 4, 5 };
            //Sum(1,2,3,4,5);
        }
        #region Method Intro
        //public static void Print()
        //{
        //    ReturnString("salam");
        //    Console.WriteLine("Hello World");
        //}
        //public static int ReturnString(string word)
        //{
        //    int count = 0;
        //    for (int i = 0; i < word.Length; i++)
        //    {
        //        count++;
        //    }
        //    Print();
        //    return count;
        //}
        #endregion

        #region Methods

        //public static void Sum(int num1,int num2)
        //{
        //    Console.WriteLine(num1+num2);
        //}
        ////array yolamaq 1 ci usul
        //public static void  SumArray(int[] arr)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        sum+=arr[i];
        //    }
        //    Console.WriteLine(sum);
        //}
        ////2 -ci usul
        public static int SumArrayParams( int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

            }



            return sum;

        }
        #endregion


        #region Method Overloading


        public static void Sum(params int[] arr)
        {
            Console.WriteLine("array olan method");
        }
        public static void Sum(int num1, int num2)
        {
            Console.WriteLine("integer olan method");
        }
        public static double Sum(double num1, int num2)
        {
            return num1 + num2;
        }
        public static int Sum(int num1, int num2, int num3)
        {
            return (num1 + num2) + num3;
        }
        public static int Sum(int num1, int num2, int num3, int num4)
        {
            return (num1 + num2) + num3 + num4;
        }

        #endregion

        #region Default
        public static void MultiNum(int a,int b,int c)
        {
            
            Console.WriteLine(a*b*c);
        }



        #endregion
    }

}