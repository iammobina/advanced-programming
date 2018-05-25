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
    public class AddOperatorTests
    {
        [TestMethod()]
        public void AddOperatorTest()
        {
            string fileName = "AddTest";
            File.WriteAllText(fileName, "45\n3");
            AddOperator n = new AddOperator(File.OpenText(fileName));
            Assert.AreEqual(n.ToString(), "(45 + 3)");
            Assert.AreEqual(n.Evaluate(), 48);
        }

    }
}