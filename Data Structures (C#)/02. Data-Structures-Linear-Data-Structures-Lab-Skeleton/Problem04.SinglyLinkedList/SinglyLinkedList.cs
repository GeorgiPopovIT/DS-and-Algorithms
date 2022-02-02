namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var nodeToAdd = new Node<T>()
            {
                Value = item,
                Next = this._head
            };


            this._head = nodeToAdd;

            this.Count++;

        }

        public void AddLast(T item)
        {

            var newNode = new Node<T>
            {
                Value = item
            };

            if (this._head is null)
                this._head = newNode;
            else
            {
                var current = this._head;

                while (current.Next != null)
                    current = current.Next;

                current.Next = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.IsEmptyLinkedList();

            return this._head.Value;
        }

        public T GetLast()
        {
            this.IsEmptyLinkedList();

            var current = this._head;
            while (current.Next != null)
                current = current.Next;

            return current.Value;
        }

        public T RemoveFirst()
        {
            this.IsEmptyLinkedList();

            var current = this._head;

            var nodeToFirst = current.Next;

            this._head = nodeToFirst;

            this.Count--;

            return current.Value;
        }

        public T RemoveLast()
        {
            this.IsEmptyLinkedList();

            if (this._head.Next is null)
                return this.RemoveFirst();

            var current = this._head;

            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            var lastItem = current.Next.Value;
            current.Next = null;
            this.Count--;

            return lastItem;

        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this._head;
            while (currentNode.Next != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void IsEmptyLinkedList()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(nameof(Count));
            }
        }
    }
}