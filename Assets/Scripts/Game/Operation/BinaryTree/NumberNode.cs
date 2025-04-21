using System.Globalization;
using Game.Operation.BinaryTree.Interfaces;

namespace Game.Operation.BinaryTree
{
    /// <summary>
    ///     Leaf of mathematics equation binary tree
    /// </summary>
    public class NumberNode : NodeAbstract
    {
        public NumberNode(double value)
        {
            Value = value;
        }

        private double Value { get; }

        public override double Evaluate()
        {
            return Value;
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}