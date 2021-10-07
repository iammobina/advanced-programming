using System;
using System.IO;

namespace OOCalculator
{
    public class NumberExpression : Expression
    {
        protected double Number;

        public NumberExpression(string line)
        {
            this.Number = double.Parse(line);
        }

        public override double Evaluate() => this.Number;

        public override string ToString() => this.Number.ToString();
    }
}