using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class RecipeTests
    {

        Recipe RecipeTest = new Recipe("shenisel", "khanegi", 1, 4, "khanegi", new List<string> { "sheni"});
        Ingredient ingredienttest = new Ingredient("Onion", "Fried", 1, "kg");
        RecipeBook RecipeBookTest = new RecipeBook("Recipe book", 2);
        List<Recipe> testRecipeList = new List<Recipe>();

        [TestMethod()]
        public void RecipeInstructionTest()
        {
            Assert.AreEqual(RecipeTest.Instructions, "khanegi");
        }

        [TestMethod()]
        public void RemoveIngredientTest()
        {
            
            RecipeTest.ingredientlist.Add(ingredienttest);
            Assert.IsFalse(RecipeTest.RemoveIngredient("Not Fried"));
            Assert.IsTrue(RecipeTest.RemoveIngredient("Onion"));
        }

    }
}