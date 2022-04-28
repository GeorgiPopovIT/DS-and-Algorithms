namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; }

        public IAbstractBinaryTree<T> LeftChild { get; }

        public IAbstractBinaryTree<T> RightChild { get; }

        public string AsIndentedPreOrder(int indent)
        {
            var result = new StringBuilder();

            this.PreOrderDfs(result, indent, this);

            return result.ToString();
        }



        public void ForEachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.InOrder());
            }
            result.Add(this);

            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.InOrder());
            }

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.PostOrder());
            }
            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.PostOrder());
            }

            result.Add(this);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            result.Add(this);

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.PreOrder());
            }

            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.PreOrder());
            }

            return result;
        }

        private void PreOrderDfs(StringBuilder result, int indent, IAbstractBinaryTree<T> binaryTree)
        {
            result
                .Append(new string(' ', indent))
                .AppendLine(binaryTree.Value.ToString());

            if (binaryTree.LeftChild != null)
            {
                this.PreOrderDfs(result, indent + 2, this.LeftChild);
            }

            if (binaryTree.RightChild != null)
            {
                this.PreOrderDfs(result, indent + 2, this.RightChild);
            }
        }
    }
}
