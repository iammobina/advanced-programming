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
            Assert.AreEqual(IngrediantTest.ToString(), "name:{Name} Description:{Description} Quantity:{Quantity} Unit:{Unit}");
        }


        [TestMethod()]
        public void DeserializeTest()
        {
            RecipeBookTest.recipe.Add(RecipeTest);
            RecipeTest.ingredients.Add(IngrediantTest);
            RecipeBookTest.Save(@"recipe.txt");
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"recipe.txt"))
            {
                string title = reader.ReadLine();
                Recipe r = Recipe.Deserialize(reader, title);
                Assert.IsNotNull(r);
                Assert.AreEqual(r.ingredients[0].Name, IngrediantTest.Name);
            }
        }
    }
}