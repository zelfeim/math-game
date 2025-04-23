using System;
using Game.Operation.BinaryTree.Interfaces;
using Game.Operation.BinaryTree.Operations;
using Game.Operation.BinaryTree.Operators;
using Game.Operation.Interfaces;

namespace Game.Operation.BinaryTree
{
    public class BinaryTreeFactory
    {
        private INode CreateNode(int depth)
        {
            if (depth <= 0)
                return CreateNumberNode();

            var random = UnityEngine.Random.Range(0, 100);
            if (random < 30) return CreateNumberNode();

            var leftNode = CreateNode(depth - 1);
            var rightNode = CreateNode(depth - 1);

            return CreateRandomNode(leftNode, rightNode);
        }

        public BinaryTree CreateTree(int depth)
        {
            var rootNode = CreateNode(depth); 
            return new BinaryTree(rootNode);
        }

        private INode CreateNumberNode()
        {
            // TODO Get values configuration
            var value = UnityEngine.Random.Range(0, 101);
            return NodeFactory.CreateNumberNode(value);
        }

        private INode CreateRandomNode(INode leftNode, INode rightNode)
        {
            // Dumb logic, we retry creating a random node until it's valid
            while (true)
            {
                // TODO Get ranges from configuration
                switch (UnityEngine.Random.Range(0, 7))
                {
                    case 0:
                        return NodeFactory.CreateAdditionNode(leftNode, rightNode);
                    case 1:
                        return NodeFactory.CreateSubtractionNode(leftNode, rightNode);
                    case 2:
                        return NodeFactory.CreateMultiplicationNode(leftNode, rightNode);
                    case 3:
                        try
                        {
                            return NodeFactory.CreateDivisionNode(leftNode, rightNode);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }
                    case 4:
                        try
                        {
                            return NodeFactory.CreateExponentiationNode(leftNode);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }
                    case 5:
                        try
                        {
                            return NodeFactory.CreateSquareRootNode(leftNode);
                        }
                        catch (ArgumentException)
                        {
                           continue; 
                        }
                    case 6:
                        try
                        {
                            return NodeFactory.CreateLogarithmNode(leftNode);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}