using Problem01.FasterQueue;
using System;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var fastQueue = new FastQueue<int>();

            fastQueue.Enqueue(1);
            fastQueue.Enqueue(2);
            fastQueue.Enqueue(3);
            fastQueue.Dequeue();


            Console.WriteLine(fastQueue.Peek());
        }
    }
}
