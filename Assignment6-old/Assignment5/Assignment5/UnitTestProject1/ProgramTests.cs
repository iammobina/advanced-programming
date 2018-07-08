using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;

namespace UnitTestProject1
{
    [TestClass]
    public class ProgramTests
    {

        public void Addtest()
        {
            RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 1);
            Recipe foods = new Recipe("ghorme", "khube", 1, 2, "khunegi", new string[] { "ghorme", "sabzi" });
            Assert.IsTrue(fromMom.Add(foods));

        }
    }
}
