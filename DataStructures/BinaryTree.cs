using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class BinaryTree<T> : IBinaryTree<T>, IEnumerable<T> where T : IComparable<T>
    {
        private class TreeNode
        {
            public readonly T value;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(T value)
            {
                this.value = value;
                left = null;
                right = null;
            }
        }

        private TreeNode root;
        private int nodeCount;

        public int Count => nodeCount;

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal(root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> InOrderTraversal(TreeNode node)
        {
            if (node != null)
            {
                foreach (var item in InOrderTraversal(node.left))
                    yield return item;

                yield return node.value;

                foreach (var item in InOrderTraversal(node.right))
                    yield return item;
            }
        }

        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Value cannot be null");
            }

            if (root == null)
            {
                root = new TreeNode(value);
            }
            else
            {
                AddTo(root, value);
            }

            nodeCount++;
        }

        private void AddTo(TreeNode node, T value)
        {
            while (node != null)
            {
                int comparisonResult = value.CompareTo(node.value);

                if (comparisonResult < 0)
                {
                    if (node.left == null)
                    {
                        node.left = new TreeNode(value);
                        return;
                    }
                    else
                    {
                        node = node.left;
                    }
                }
                else if (comparisonResult > 0)
                {
                    if (node.right == null)
                    {
                        node.right = new TreeNode(value);
                        return;
                    }
                    else
                    {
                        node = node.right;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        public bool Contains(T value)
        {
            return ContainsRecursive(root, value);
        }

        private bool ContainsRecursive(TreeNode node, T value)
        {
            while (node != null)
            {
                int comparisonResult = value.CompareTo(node.value);

                if (comparisonResult == 0)
                {
                    return true;
                }
                else if (comparisonResult < 0)
                {
                    node = node.left;
                }
                else
                {
                    node = node.right;
                }
            }

            return false;
        }

        public void Clear()
        {
            root = null;
            nodeCount = 0;
        }

        public T[] ToArray()
        {
            T[] result = new T[nodeCount];
            int index = 0;
            ToArrayRecursive(root, result, ref index);
            return result;
        }

        private void ToArrayRecursive(TreeNode node, T[] result, ref int index)
        {
            if (node != null)
            {
                ToArrayRecursive(node.left, result, ref index);
                result[index++] = node.value;
                ToArrayRecursive(node.right, result, ref index);
            }
        }
    }
}