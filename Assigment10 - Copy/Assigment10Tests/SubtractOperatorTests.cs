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
    public class SubtractOperatorTests
    {
        [TestMethod()]
        public void SubtractOperatorTest()
        {
            string fileName = "SubtractTest";
            File.WriteAllText(fileName, "99\n1");
            SubtractOperator n = new SubtractOperator(File.OpenText(fileName));
            Assert.AreEqual(n.ToString(), "(99 - 1)");
            Assert.AreEqual(n.Evaluate(), 98);
        }
    }
}