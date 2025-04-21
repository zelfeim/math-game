using Game.Operation.BinaryTree.Enums;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree.Operations
{
    public class MultiplicationNode : OperationNode
    {
        public MultiplicationNode(INode leftNode, INode rightNode) : base(leftNode, rightNode,
            OperationType.Multiplication)
        {
        }

        public override double Evaluate()
        {
            return LeftNode.Evaluate() * RightNode.Evaluate();
        }
    }
}