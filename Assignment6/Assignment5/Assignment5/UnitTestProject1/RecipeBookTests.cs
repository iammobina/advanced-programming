using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class RecipeBookTests
    {

        Ingredient IngrediantTest = new Ingredient("namak", "shoor", 3, "g");
        Recipe RecipeTest = new Recipe("shenisel", "khanegi", 1, 4, "khanegi", new List<string> { "sheni" });
        RecipeBook RecipeBookTest = new RecipeBook("Recipe book", 2);
        Recipe RecipeTest1 = new Recipe("ghromesabzi", "khunegi", 1, 4, "Irani", new List<string> { "ghorme"});
        Recipe RecipeTest2 = new Recipe("kabab", "mahitabeE", 1, 4, "Irani", new List<string> { "kabab" });

        [TestMethod()]
        public void RecipeBooksTest()
        {
            Assert.AreEqual(RecipeBookTest.Title, "Recipe book");
            Assert.AreNotEqual(RecipeBookTest.Capacity, 1);
        }

        [TestMethod()]
        public void SaveTest()
        {
            RecipeBookTest.recipe.Add(RecipeTest);
            RecipeTest.ingredientlist.Add(IngrediantTest);
            RecipeBookTest.Save(@"recipe.txt");
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"recipe.txt"))
            {
                Assert.IsNotNull(Recipe.Deserialize(reader));
            }
        }

        [TestMethod()]
        public void LookupByTitleTest()
        {
            RecipeBookTest.recipe.Add(RecipeTest);
            RecipeBookTest.recipe.Add(RecipeTest1);
            Assert.IsNotNull(RecipeBookTest.LookupByTitle("shenisel"));
            Assert.IsNull(RecipeBookTest.LookupByTitle("pizza"));
        }

        [TestMethod()]
        public void LookupByKeywordTest()
        {
            RecipeBookTest.recipe.Add(RecipeTest);
            RecipeBookTest.recipe.Add(RecipeTest1);
            Assert.IsNotNull(RecipeBookTest.LookupByKeyword("ghorme"));
            List<Recipe> FindByK = RecipeBookTest.LookupByKeyword("ghorme");
            Assert.AreEqual(FindByK.Count,1);
            Assert.IsNotNull(RecipeBookTest.LookupByKeyword("ghorme"));
        }

        [TestMethod()]
        public void LookupByCuisineTest()
        {
            RecipeBookTest.recipe.Add(RecipeTest);
            Assert.IsNotNull(RecipeBookTest.LookupByCuisine("khanegi"));
            List<Recipe> FindByC = RecipeBookTest.LookupByCuisine("khanegi");
            Assert.AreEqual(FindByC.Count, 1);
        }

        [TestMethod()]
        public void LoadTest()
        {
            RecipeBookTest.recipe.Add(RecipeTest);
            RecipeTest.ingredientlist.Add(IngrediantTest);
            RecipeBookTest.Save(@"recipe.txt");
            Assert.IsTrue(RecipeBookTest.Load(@"recipe.txt"));
            Assert.IsFalse(RecipeBookTest.Load(@"Null.txt"));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            RecipeBookTest.recipe.Add(RecipeTest);
            RecipeBookTest.recipe.Add(RecipeTest1);
            int capacity = RecipeBookTest.recipe.Count;
            Assert.AreEqual(RecipeBookTest.recipe.Count,capacity);
            Assert.IsFalse(RecipeBookTest.Remove("kabab"));
            Assert.AreEqual(capacity, RecipeBookTest.recipe.Count);
            Assert.IsTrue(RecipeBookTest.Remove("shenisel"));
        }
    }
  }
