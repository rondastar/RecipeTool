using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace RecipeTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu.Display();
            Test();

        }

        public static void Test()
        {
            // Test Splitter.SplitRecipeLine ---- splits a recipe line in string format into separate elements,
            // using ' ' and '/' as delimiters. '/' is used to identify fractions.
            // Prints each element on a separate line for testing purposes <<======================================================== REMOVE WRITELINES AFTER FINAL TESTING

            // ----- Test 1
            LinkedListDoubly<string> recipeElements =
                Splitter.SplitRecipeLine("16 2/3 C crushed tomatoes");

            Console.WriteLine(recipeElements.Count); // 7
            recipeElements.DisplayForward(); // 16 2 / 3 C crushed tomatoes
            Console.WriteLine();

            // ----- Test 2
            LinkedListDoubly<string> recipeElements2 =
                Splitter.SplitRecipeLine("a pinch of salt");

            Console.WriteLine(recipeElements2.Count); // 4
            recipeElements2.DisplayForward(); // a pinch of salt
            Console.WriteLine();


            // ----- Test 3
            LinkedListDoubly<string> recipeElements3 =
                Splitter.SplitRecipeLine("3 tablespoons oregano");

            Console.WriteLine(recipeElements3.Count); // 7
            recipeElements3.DisplayForward(); // 16 2 / 3 C crushed tomatoes
            Console.WriteLine();


            // Test IngredientLineSorter.SortIngredientLine --- displays recipe IngredientLine as Quantity, Unit, and Ingredient

            // ----- Test 1
            TestIngredientLineSorter(recipeElements);
            Console.WriteLine();


            // ----- Test 2
            TestIngredientLineSorter(recipeElements2);
            Console.WriteLine();


            // ----- Test 3
            TestIngredientLineSorter(recipeElements3);
            Console.WriteLine();


        }

        public static IngredientLine TestIngredientLineSorter(LinkedListDoubly<string> ingredientLine)
        {
            // Displays all elements in the ingredient line
            IngredientLine sortedIngredientLine = new IngredientLine();
            sortedIngredientLine = IngredientLineSorter.SortIngredientLine(ingredientLine);

            // Display quantity, using string literal unless null
            if(sortedIngredientLine.Qty == null)
            {
                Console.WriteLine($"Quantity: null");
            }
            else
            {
                Console.WriteLine($"Quantity: {sortedIngredientLine.Qty}");
            }

            // Display unit, using string literal unless null
            if (sortedIngredientLine.Unit == null)
            {
                Console.WriteLine($"Unit: null");
            }
            else
            {
                Console.WriteLine($"Unit: {sortedIngredientLine.Unit.Name}");
            }

            // Display ingredient using string literal
            Console.WriteLine($"Ingredient: {sortedIngredientLine.Ingredient.Name}");

            return sortedIngredientLine;
        }
    }
}
