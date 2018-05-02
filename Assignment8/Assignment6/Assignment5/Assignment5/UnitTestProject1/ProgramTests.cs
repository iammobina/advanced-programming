using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod()]
        public void FromMom()
        {
            RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 1);
            Recipe foods = new Recipe("ghorme", "khube", 1, 2, "khunegi", new List<string> { "ghorme" });
            Assert.IsFalse(fromMom.Add(foods));
        }

        [TestMethod()]
        public void ShowTest()
        {
            Recipe RecipeTest = new Recipe("shenisel", "khanegi", 1, 4, "khanegi", new List<string> { "sheni" });
            Ingredient ingredienttest = new Ingredient("Onion", "Fried", 1, "kg");
            List<Ingredient> ingredientTest = new List<Ingredient>();
            ingredientTest.Add(ingredienttest);;
            Assert.IsTrue(Program.Show(RecipeTest));
        }
    }
}