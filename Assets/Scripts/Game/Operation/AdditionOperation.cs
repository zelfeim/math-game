using Unity.Mathematics;
using Unity.VisualScripting;

namespace Game.Operation
{
    public class AdditionOperation : OperationBase
    {
        public AdditionOperation(double rhs) : base(rhs)
        {
            Function = Addition;
        }

        private double Addition(double lhs)
        {
            return lhs + Rhs;
        }
    }
}