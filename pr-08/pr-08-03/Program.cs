using System;
using System.Threading;

namespace pr_08_03
{
    class Program
    {
        static void ShowMyText(object state)
        {
            string text = (string)state;
            Console.WriteLine("Thread: {0} - {1}", Thread.CurrentThread.ManagedThreadId, text);
        }
        static void Main(string[] args)
        {
            var callback = new WaitCallback(ShowMyText);
            ThreadPool.QueueUserWorkItem(callback, "Hello");
            ThreadPool.QueueUserWorkItem(callback, "Hi");
            ThreadPool.QueueUserWorkItem(callback, "Heya");
            ThreadPool.QueueUserWorkItem(callback, "Goodbye");
            Console.Read();
        }
    }
}