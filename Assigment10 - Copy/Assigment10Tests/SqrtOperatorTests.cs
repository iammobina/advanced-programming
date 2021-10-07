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
    public class SqrtOperatorTests
    {
        [TestMethod()]
        public void SqrtOperatorTest()
        {
            string fileName = "SqrtTest";
            File.WriteAllText(fileName, "3");
            SqrtOperator n = new SqrtOperator(File.OpenText(fileName));
            Assert.AreEqual(n.ToString(), "Sqrt(3)");
            Assert.AreEqual(n.Evaluate(), Math.Sqrt(3));

        }


    }
}