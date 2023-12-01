using System;

namespace DataStructures
{
    public class BinaryTree<T> : IBinaryTree<T>
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
                int comparisonResult = Comparer<T>.Default.Compare(value, node.value);

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

        private int CompareValues(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0; 
            }

            if (x == null)
            {
                return -1; 
            }

            if (y == null)
            {
                return 1; 
            }

            int intX = (int)x;
            int intY = (int)y;

            if (intX < intY)
            {
                return -1;
            }
            else if (intX > intY)
            {
                return 1;
            }
            else
            {
                return 0;
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
                int comparisonResult = Comparer<T>.Default.Compare(value, node.value);

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