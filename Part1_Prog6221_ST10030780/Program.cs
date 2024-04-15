using System;

namespace RecipeApp
{
    class Program
    {
        static Recipe currentRecipe = new Recipe();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nWelcome to RecipeApp!");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear All Data");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            EnterRecipeDetails();
                            break;
                        case 2:
                            DisplayRecipe();
                            break;
                        case 3:
                            ScaleRecipe();
                            break;
                        case 4:
                            ResetQuantities();
                            break;
                        case 5:
                            ClearAllData();
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                }
            }
        }

        static void EnterRecipeDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            currentRecipe.Ingredients = new Ingredient[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter quantity of {name}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                currentRecipe.Ingredients[i] = new Ingredient(name, quantity, unit);
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            currentRecipe.Steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                currentRecipe.Steps[i] = Console.ReadLine();
            }

            Console.WriteLine("Recipe details entered successfully.");
        }

        static void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe Details:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in currentRecipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < currentRecipe.Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {currentRecipe.Steps[i]}");
            }
        }

        static void ScaleRecipe()
        {
            Console.Write("Enter scaling factor (0.5 for half, 2 for double, 3 for triple): ");
            double factor = double.Parse(Console.ReadLine());

            foreach (var ingredient in currentRecipe.Ingredients)
            {
                ingredient.Quantity *= factor;
            }

            Console.WriteLine("Recipe scaled successfully.");
        }

        static void ResetQuantities()
        {
            // Reset quantities to original values
            currentRecipe.ResetQuantities();
            Console.WriteLine("Quantities reset to original values.");
        }

        static void ClearAllData()
        {
            currentRecipe = new Recipe();
            Console.WriteLine("All data cleared.");
        }
    }

    class Recipe
    {
        public Ingredient[] Ingredients { get; set; }
        public string[] Steps { get; set; }

        public void ResetQuantities()
        {
            // Reset quantities to original values
        }
    }

    class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}

