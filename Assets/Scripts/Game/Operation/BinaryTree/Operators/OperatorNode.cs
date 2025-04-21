using System;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operators
{
    public abstract class OperatorNode : NodeAbstract
    {
        private readonly OperatorType _type;

        protected OperatorNode(INode childNode, OperatorType operatorType)
        {
            ChildNode = childNode;
            _type = operatorType;
        }

        protected INode ChildNode { get; }

        public abstract override double Evaluate();

        public sealed override string ToString()
        {
            return _type switch
            {
                OperatorType.Exponentiation => $@"{ChildNode}²",
                OperatorType.Root => $@"√{ChildNode}",
                OperatorType.Logarithm => $@"log₂{ChildNode}",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public enum OperatorType
    {
        Exponentiation,
        Root,
        Logarithm
    }
}