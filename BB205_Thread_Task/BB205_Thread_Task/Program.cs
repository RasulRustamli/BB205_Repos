namespace BB205_Thread_Task
{
    internal class Program
    {
        static int count = 0;

        static object objlock = new object();
        static object objlock2 = new object();

        static async Task Main(string[] args)
        {
            //Thread thread1 = new Thread(Loop);
            //Thread thread2 = new Thread(Loop2);
            //thread1.Start();
            //thread2.Start();

            //thread1.Join();
            //thread2.Join();

            //var a=Task.Run(() =>
            //  {
            //      return "salam";
            //  }).Result;

            await GetHtmlCodeAsync();
            Console.WriteLine("salam");
            Console.ReadLine();
            
            
        }

        static async Task GetHtmlCodeAsync()
        {
            HttpClient client = new HttpClient();

           var result= await client.GetStringAsync("https://az.wikipedia.org/wiki/Ana_s%C9%99hif%C9%99");

            Console.WriteLine(result);
        }





        private static void Loop2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"2ci dongu {i}");
               
                    //lock (objlock)
                    //{
                    //    count++;
                    //}
                
                

            }

        }

        private static void Loop()
        {
            
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"1ci dongu firlanir {i}");
                //lock (objlock)
                //{
                    
                //        count--;
                    
                    
                //}

            }
        }
    }
}