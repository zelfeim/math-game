using System;
using Game.Operation.BinaryTree.Interfaces;
using Game.Operation.BinaryTree.Operations;

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
            // TODO Get from main menu selection, just like difficulty
            var notationType = NotationType.Postfix;

            if (notationType == NotationType.Infix)
            {
                return _type switch
                {
                    OperatorType.Exponentiation => $"({ChildNode})^2",
                    OperatorType.Root => $@"√({ChildNode})",
                    OperatorType.Logarithm => $"log2({ChildNode})",
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            if (notationType == NotationType.Postfix)
            {
                return _type switch
                {
                    OperatorType.Exponentiation => $"{ChildNode} ^2",
                    OperatorType.Root => $"{ChildNode} sqrt",
                    OperatorType.Logarithm => $"{ChildNode} log",
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}