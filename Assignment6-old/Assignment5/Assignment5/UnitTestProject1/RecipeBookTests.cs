using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System.Runtime.Remoting.Messaging;

namespace UnitTestProject1
{
    [TestClass]
    public class RecipeBookTests
    {
            RecipeBook testRecipeBook = new RecipeBook("Recipe book", 2);
            Ingredient testIngrediant = new Ingredient("felfel", "tond", 4, "g");
            Recipe testRecipe = new Recipe("shenisel", "khoshmaze", 1, 4, "kahnegi", new string[] { "sheni"});

            [TestMethod()]
            public void AddTest()
            {
                Assert.IsTrue(testRecipeBook.Add(testRecipe));
            }

        [TestMethod()]
        public void SaveTest()
        {
            testRecipeBook.Add(testRecipe);
            testRecipe.AddIngredient(testIngrediant);
            testRecipeBook.Save(@"recipe.txt");
            using (System.IO.StreamReader reading = new System.IO.StreamReader(@"recipe.txt"))
            {
                Assert.IsNotNull(Recipe.Deserialize(reading));
            }
        }

        [TestMethod()]
        public void LoadTest()
        {
            testRecipe.AddIngredient(testIngrediant);
            testRecipeBook.Add(testRecipe);
            testRecipeBook.Save(@"recipe.txt");
            Assert.IsTrue(testRecipeBook.Load(@"recipe.txt"));
        }
    
}
    }
