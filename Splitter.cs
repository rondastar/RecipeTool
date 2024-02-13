using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTool
{
    public static class Splitter
    {
        /// <summary>
        /// splits a line from a recipe into separate elements
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        internal static LinkedListDoubly<string> SplitRecipeLine(string s)
        {
            // recipe elements is made up of recipe lines, which are made up of strings split by spaces
            LinkedListDoubly<string> recipeElements = new LinkedListDoubly<string>();


            // keep track of the start of the current element being split
            int indexElementStart = 0;

            for (int i = 0; i < s.Length; i++)
            {
                //LinkedListSingly<string> recipeLine = new LinkedListSingly<string>();

                //// if the current index is a line break
                //if (s[i] == '\n')
                //{
                //    recipeElements.Add(recipeLine);
                //}

                // if the current index is a space or slash
                if (s[i] == ' ' || s[i]=='/')
                {
                    // create an array to hold the element ending before the space or slash
                    char[] element = new char[i - indexElementStart];

                    // iterate through the element and add each character to array
                    for (int j = indexElementStart; j < i; j++)
                    {
                        element[j - indexElementStart] = s[j];
                    }

                    Console.WriteLine(element);
                    string stringElement = new string(element);
                    recipeElements.Add(stringElement);

                    // if the current index is a slash, add it as a separate element
                    // this is separated to make is easier to identify and process fractions
                    if (s[i]=='/')
                    {
                        // create an array to hold the slash
                        string slash = "/";

                        Console.WriteLine(slash);
                        recipeElements.Add(slash);
                    }

                    // Start the next element after the space
                    indexElementStart = i + 1;
                    i++;
                }

                // if it is the end of the string
                else if (i == s.Length - 1)
                {
                    // create an array to hold the current element
                    char[] element = new char[i + 1 - indexElementStart];

                    // iterate through the current element and add each character to array
                    for (int j = indexElementStart; j <= i; j++)
                    {
                        element[j - indexElementStart] = s[j];
                    }

                    Console.WriteLine(element);
                    string stringElement = new string(element);
                    recipeElements.Add(stringElement);
                }

            }

            return recipeElements;

        }


    }
}
