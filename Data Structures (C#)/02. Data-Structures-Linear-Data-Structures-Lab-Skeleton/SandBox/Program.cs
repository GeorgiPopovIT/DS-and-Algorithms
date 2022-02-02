using System;
using Problem04.SinglyLinkedList;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new SinglyLinkedList<int>();

            myList.AddFirst(15);
            myList.AddFirst(42);
            myList.AddLast(65);

            Console.WriteLine(myList.RemoveLast());
            Console.WriteLine(myList.GetLast());
        }
    }
}
