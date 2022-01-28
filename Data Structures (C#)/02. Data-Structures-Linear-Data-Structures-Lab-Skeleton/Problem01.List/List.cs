namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            this._items = new T[capacity];
        }

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public T this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }
                return this._items[index];
            }

            set
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }
                 this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this._items.Length)
            {
                this.Grow();
            }

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
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (!this.IsValidIndex(index))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            if (this.Count == this._items.Length)
            {
                this.Grow();
            }

            
            for (int i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;

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
            if (!this.IsValidIndex(index))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            for (int i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this._items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Grow()
        {
            if (this.Count == this._items.Length)
            {
                var newArray = new T[this.Count * 2];

                for (int i = 0; i < this._items.Length; i++)
                {
                    newArray[i] = this._items[i];
                }

                this._items = newArray;

            }
        }

        private bool IsValidIndex(int index)
            => index >= 0 && index < this.Count 
            ? true
            : false;
    }
}