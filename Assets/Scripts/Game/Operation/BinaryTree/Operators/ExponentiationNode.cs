using System;
using Game.Operation.BinaryTree.Interfaces;
using Game.Operation.BinaryTree.Operations;

namespace Game.Operation.BinaryTree.Operators
{
    public class ExponentiationNode : OperatorNode
    {
        public ExponentiationNode(INode childNode) : base(childNode, OperationType.Exponentiation)
        {
        }

        public override double Evaluate()
        {
            return Math.Pow(ChildNode.Evaluate(), 2);
        }
    }
}