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
            return LeftNode.Evaluate() / RightNode.Evaluate();
        }
    }
}