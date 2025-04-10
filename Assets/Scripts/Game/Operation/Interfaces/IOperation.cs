namespace Game.Operation.Interfaces
{
    public interface IOperation
    {
        double Rhs { get; }
        public double Evaluate(double rhs);
    }
}