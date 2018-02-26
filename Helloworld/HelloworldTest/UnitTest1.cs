using Helloworld;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using HelloWorld;
using System;

namespace HelloworldTest
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void issortedTest()
        {
            int[] gradesAsc = new int[] { 1, 2, 5, 6, 10 };
            int[] gradesDesc = new int[] { 9, 5, 2, 1 };
            int[] gradesNeg = new int[] { 9, 5, 15, 1 };

            Assert.IsTrue(Program.issorted(gradesAsc, true));
            Assert.IsTrue(Program.issorted(gradesDesc, false));
            Assert.IsFalse(Program.issorted(gradesNeg, true));

        }

        [TestMethod()]
        public void issortedTest1()
        {
            int[] gradesAsc = new int[] { 1, 2, 5, 6, 10 };
            int[] gradesDesc = new int[] { 9, 5, 2, 1 };
            int[] gradesNeg = new int[] { 9, 5, 15, 1 };

            Assert.IsTrue(Program.issorted(gradesAsc, true));
            Assert.IsTrue(Program.issorted(gradesDesc, false));
            Assert.IsFalse(Program.issorted(gradesNeg, true));
        }
        
    }
}