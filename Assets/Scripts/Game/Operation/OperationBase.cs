using System;
using Game.Operation.Interfaces;

namespace Game.Operation
{
    public class OperationBase : IOperation
    {
        protected Func<double, double> Function;

        protected OperationBase(double rhs)
        {
            Rhs = rhs;
        }

        protected OperationBase(double rhs, double helper)
        {
            Rhs = rhs;
            Helper = helper;
        }

        public double Helper { get; set; }
        public double Rhs { get; }

        public double Evaluate(double rhs)
        {
            return Function(rhs);
        }
    }
}