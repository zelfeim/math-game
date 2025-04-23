using Game.Operation.Interfaces;
using UnityEngine;

namespace Game.Operation
{
    public class Operation : IOperation
    {
        public Operation(BinaryTree.BinaryTree binaryTree)
        {
            BinaryTree = binaryTree;
        }

        public BinaryTree.BinaryTree BinaryTree { get; }

        public double Evaluate(double lhs)
        {
            return lhs + BinaryTree.Evaluate();
        }
    }
}