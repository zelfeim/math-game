using System;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operations
{
    public abstract class OperationNode : NodeAbstract
    {
        private readonly OperationType _type;

        protected OperationNode(INode leftNode, INode rightNode, OperationType operationType)
        {
            LeftNode = leftNode ?? throw new ArgumentNullException(nameof(leftNode));
            RightNode = rightNode ?? throw new ArgumentNullException(nameof(rightNode));
            _type = operationType;
        }

        protected INode LeftNode { get; }
        protected INode RightNode { get; }

        public abstract override double Evaluate();

        public sealed override string ToString()
        {
            return _type switch
            {
                OperationType.Addition => $"({LeftNode} + {RightNode})",
                OperationType.Subtraction => $"({LeftNode} - {RightNode})",
                OperationType.Multiplication => $@"({LeftNode} * {RightNode})",
                OperationType.Division => $@"({LeftNode} / {RightNode})",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}