namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public Node LeftChild { get; set; }

            public Node RightChild { get; set; }
        }

        private Node root;

        public BinarySearchTree(T value)
        {
            
        }

        public bool Contains(T element)
        {
            throw new NotImplementedException();
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.LeftChild);
            action.Invoke(node.Value);
            this.EachInOrder(action, node.RightChild);
            
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        private Node Insert(T value, Node node)
        {
            if (node != null)
            {
                node = new Node(value);
            }
            else if (value.CompareTo(node.Value))
            {

            }
            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            throw new NotImplementedException();
        }
    }
}
