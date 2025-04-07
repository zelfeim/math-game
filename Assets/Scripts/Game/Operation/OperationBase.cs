using System;
using Game.Operation.Interfaces;
using UnityEngine;

namespace Game.Operation
{
    public class OperationBase : IOperation
    {
        protected readonly double Rhs;
        
        protected Func<double, double> Function;

        protected OperationBase(double rhs)
        {
            Rhs = rhs;
        }

        public double Evaluate(double rhs)
        {
            return Function(rhs);
        }
    }
}