using System;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operators
{
    public abstract class OperatorNode : NodeAbstract
    {
        private readonly OperatorType _type;

        protected OperatorNode(INode childNode, OperatorType operatorType)
        {
            ChildNode = childNode ?? throw new ArgumentNullException(nameof(childNode));
            _type = operatorType;
        }

        protected INode ChildNode { get; }

        public abstract override double Evaluate();

        public sealed override string ToString()
        {
            return _type switch
            {
                OperatorType.Exponentiation => $@"({ChildNode})^2",
                OperatorType.Root => $@"√({ChildNode})",
                OperatorType.Logarithm => $@"log2({ChildNode})",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}