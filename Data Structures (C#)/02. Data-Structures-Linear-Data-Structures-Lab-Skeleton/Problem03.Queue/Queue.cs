namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = this._head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.IsEmptyQueue();


            var topNodeValue = this._head.Value;

            var newTopNode = this._head.Next;

            this._head.Next = null;

            this._head = newTopNode;

            this.Count--;

            return topNodeValue;

        }

        public void Enqueue(T item)
        {
            if (this._head == null)
            {
                this._head = new Node<T>()
                {
                    Value = item,
                    Next = null
                };
            }
            else
            {
                Node<T> toAdd = new Node<T>()
                {
                    Value = item
                };

                Node<T> current = this._head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = toAdd;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.IsEmptyQueue();

            var topNodeValue = this._head.Value;

            return topNodeValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.Count > 0)
            {
                yield return this.Dequeue();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void IsEmptyQueue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(nameof(Count));
            }
        }
    }
}