using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void EhtemalTest()
        {
            int[] TestArray = new int[] { 1, 1, 6, 8, 9, 7, 9, 3 };

            Assert.AreEqual(Program.Ehtemal(TestArray, 1), 0.25);
        }

        [TestMethod()]
        public void EhtemaleghalatTest()
        {
            int[] TestA = new int[] { 0, 6, 6, 8, 9, 7, 9, 3 };

            Assert.AreNotEqual(Program.Ehtemal(TestA, 1), 0.25);
        }
       
        [TestMethod()]
        public void Ehtemale8adadi()
        {
            int[] TestB = new int[] { 1, 1, 1, 1, 12, 5, 6, 9 };
            Assert.AreNotEqual(Program.Ehtemal(TestB, 1), 0);
        }
    }
}