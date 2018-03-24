using System;
namespace Assignment5
{
    class Program
    {
       static void Main(string[] args)
        {
            RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 20);

            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine($"Press N(ew), D(el), S(earch)or L(ist)");
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
                        for (int i = 0; i < fromMom.listrecipe.Length; i++)
                        {
                            if (fromMom.listrecipe[i] == null)
                            continue;
                            else
                                Show(fromMom.listrecipe[i]);
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Esc");
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
            int ingCount = int.Parse(Console.ReadLine());
            Console.WriteLine("How many people can use this food?");
            int servCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Please write about cuisine of the food:");
            string cuisine = Console.ReadLine();
            Console.WriteLine("Please Enter a Keyword:)");
            string[] keywords = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
            Ingredient[] eachnewingredient = new Ingredient [ingCount];
            for (int i = 0; i < ingCount; i++)
            {
                Console.WriteLine("Please name the ingredient:");
                string name = Console.ReadLine();
                Console.WriteLine("Please write about this ingredient:");
                string ingdescription = Console.ReadLine();
                Console.WriteLine("Please write about it's quantity:");
                double quantity = double.Parse(Console.ReadLine());
                Console.WriteLine("Please write about it's unit:");
                string unit = Console.ReadLine();
                eachnewingredient[i] = new Ingredient(name, ingdescription, quantity, unit);
            }
            Recipe foods = new Recipe(title, description, servCount, ingCount, cuisine, keywords);
            for (int i = 0; i < ingCount; i++)
                foods.AddIngredient(eachnewingredient[i]);
            return foods;

        }
    }
}
