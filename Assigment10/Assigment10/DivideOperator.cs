using System;
using System.IO;

namespace OOCalculator
{
    public class DivideOperator : BinaryOperator
    {
        public DivideOperator(TextReader reader)
            : base(reader)
        { }


        public override string OperatorSymbol => "/";

        public override double Evaluate() => (double)this.LHS.Evaluate()/this.RHS.Evaluate();
    }
}