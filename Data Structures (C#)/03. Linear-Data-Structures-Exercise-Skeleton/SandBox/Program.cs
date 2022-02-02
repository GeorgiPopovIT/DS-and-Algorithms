using System;
using Problem02.DoublyLinkedList;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new DoublyLinkedList<int>();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            

            linkedList.RemoveLast();
            linkedList.RemoveLast();
            linkedList.RemoveLast();

        }
    }
}
