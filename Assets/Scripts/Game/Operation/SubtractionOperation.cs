namespace Game.Operation
{
    public class SubtractionOperation : OperationBase
    {
        public SubtractionOperation(double rhs) : base(rhs)
        {
            Function = Subtraction;
        }

        private double Subtraction(double lhs)
        {
            return lhs - Rhs;
        }
    }
}