using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace RecipeTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu.Display();
            TestSingleLineSplitRecipe();
            //TestMultiLineSplitRecipe();

        }

        public static void TestSingleLineSplitRecipe()
        {
            LinkedListDoubly<char[]> recipeElements =
                Splitter.SplitRecipe("16 2/3 C tomatoes");

            Console.WriteLine(recipeElements.Count);
            recipeElements.DisplayForward();
        }

        //public static void TestMultiLineSplitRecipe()
        //{
        //    LinkedListSingly<LinkedListSingly<string>> recipeElements =
        //        Splitter.SplitRecipe("1 1/2 C tomatoes\n1 lb. ground beef\n1 onion\nsalt");

        //    Console.WriteLine(recipeElements.Count);
        //}
    }
}
