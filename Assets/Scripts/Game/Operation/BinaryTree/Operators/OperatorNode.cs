using System;
using Game.Misc;
using Game.Operation.BinaryTree.Interfaces;
using Game.Operation.BinaryTree.Operations;

namespace Game.Operation.BinaryTree.Operators
{
    public abstract class OperatorNode : NodeAbstract
    {
        private readonly OperationType _type;

        protected OperatorNode(INode childNode, OperationType operatorType)
        {
            ChildNode = childNode ?? throw new ArgumentNullException(nameof(childNode));
            _type = operatorType;
        }

        protected INode ChildNode { get; }

        public abstract override double Evaluate();

        public sealed override string ToString()
        {
            // TODO Get from main menu selection, just like difficulty
            if (SettingsManager.CurrentNotation == Notation.Infix)
            {
                return _type switch
                {
                    OperationType.Exponentiation => $"({ChildNode})^2",
                    OperationType.Root => $@"√({ChildNode})",
                    OperationType.Logarithm => $"log2({ChildNode})",
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            if (SettingsManager.CurrentNotation == Notation.Postfix)
            {
                return _type switch
                {
                    OperationType.Exponentiation => $"{ChildNode} ^2",
                    OperationType.Root => $"{ChildNode} sqrt",
                    OperationType.Logarithm => $"{ChildNode} log",
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}