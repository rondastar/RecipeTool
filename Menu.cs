using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTool
{
    internal class Menu
    {
        public static void Display()
        {
            bool menuLoop = true;
            while (menuLoop)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1 - Temp: Celsius to Fahrenheit");
                Console.WriteLine("2 - Temp: Fahrenheit to Celsius");
                Console.WriteLine("3 - Recipe");
                // The additional options are ideas for future functions
                //Console.WriteLine("3 - Ingredients: Convert US units to grams");
                //Console.WriteLine("4 - Recipe: Scale by pan size");
                //Console.WriteLine("5 - Recipe: Scale by servings");
                Console.WriteLine("e - Exit");
                Console.Write("Enter selection: ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        // 1 - Temp: Celsius to Fahrenheit
                        // Prompts user for temperature to convert; returns converted temp in Fahrenheit
                        Console.WriteLine("Convert Temperature: Celsius to Fahrenheit");
                        double tempF = CelsiusToFahrenheitConversion(TemperatureToConvert());
                        Console.WriteLine($"{tempF} degrees F");
                        break;
                    case "2":
                        // 2 - Temp: Fahrenheit to Celsius
                        // Prompts user for temperature to convert; returns converted temp in Celsius
                        Console.WriteLine("Convert Temperature: Fahrenheit to Celsius");
                        double tempC = FahrenheitToCelsius(TemperatureToConvert());
                        Console.WriteLine($"{tempC} degrees C");
                        break;
                    //case "3":
                    //    // 3 - Ingredients: Convert US units to grams
                    //    break;
                    //case "4":
                    //    // 4 - Recipe: Scale by pan size
                    //    break;
                    //case "5":
                    //    // 5 - Recipe: Scale by servings
                    //    break;
                    case "e":
                        // exit menu - turn off loop
                        Console.WriteLine("Good bye");
                        menuLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }
            }
        }
        public static double TemperatureToConvert()
        {
            // Prompts user to enter a temperature to convert
            Console.WriteLine("Enter temperature to convert: ");
            double temp = -1;
            bool parseUserTemp = double.TryParse(Console.ReadLine(), out double userTemp);
            if (parseUserTemp == true)
            {
                temp = userTemp;
            }
            else
            {
                // User input was not a float. Displays request to re-enter temperature.
                Console.WriteLine("Invalid entry. Please re-enter the temperature.");
            }
            return temp;
        }
        public static double CelsiusToFahrenheitConversion(double celsius)
        {
            // converts degrees celsius to fahrenheit, returns degrees fahrenheit
            double fahrenheit = celsius * (double)1.8 + 32;
            return fahrenheit;
        }
        public static double FahrenheitToCelsius(double fahrenheit)
        {
            // converts degrees fahrenheit to celsius, returns degrees celsius
            double celsius = (fahrenheit - 32) / 1.8;
            return celsius;
        }
        public static float BakingPanAreaRecipe()
        {
            Console.WriteLine("Enter the dimensions of the baking pan in the recipe");
            Console.Write("Length: ");
            if (float.TryParse(Console.ReadLine(), out float panLengthRecipe)) ;
            else
            {
                Console.WriteLine("Please enter a valid number.");
                BakingPanAreaRecipe();
            }
            Console.Write("Width: ");
            if (float.TryParse(Console.ReadLine(), out float panWidthRecipe)) ;
            else
            {
                Console.WriteLine("Please enter a valid number.");
                BakingPanAreaRecipe();
            }
            float bakingPanAreaRecipe = panLengthRecipe * panWidthRecipe;
            return bakingPanAreaRecipe;
        }
        public static void BakingPanRecipeScaler()
        {
            Console.Write("Enter the dimensions of the pan you would like to use");
            Console.Write("Length: ");
            if (double.TryParse(Console.ReadLine(), out double panLengthDesired)) ;
            else
            {
                Console.WriteLine("Please enter a valid number.");
                BakingPanRecipeScaler();
            }
            Console.Write("Width: ");
            if (double.TryParse(Console.ReadLine(), out double panWidthDesired)) ;
            else
            {
                Console.WriteLine("Please enter a valid number.");
                BakingPanRecipeScaler();
            }
        }
    }
}
