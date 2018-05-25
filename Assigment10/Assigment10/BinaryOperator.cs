using System;
using System.IO;

namespace OOCalculator
{
    public abstract class BinaryOperator: Expression, IOperator
    {
        protected Expression LHS;
        protected Expression RHS;

        public BinaryOperator(TextReader reader)
        {
            LHS = Expression.GetNextExpression(reader);
            RHS = Expression.GetNextExpression(reader);

        }

        public abstract string OperatorSymbol { get; }

        public sealed override string ToString() => $"({this.LHS.ToString()} {this.OperatorSymbol} {this.RHS.ToString()})";

    }
}