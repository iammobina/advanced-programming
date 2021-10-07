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
    public class SquareOperatorTests
    {
        [TestMethod()]
        public void SquareOperatorTest()
        {
            string fileName = "SquareTest";
            File.WriteAllText(fileName, "11");
            SquareOperator n = new SquareOperator(File.OpenText(fileName));
            Assert.AreEqual(n.ToString(), "Square(11)");
            Assert.AreEqual(n.Evaluate(), 121);

        }
    }
}