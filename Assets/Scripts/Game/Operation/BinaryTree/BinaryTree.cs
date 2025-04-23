using System;
using Game.Operation.BinaryTree.Interfaces;
using UnityEngine;

namespace Game.Operation.BinaryTree
{
    public class BinaryTree
    {
        public BinaryTree(INode rootNode)
        {
            RootNode = rootNode;
        }

        private INode RootNode { get; }

        public double Evaluate()
        {
            try
            {
                return RootNode.Evaluate();
            }
            catch (Exception e)
            {
                // It SHOULD not happen, TODO some way to handle such cases
                Debug.Log(e);
                return 0;
            }
        }

        public override string ToString()
        {
            return RootNode.ToString();
        }
    }
}