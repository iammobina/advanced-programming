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
    public class DivideOperatorTests
    {
        [TestMethod()]
        public void DivideOperatorTest()
        {
            string fileName = "DivideTest";
            File.WriteAllText(fileName, "72\n2");
            DivideOperator n = new DivideOperator(File.OpenText(fileName));
            Assert.AreEqual(n.ToString(), "(72 / 2)");
            Assert.AreEqual(n.Evaluate(), 36);
        }
    }
}