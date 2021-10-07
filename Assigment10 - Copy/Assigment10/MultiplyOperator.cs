using System;
using System.IO;

namespace OOCalculator
{
    public class MultiplyOperator : BinaryOperator
    {
        public MultiplyOperator(TextReader reader)
            : base(reader)
        {  }

        public override string OperatorSymbol => "*";

        public override double Evaluate() => this.LHS.Evaluate() * this.RHS.Evaluate();
    }
}