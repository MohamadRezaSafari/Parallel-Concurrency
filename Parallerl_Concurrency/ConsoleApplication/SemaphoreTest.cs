

using System.Threading;

namespace ConsoleApplication
{
    public class Test2
    {
        public static Semaphore semaphore = new Semaphore(1, 1);

        public static void Main()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread threadObject = new Thread(DoSomeTask)
                {
                    Name = "Thread " + i
                };
                threadObject.Start(i);
            }
            Console.ReadKey();
        }

        static void DoSomeTask(object id)
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter into Critical Section for processing");
            try
            {
                //Blocks the current thread until the current WaitHandle receives a signal.   
                semaphore.WaitOne();
                Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Doing its work");
                Thread.Sleep(5000);
                Console.WriteLine(Thread.CurrentThread.Name + "Exit.");
            }
            finally
            {
                //Release() method to releage semaphore  
                semaphore.Release();
            }
        }
    }

    class Demo
    {
        static Thread[] t = new Thread[5];
        static Semaphore semaphore = new Semaphore(1, 1);
        static void DoSomething()
        {
            Console.WriteLine("{0} = waiting", Thread.CurrentThread.Name);

            semaphore.WaitOne();

            Console.WriteLine("{0} begins!", Thread.CurrentThread.Name);
            Thread.Sleep(1000);
            Console.WriteLine("{0} releasing...", Thread.CurrentThread.Name);

            semaphore.Release();
        }

        public static void Main()
        {
            for (int j = 0; j < 5; j++)
            {
                t[j] = new Thread(DoSomething);
                t[j].Name = "thread number " + j;
                t[j].Start();
            }
            Console.Read();
        }
    }

    public class SemaphoreTest
    {
        public static void Printer()
        {
            Semaphore semaphore = new Semaphore(1, 1);


            for (int i = 0; i < 20; i++)
            {
                int j = i;

                
                    //var x = new X();
                    //x.Print(j);
                

                Task.Factory.StartNew(() =>
                {
                    semaphore.WaitOne();
                    //var x = new X();
                    //x.Print(j);
                    semaphore.Release();
                });
            }
        }

        //private void Print(int valueToPrint)
        //{
        //    Console.WriteLine(valueToPrint);
        //    Thread.Sleep(TimeSpan.FromSeconds(5));
        //}
    }
}