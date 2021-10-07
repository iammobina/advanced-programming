using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
      public class Program 
    {
        public const string receipeFilePath = @"C:\Git\96522321\myFirstProject\Assignment6\Assignment5\Assignment5\recipe.txt";
        static void Main(string[] args)
        {
            RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 20);
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine($"Press (N)ew, (D)el, (S)earch, (L)ist, sa(V)e or l(O)ad");
                cki = Console.ReadKey();
                Console.WriteLine();
                
                switch (cki.Key)
                {
                    case ConsoleKey.N:
                        Console.WriteLine("New Recipe");
                        // بر عهده دانشجو
                        Recipe foods = GetRecipeFromInput();
                        fromMom.Add(foods);
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("Delete Recipe");
                        // بر عهده دانشجو
   
                        Console.WriteLine("Are you sure you want to delete your recipe? press Y(for Yes) OR  N(for No)");
                        cki = Console.ReadKey();
                        Console.WriteLine();
                        switch (cki.Key)
                        {
                            case ConsoleKey.Y:
                                Console.WriteLine("Plese Enter the title of Recipe");
                                fromMom.Remove(Console.ReadLine());
                                Console.WriteLine("Your recipe removed successfully !");
                                break;
                            case ConsoleKey.N:
                                Console.WriteLine("Your recipe still exist !");
                                break;
                        }
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Search Recipe");
                        // بر عهده دانشجو
                        Console.WriteLine("How do you want to search? By cuisine(C) or keyword(K) or title(T)?");
                        cki = Console.ReadKey();
                        Console.WriteLine();
                        switch (cki.Key)
                        {
                            case ConsoleKey.T:
                                Console.WriteLine($"Please enter a title that you want to search:");
                                Show(fromMom.LookupByTitle(Console.ReadLine()));
                                break;
                            case ConsoleKey.C:
                                Console.WriteLine($"Please enter a cuisine that you want to search:");
                                List<Recipe> FindByC = fromMom.LookupByCuisine(Console.ReadLine());
                                for (int i = 0; i < FindByC.Count; i++)
                                    Show(FindByC[i]);
                                break;
                            case ConsoleKey.K:
                                Console.WriteLine($"Please enter a keyword that you want to search");
                                List<Recipe> FindByK = fromMom.LookupByKeyword(Console.ReadLine());
                                for (int i = 0; i < FindByK.Count; i++)
                                    Show(FindByK[i]);
                                break;
                            
                        }
                        break;
                    case ConsoleKey.L:
                        Console.WriteLine("List Recipes");
                        // بر عهده دانشجو
                        foreach (var recipe in fromMom.recipe)
                            Show(recipe);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Esc");
                        break;

                    case ConsoleKey.V:
                        fromMom.Save(receipeFilePath);
                        break;
                    case ConsoleKey.O:
                        fromMom.Load(receipeFilePath);
                        Console.WriteLine("Hold on a second!Your txt file will be open:");
                        System.Diagnostics.Process.Start("Explorer", @"C:\Git\96522321\myFirstProject\Assignment6\Assignment5\Assignment5\recipe.txt");
                        break;
                    default:
                        Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                        break;
                }

                Console.WriteLine("Press any key to continue, Esc to exit");
                cki = Console.ReadKey();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Escape);
        }
        public static bool Show(Recipe recipe)
        {
            Console.WriteLine(recipe.ToString());
            return true;
        }

        public static Recipe GetRecipeFromInput()
        {
            Console.WriteLine("Please name the food :");
            string title = Console.ReadLine();
            Console.WriteLine("Please write about this food:");
            string description = Console.ReadLine();
            Console.WriteLine("How many ingredients do you have?");
            int ingredientCount = int.Parse(Console.ReadLine());
            Console.WriteLine("How many people can use this food?");
            int servCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Please write about cuisine of the food:");
            string cuisine = Console.ReadLine();
            Console.WriteLine("Please Enter a Keyword:");
            List<string> keywords = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<Ingredient> ingredients = new List<Ingredient>();
            Ingredient ingredient1 = new Ingredient();
            for (int i = 0; i < ingredients.Count; i++)
            {
                Console.WriteLine("Please name the ingredient:");
                ingredient1.Name = Console.ReadLine();
                Console.WriteLine("Please write about this ingredient:");
                ingredient1.Description = Console.ReadLine();
                Console.WriteLine("Please write about it's quantity:");
                ingredient1.Quantity = double.Parse(Console.ReadLine());
                Console.WriteLine("Please write about it's unit:");
                ingredient1.Unit = Console.ReadLine();
                ingredients.Add(ingredient1);
            }
            Recipe foods = new Recipe(title, description, ingredients, servCount, cuisine, keywords);
            return foods;

        }
    }
}
