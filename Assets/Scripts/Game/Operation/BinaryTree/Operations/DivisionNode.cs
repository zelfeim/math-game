using System;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operations
{
    public class DivisionNode : OperationNode
    {
        public DivisionNode(INode leftNode, INode rightNode) : base(leftNode, rightNode, OperationType.Division)
        {
        }

        public override double Evaluate()
        {
            var rightNodeValue = RightNode.Evaluate(); 
            if (rightNodeValue == 0) throw new Exception("Division by zero");
            
            var leftNodeValue = LeftNode.Evaluate();
            
            return leftNodeValue / rightNodeValue;
        }
    }
}