namespace Game.Operation.Interfaces
{
    public interface IOperation
    {
        public BinaryTree.BinaryTree BinaryTree { get; }
        public double Evaluate(double rhs);
    }
}