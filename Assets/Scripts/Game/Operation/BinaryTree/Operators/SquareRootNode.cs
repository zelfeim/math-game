using System;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operators
{
    public class SquareRootNode : OperatorNode
    {
        public SquareRootNode(INode childNode) : base(childNode, OperatorType.Root)
        {
            
        }
        
        public override double Evaluate()
        {
            return Math.Sqrt(ChildNode.Evaluate());
        }
    }
}