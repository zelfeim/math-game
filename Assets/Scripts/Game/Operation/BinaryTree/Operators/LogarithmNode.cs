using System;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operators
{
    public class LogarithmNode : OperatorNode
    {
        public LogarithmNode(INode childNode) : base(childNode, OperatorType.Logarithm)
        {
        }

        public override double Evaluate()
        {
            return Math.Log(ChildNode.Evaluate(), 2);
        }
    }
}