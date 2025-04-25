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
        private double? _rhsValue;

        public double Evaluate(double lhs)
        {
            _rhsValue ??= BinaryTree.Evaluate();
            
            return lhs + _rhsValue.Value;
        }
    }
}