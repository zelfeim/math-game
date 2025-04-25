using System;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operators
{
    public class LogarithmNode : OperatorNode
    {
        public LogarithmNode(INode childNode) : base(childNode, OperationType.Logarithm)
        {
        }

        public override double Evaluate()
        {
            var value = ChildNode.Evaluate();
            if (value < 0) throw new Exception("Logarithm of negative number");
            
            return Math.Log(value);
        }
    }
}