using System;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operators
{
    public class ExponentiationNode : OperatorNode
    {
        public ExponentiationNode(INode childNode) : base(childNode, OperatorType.Exponentiation)
        {
        }

        public override double Evaluate()
        {
            return Math.Pow(ChildNode.Evaluate(), 2);
        }
    }
}