using Game.Operation.BinaryTree.Enums;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operations
{
    public class SubtractionNode : OperationNode
    {
        public SubtractionNode(INode leftNode, INode rightNode) : base(leftNode, rightNode, OperationType.Subtraction)
        {
        }

        public override double Evaluate()
        {
            return LeftNode.Evaluate() - RightNode.Evaluate();
        }
    }
}