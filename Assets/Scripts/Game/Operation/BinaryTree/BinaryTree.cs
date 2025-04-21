using System;
using Game.Operation.BinaryTree.Interfaces;
using Game.Operation.BinaryTree.Operations;
using Game.Operation.BinaryTree.Operators;
using Random = UnityEngine.Random;

namespace Game.Operation.BinaryTree
{
    public class BinaryTree
    {
        public BinaryTree(int depth)
        {
            RootNode = CreateRandomNode(depth);
        }

        public INode RootNode { get; }

        private static INode CreateRandomNode(int depth)
        {
            if (depth == 0)
                // TODO such random methods should be in one place, configured by difficulty
                return new NumberNode(Random.Range(0, 15));

            var random = Random.Range(0, 100);

            if (random < 70) return new NumberNode(10);

            var leftNode = CreateRandomNode(depth - 1);
            var rightNode = CreateRandomNode(depth - 1);
            
            return Random.Range(0, 3) switch
            {
                0 => new AdditionNode(leftNode, rightNode),
                1 => new SubtractionNode(leftNode, rightNode),
                2 => new MultiplicationNode(leftNode, rightNode),
                3 => new DivisionNode(leftNode, rightNode),
                4 => new ExponentiationNode(leftNode),
                5 => new SquareRootNode(leftNode),
                6 => new LogarithmNode(leftNode),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public override string ToString()
        {
            return RootNode.ToString();
        }
    }
}