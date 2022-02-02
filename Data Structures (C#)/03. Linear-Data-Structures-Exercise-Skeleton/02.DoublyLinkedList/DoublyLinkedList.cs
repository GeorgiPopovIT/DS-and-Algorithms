namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;


        public int Count { get; private set; }



        public void AddFirst(T item)
        {
            var newNode = new Node<T>()
            {
                Item = item
            };

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var firstNode = this.head;
                firstNode.Previous = newNode;

                this.head = newNode;
                this.head.Next = firstNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>()
            {
                Item = item,
                Next = null
            };

            if (this.head is null)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                newNode.Previous = this.tail;
                this.tail = this.tail.Next;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return this.head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            var removedNode = this.head;

            this.head = removedNode.Next;

            this.Count--;

            return removedNode.Item;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            var removedNode = this.tail;

            //this.tail = removedNode.Previous;

            if (this.Count == 1)
            {
                this.tail = this.head = null;

            }
            else
            {
                this.tail = removedNode.Previous;

                this.tail.Next = null;

            }
            

            this.Count--;

            return removedNode.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}