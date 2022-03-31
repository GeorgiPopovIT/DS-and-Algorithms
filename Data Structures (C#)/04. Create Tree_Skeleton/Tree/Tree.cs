namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {

            this._children = children.ToList();
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Any())
            {
                var currNode = queue.Dequeue();
                result.Add(currNode.Value);

                foreach (var child in currNode.Children)
                {
                    queue.Enqueue(child);
                }

            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            //var result = new Stack<T>();
            //var stack = new Stack<Tree<T>>();

            //stack.Push(this);

            //while (stack.Count > 0)
            //{
            //    var node = stack.Pop();

            //    foreach (var child in node._children)
            //    {
            //        child.OrderDfs();
            //    }

            //    result.Push(node.Value);
            //}
            var result = new List<T>();

            foreach (var child in this.Children)
            {
                result.AddRange(child.OrderDfs());
            }

            result.Add(this.Value);

            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var searchedNode = this.FindByBfs(parentKey);

            CheckIsNodeEmpty(searchedNode);

            searchedNode._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = this.FindByBfs(nodeKey);

            CheckIsNodeEmpty(searchedNode);

            var parentNode = searchedNode.Parent;

            CheckIsNodeEmpty(parentNode);

            parentNode._children.Remove(searchedNode);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindByBfs(firstKey);
            var secondNode = this.FindByBfs(secondKey);

            if(firstNode is null || secondNode is null)
            {
                throw new ArgumentNullException();
            }

            var firstElementParent = firstNode.Parent;
            var secondElementParent = secondNode.Parent;

            if (firstElementParent is null || secondElementParent is null)
            {
                throw new ArgumentNullException();
            }

            var indexOfFirst = firstElementParent._children.IndexOf(firstNode);
            var indexOfSecond = secondElementParent._children.IndexOf(secondNode);

            firstElementParent._children[indexOfFirst] = secondNode;
            secondNode.Parent = firstElementParent;

            secondElementParent._children[indexOfSecond] = firstNode;
            firstNode.Parent = secondElementParent;

        }

        private Tree<T> FindByBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Any())
            {
                var currNode = queue.Dequeue();
                if (currNode.Value.Equals(parentKey))
                {
                    return currNode;
                }

                foreach (var child in currNode.Children)
                {
                    queue.Enqueue(child);
                }

            }

            return null;
        }

        private void CheckIsNodeEmpty(Tree<T> searchedNode)
        {
            if (searchedNode is null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
