using Game.Operation.Interfaces;
using UnityEngine;

namespace Game.Operation
{
    public class Operation : IOperation
    {
        public Operation(int depth)
        {
            BinaryTree = new BinaryTree.BinaryTree(depth);
        }

        public BinaryTree.BinaryTree BinaryTree { get; }

        public double Evaluate(double lhs)
        {
            return lhs + BinaryTree.Evaluate();
        }
    }
}