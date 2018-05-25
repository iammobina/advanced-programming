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
    public class MultiplyOperatorTests
    {
        [TestMethod()]
        public void MultiplyOperatorTest()
       {
            string fileName = "MultiplyTest";
            File.WriteAllText(fileName, "4\n4");
            MultiplyOperator n = new MultiplyOperator(File.OpenText(fileName));
            Assert.AreEqual(n.ToString(), "(4 * 4)");
            Assert.AreEqual(n.Evaluate(), 16);
        }

    }
}