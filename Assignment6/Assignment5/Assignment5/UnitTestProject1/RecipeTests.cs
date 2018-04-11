using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;

namespace UnitTestProject1
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void AddIngredientTest()
        {
            Ingredient testIngrediant = new Ingredient("namak", "shoor", 3, "g");
            Recipe testRecipe = new Recipe("makarani", "khub", 1, 4, "khanegi", new string[] { "maka", "makaron" });
            Assert.IsTrue(testRecipe.AddIngredient(testIngrediant));
        }
    }
}
