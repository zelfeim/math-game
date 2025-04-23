using System;
using Game.Operation.BinaryTree.Interfaces;
using Random = UnityEngine.Random;

namespace Game.Operation.BinaryTree
{
    public class BinaryTreeFactory
    {
        // TODO: Get from difficulty configuration
        private const float NumberChance = 0.2f;
        private const int MinValue = 0;
        private const int MaxValue = 25;
        private const int Depth = 3;

        private INode CreateNode(int depth)
        {
            if (depth <= 0 || Random.value < NumberChance)
                return CreateNumberNode();

            var leftNode = CreateNode(depth - 1);
            var rightNode = CreateNode(depth - 1);

            return CreateRandomNode(leftNode, rightNode);
        }

        public BinaryTree CreateTree()
        {
            var rootNode = CreateNode(Depth);
            return new BinaryTree(rootNode);
        }

        private INode CreateNumberNode()
        {
            var value = Random.Range(MinValue, MaxValue + 1);
            return NodeFactory.CreateNumberNode(value);
        }

        private INode CreateRandomNode(INode leftNode, INode rightNode)
        {
            // Dumb logic, we retry creating a random node until it's valid
            while (true)
                switch (Random.Range(0, 7))
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