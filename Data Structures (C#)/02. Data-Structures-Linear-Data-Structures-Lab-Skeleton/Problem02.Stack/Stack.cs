namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = this._top;

            while (currentNode != null)
            {
                if(currentNode.Value.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public T Peek()
        {
            this.IsEmptyStack();

            var topNodeValue = this._top.Value;

            return topNodeValue;
        }

        public T Pop()
        {
            this.IsEmptyStack();

            var topNodeValue = this._top.Value;

            var newTopNode = this._top.Next;

            this._top.Next = null;

            this._top = newTopNode;

            this.Count--;

            return topNodeValue;
        }

        public void Push(T item)
        {
            var nodeToAdd = new Node<T>
            {
                Value = item,
                Next = this._top
            };

            this._top = nodeToAdd;

            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this._top;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void IsEmptyStack()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(nameof(Count));
            }
        }
    }
}