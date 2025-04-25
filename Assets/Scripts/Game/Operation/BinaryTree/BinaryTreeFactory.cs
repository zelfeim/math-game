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

        private const int AdditionWeight = 25;
        private const int SubtractionWeight = 25;
        private const int MultiplicationWeight = 15;
        private const int DivisionWeight = 15;
        private const int ExponentiationWeight = 10;
        private const int SquareRootWeight = 5;
        private const int LogarithmWeight = 5;

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

        /// <summary>
        ///     Create a random node based on weights.
        /// </summary>
        /// <param name="leftNode"></param>
        /// <param name="rightNode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static INode CreateRandomNode(INode leftNode, INode rightNode)
        {
            while (true)
            {
                var chance = Random.Range(0, 101);
                var percentage = 0;

                if (chance < (percentage += AdditionWeight)) 
                    return NodeFactory.CreateAdditionNode(leftNode, rightNode);

                if (chance < (percentage += SubtractionWeight))
                    return NodeFactory.CreateSubtractionNode(leftNode, rightNode);

                if (chance < (percentage += MultiplicationWeight))
                    return NodeFactory.CreateMultiplicationNode(leftNode, rightNode);

                if (chance < (percentage += DivisionWeight))
                    try
                    {
                        return NodeFactory.CreateDivisionNode(leftNode, rightNode);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }

                if (chance < (percentage += ExponentiationWeight))
                    try
                    {
                        return NodeFactory.CreateExponentiationNode(leftNode);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }

                if (chance < (percentage += SquareRootWeight))
                    try
                    {
                        return NodeFactory.CreateSquareRootNode(leftNode);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }

                if (chance < (percentage += LogarithmWeight))
                    try
                    {
                        return NodeFactory.CreateLogarithmNode(leftNode);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }

                throw new ArgumentOutOfRangeException();
            }
        }
    }
}