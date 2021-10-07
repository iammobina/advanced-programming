using System;
using System.IO;

namespace OOCalculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        protected Expression Operand;

        public UnaryOperator(TextReader reader)
        {
            this.Operand = Expression.GetNextExpression(reader);
        }

       public sealed override string ToString() => $"{this.OperatorSymbol}({this.Operand.ToString()})";

        public abstract string OperatorSymbol { get; }
    }
}