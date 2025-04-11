namespace Game.Operation
{
    public class MultiplicationOperation : OperationBase
    {
        public MultiplicationOperation(double rhs) : base(rhs)
        {
            Function = Multiplicate;
        }

        private double Multiplicate(double lhs)
        {
            return lhs * Rhs;
        }
    }
}