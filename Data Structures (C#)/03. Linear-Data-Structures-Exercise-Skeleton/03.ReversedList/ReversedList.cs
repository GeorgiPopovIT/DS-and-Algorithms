namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this._items[this.Count - index - 1];
            }
            set
            {
                ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.Grow();

            this._items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this._items.Length; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this._items.Length; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return this.Count - i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);

            this.Grow();

            for (int i = this.Count; i >= this.Count - index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[this.Count - index] = item;

            this.Count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < this._items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    for (int j = i; j < this.Count; j++)
                    {
                        this._items[j] = this._items[j + 1];
                    }

                    this.Count--;

                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items = this._items.Take(this.Count - 1).ToArray();

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this._items.Length - 1; i >= 0; i--)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (!(index >= 0 && index < this.Count))
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Grow()
        {
            if (this.Count == this._items.Length)
            {
                var newArray = new T[this.Count * 2];
                Array.Copy(this._items, newArray, this.Count);

                this._items = newArray;
            }
        }
    }
}