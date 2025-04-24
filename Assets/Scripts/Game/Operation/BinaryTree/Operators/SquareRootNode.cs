using System;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operators
{
    public class SquareRootNode : OperatorNode
    {
        public SquareRootNode(INode childNode) : base(childNode, OperationType.Root)
        {
            
        }
        
        public override double Evaluate()
        {
            var value = ChildNode.Evaluate();
            if (value < 0) throw new Exception("Square root of negative number");
            
            return Math.Sqrt(value);
        }
    }
}