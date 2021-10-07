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
    public class NegateOperatorTests
    {
        [TestMethod()]
        public void NegateOperatorTest()
        {
            string fileName = "NegateTest";
            File.WriteAllText(fileName, "8");
            NegateOperator n = new NegateOperator(File.OpenText(fileName));
            Assert.AreEqual(n.ToString(), "-(8)");
            Assert.AreEqual(n.Evaluate(), -8);
        }
    }
}