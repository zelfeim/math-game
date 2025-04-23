using System;
using Game.Operation.BinaryTree.Interfaces;
using Game.Operation.BinaryTree.Operations;
using Game.Operation.BinaryTree.Operators;

namespace Game.Operation.BinaryTree
{
    public static class NodeFactory
    {
        private const double Epsilon = 1e-10;

        public static INode CreateAdditionNode(INode leftNode, INode rightNode)
        {
            return new AdditionNode(leftNode, rightNode);
        }

        public static INode CreateSubtractionNode(INode leftNode, INode rightNode)
        {
            return new SubtractionNode(leftNode, rightNode);
        }

        public static INode CreateMultiplicationNode(INode leftNode, INode rightNode)
        {
            return new MultiplicationNode(leftNode, rightNode);
        }

        public static INode CreateDivisionNode(INode leftNode, INode rightNode)
        {
            if (rightNode.Evaluate() < Epsilon)
            {
               throw new ArgumentException("Right node (denominator) cannot be a constant zero.", nameof(rightNode));
            }
            
            return new DivisionNode(leftNode, rightNode);
        }

        public static INode CreateExponentiationNode(INode childNode)
        {
            return new ExponentiationNode(childNode);
        }

        public static INode CreateLogarithmNode(INode childNode)
        {
             if (childNode.Evaluate() < 0)
             {
                 throw new ArgumentException("Logarithm argument must be positive.", nameof(childNode));
             }

             return new LogarithmNode(childNode);
        }

        public static INode CreateSquareRootNode(INode childNode)
        {
            if (childNode.Evaluate() < 0)
            {
                throw new ArgumentException("Square root argument cannot be negative.", nameof(childNode));
            }
            
            return new SquareRootNode(childNode);
        }

        public static INode CreateNumberNode(double value)
        {
            return new NumberNode(value);
        }
    }
}