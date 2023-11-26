using System;

namespace DataStructures
{
    public class BinaryTree
    {
        private class TreeNode
        {
            public readonly object value;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(object value)
            {
                value = value;
                left = null;
                right = null;
            }
        }

        private TreeNode root;
        private int nodeCount;

        public int Count
        {
            get { return nodeCount; }
        }

        public void Add(object value)
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

        private void AddTo(TreeNode node, object value)
        {
            while (node != null)
            {
                if (CompareValues(value, node.value) < 0)
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
                else if (CompareValues(value, node.value) > 0)
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

        public bool Contains(object value)
        {
            return ContainsRecursive(root, value);
        }

        private bool ContainsRecursive(TreeNode node, object value)
        {
            while (node != null)
            {
                if (CompareValues(value, node.value) == 0)
                {
                    return true;
                }
                else if (CompareValues(value, node.value) < 0)
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

        public object[] ToArray()
        {
            object[] result = new object[nodeCount];
            int index = 0;
            ToArrayRecursive(root, result, index);
            return result;
        }

        private int ToArrayRecursive(TreeNode node, object[] result, int index)
        {
            if (node != null)
            {
                index = ToArrayRecursive(node.left, result, index);
                result[index++] = node.value;
                index = ToArrayRecursive(node.right, result, index);
            }

            return index;
        }
    }
}