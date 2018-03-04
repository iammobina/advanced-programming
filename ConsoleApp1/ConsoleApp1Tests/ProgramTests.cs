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
    }
}