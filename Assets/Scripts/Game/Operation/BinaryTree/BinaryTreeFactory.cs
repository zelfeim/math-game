using System;
using Game.Difficulty;
using Game.Operation.BinaryTree.Interfaces;
using Random = UnityEngine.Random;

namespace Game.Operation.BinaryTree
{
    public class BinaryTreeFactory
    {
        private static float NumberChance => DifficultyManager.GetNumberChance();
        private static int MinValue => DifficultyManager.GetValueRange().min;
        private static int MaxValue => DifficultyManager.GetValueRange().max;
        private static int Depth => DifficultyManager.GetOperationComplexity();
        private static int AdditionWeight => DifficultyManager.GetOperation(OperationType.Addition)?.weight ?? 0;
        private static int SubtractionWeight => DifficultyManager.GetOperation(OperationType.Subtraction)?.weight ?? 0;
        private static int MultiplicationWeight => DifficultyManager.GetOperation(OperationType.Multiplication)?.weight ?? 0;
        private static int DivisionWeight => DifficultyManager.GetOperation(OperationType.Division)?.weight ?? 0;
        private static int ExponentiationWeight => DifficultyManager.GetOperation(OperationType.Exponentiation)?.weight ?? 0;
        private static int SquareRootWeight => DifficultyManager.GetOperation(OperationType.Root)?.weight ?? 0;
        private static int LogarithmWeight => DifficultyManager.GetOperation(OperationType.Logarithm)?.weight ?? 0;

        private static INode CreateNode(int depth)
        {
            if (depth <= 0 || Random.value < NumberChance)
                return CreateNumberNode();

            var leftNode = CreateNode(depth - 1);
            var rightNode = CreateNode(depth - 1);

            return CreateRandomNode(leftNode, rightNode);
        }

        public static BinaryTree CreateTree()
        {
            var rootNode = CreateNode(Depth);
            return new BinaryTree(rootNode);
        }

        private static INode CreateNumberNode()
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
            var weightSum = AdditionWeight + SubtractionWeight + MultiplicationWeight + DivisionWeight +
                            ExponentiationWeight + SquareRootWeight + LogarithmWeight;
            
            while (true)
            {
                var chance = Random.Range(0, weightSum);
                var currentPercentage = 0;

                if (chance < (currentPercentage += AdditionWeight))
                    return NodeFactory.CreateAdditionNode(leftNode, rightNode);

                if (chance < (currentPercentage += SubtractionWeight))
                    return NodeFactory.CreateSubtractionNode(leftNode, rightNode);

                if (chance < (currentPercentage += MultiplicationWeight))
                    return NodeFactory.CreateMultiplicationNode(leftNode, rightNode);

                if (chance < (currentPercentage += DivisionWeight))
                    try
                    {
                        return NodeFactory.CreateDivisionNode(leftNode, rightNode);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }

                if (chance < (currentPercentage += ExponentiationWeight))
                    try
                    {
                        return NodeFactory.CreateExponentiationNode(leftNode);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }

                if (chance < (currentPercentage += SquareRootWeight))
                    try
                    {
                        return NodeFactory.CreateSquareRootNode(leftNode);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }

                if (chance < currentPercentage + LogarithmWeight)
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