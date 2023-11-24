using System;

namespace DataStructures
{
    public class BinaryTree
    {
        private class TreeNode
        {
            public object Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(object value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private TreeNode Root;
        private int nodeCount;

        public void Add(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Value cannot be null");
            }

            if (Root == null)
            {
                Root = new TreeNode(value);
            }
            else
            {
                AddTo(Root, value);
            }

            nodeCount++;
        }

        private void AddTo(TreeNode node, object value)
        {
            while (node != null)
            {
                if (CompareValues(value, node.Value) < 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode(value);
                        return;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
                else if (CompareValues(value, node.Value) > 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = new TreeNode(value);
                        return;
                    }
                    else
                    {
                        node = node.Right;
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
            return ContainsRecursive(Root, value);
        }

        private bool ContainsRecursive(TreeNode node, object value)
        {
            while (node != null)
            {
                if (CompareValues(value, node.Value) == 0)
                {
                    return true;
                }
                else if (CompareValues(value, node.Value) < 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return false;
        }

        public void Clear()
        {
            Root = null;
            nodeCount = 0;
        }

        public object[] ToArray()
        {
            object[] result = new object[nodeCount];
            int index = 0;
            ToArrayRecursive(Root, result, ref index);
            return result;
        }

        private void ToArrayRecursive(TreeNode node, object[] result, ref int index)
        {
            if (node != null)
            {
                ToArrayRecursive(node.Left, result, ref index);
                result[index++] = node.Value;
                ToArrayRecursive(node.Right, result, ref index);
            }
        }

        public int Count
        {
            get { return nodeCount; }
        }
    }
}