using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOCalculator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCalculator.Tests
{
    [TestClass()]
    public class ExpressionTests
    {
        [TestMethod()]
        public void EvaluateTest()
        {
            string fileName = "Test";
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.Write("Multiply\nNegate\n5\nAdd\n3\nDivide\n2\nAdd\n1\nSquare\n4");
                
             }
            using (StreamReader reader = new StreamReader(fileName))
            {
                Expression e = Expression.BuildExpressionTree(reader);
               
                Assert.AreEqual(e.ToString(), "(-(5) * (3 + (2 / (1 + Square(4)))))");
                Assert.AreEqual((int)e.Evaluate(), -15);
            }
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.Write("Subtract\nSquareRoot\n4\n1");

            }
            using (StreamReader reader = new StreamReader(fileName))
            {
                Expression e = Expression.BuildExpressionTree(reader);

                Assert.AreEqual(e.ToString(), "(Sqrt(4) - 1)");
                Assert.AreEqual((int)e.Evaluate(), 1);
            }

        }
    }
}