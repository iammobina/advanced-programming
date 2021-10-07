﻿using System;
using System.IO;

namespace OOCalculator
{
    public class SqrtOperator : UnaryOperator
    {
        public SqrtOperator(TextReader reader)
            :base(reader)
        {    }

        public override string OperatorSymbol => "Sqrt";

        public override double Evaluate() => Math.Sqrt(this.Operand.Evaluate());
    }
}