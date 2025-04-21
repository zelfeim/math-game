using Game.Operation.BinaryTree.Enums;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operations
{
    public class AdditionNode : OperationNode
    {
        public AdditionNode(INode leftNode, INode rightNode) : base(leftNode, rightNode, OperationType.Addition)
        {
        }

        public override double Evaluate()
        {
            return LeftNode.Evaluate() + RightNode.Evaluate();
        }
    }
}