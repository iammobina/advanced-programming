using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        private const string ReceipeFilePath = @"C:\Git\96522321\myFirstProject\Assignment6\Assignment5\Assignment5\recipe.txt";
        FileStream txtfile = new FileStream("recipe.txt",FileMode.Open);
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
                        Console.WriteLine("Your recipe added successfully !");
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
                            
                            case ConsoleKey.C:
                                Console.WriteLine($"Please enter a cuisine that you want to search:");
                                Show(fromMom.LookupByCuisine(Console.ReadLine()));
                                break;
                            case ConsoleKey.K:
                                Console.WriteLine($"Please enter a keyword that you want to search");
                                Show(fromMom.LookupByKeyword(Console.ReadLine()));
                                break;
                            case ConsoleKey.T:
                                Console.WriteLine($"Please enter a title that you want to search:");
                                Show(fromMom.LookupByTitle(Console.ReadLine()));
                                break;
                        }
                        break;
                    case ConsoleKey.L:
                        Console.WriteLine("List Recipes");
                        // بر عهده دانشجو
                        for (int i = 0; i < fromMom.recipe.Length; i++)
                        {
                            if (fromMom.recipe[i] == null)
                            continue;
                            else
                                Show(fromMom.recipe[i]);
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Esc");
                        break;

                    case ConsoleKey.V:
                        fromMom.Save(ReceipeFilePath);
                        break;
                    case ConsoleKey.O:
                        fromMom.Load(ReceipeFilePath);
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
            string[] keywords = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
            Ingredient[] ingredients = new Ingredient [ingredientCount];
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine("Please name the ingredient:");
                string name = Console.ReadLine();
                Console.WriteLine("Please write about this ingredient:");
                string ingdescription = Console.ReadLine();
                Console.WriteLine("Please write about it's quantity:");
                double quantity = double.Parse(Console.ReadLine());
                Console.WriteLine("Please write about it's unit:");
                string unit = Console.ReadLine();
                ingredients[i] = new Ingredient(name, ingdescription, quantity, unit);
            }
            Recipe foods = new Recipe(title, description, ingredientCount, servCount, cuisine, keywords);
           for (int i = 0; i < ingredients.Length; i++)
                foods.AddIngredient(ingredients[i]);
            return foods;

        }
    }
}
