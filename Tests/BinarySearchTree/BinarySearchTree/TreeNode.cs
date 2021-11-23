using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class TreeNode<T>
    {
        public TreeNode<T> Left;

        public TreeNode<T> Rigth;

        public T Data;

        public TreeNode(TreeNode<T> left, TreeNode<T> rigth, T data)
        {
            Left = left;
            Rigth = rigth;
            Data = data;
        }
    }
}
