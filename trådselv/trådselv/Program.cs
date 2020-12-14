using System;
using System.Threading;

namespace trådselv
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPoolDemo tpd = new ThreadPoolDemo();
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task1));
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task2));
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task3));
            Console.ReadLine();
        }

    }
    class ThreadPoolDemo
    {
        int i = 0;
        public void task1(object obj)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            while (Thread.CurrentThread.IsAlive)//running while alive
            {

                if (i > 20)
                {
                    return;
                }
                Console.WriteLine("we are living baby");
                Thread.Sleep(2);
            }

        }
        public void task2(object obj)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;

            while (Thread.CurrentThread.IsAlive)//running while alive
            {
                if (Thread.CurrentThread.IsBackground)// just keeps running in background
                {
                    i++;
                    Console.WriteLine("Im still running just so you know");
                }
                if (i == 30)
                {
                    return;
                }
            }



        }

        public void task3(object obj)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest; // high priority thread
            while (i < 10)
            {
                Console.WriteLine("im high priority");

            }

        }

    }
}
