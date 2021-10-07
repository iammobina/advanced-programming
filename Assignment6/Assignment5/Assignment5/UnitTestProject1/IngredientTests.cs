using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class IngredientTests
    {
        
        Ingredient IngrediantTest = new Ingredient("namak", "shoor", 3, "g");
        Recipe RecipeTest = new Recipe("shenisel", "khanegi", 1, 4, "khanegi", new List<string> { "sheni" });
        RecipeBook RecipeBookTest = new RecipeBook("Recipe book", 2);

        [TestMethod()]
        public void IngredientTest()
        {
            Assert.AreEqual(IngrediantTest.Name, "namak");
            Assert.AreSame(IngrediantTest.Description, "shoor");
            Assert.AreNotEqual(IngrediantTest.Quantity, 4);
            Assert.AreNotSame(IngrediantTest.Description, "kg");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(IngrediantTest.ToString(), "Name:{Name} Description:{Description} Quantity:{Quantity} Unit:{Unit}");
        }


        [TestMethod()]
        public void DeserializeTest()
        {
            RecipeBookTest.recipe.Add(RecipeTest);
            RecipeTest.ingredientlist.Add(IngrediantTest);
            RecipeBookTest.Save(@"recipe.txt");
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"recipe.txt"))
            {
                Assert.IsNotNull(Recipe.Deserialize(reader));
                Assert.IsNotNull(Ingredient.Deserialize(reader));
            }
        }
    }
}