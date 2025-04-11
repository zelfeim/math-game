namespace Game.Operation
{
    public class DivisionOperation : OperationBase
    {
        public DivisionOperation(double rhs) : base(rhs)
        {
            Function = Division;
        }
        
        private double Division(double lhs)
        {
            return lhs / Rhs;
        }
    }
}