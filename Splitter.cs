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
        //// This splitter is from StackOverflow
        //// [https://stackoverflow.com/questions/4680128/split-a-string-with-delimiters-but-keep-the-delimiters-in-the-result-in-c-sharp#comment7390300_521172]
        ///// <summary>
        ///// Splits the given string into a list of substrings, while outputting the splitting
        ///// delimiters (each in its own string) as well. It's just like String.Split() except
        ///// the delimiters are preserved. No empty strings are output.</summary>
        ///// <param name="s">String to parse. Can be null or empty.</param>
        ///// <param name="delimiters">The delimiting characters. Can be an empty array.</param>
        ///// <returns></returns>
        //public static IList<string> SplitAndKeepDelimiters(this string s, params char[] delimiters)
        //{
        //    var parts = new List<string>();
        //    if (!string.IsNullOrEmpty(s))
        //    {
        //        int iFirst = 0;
        //        do
        //        {
        //            int iLast = s.IndexOfAny(delimiters, iFirst);
        //            if (iLast >= 0)
        //            {
        //                if (iLast > iFirst)
        //                    parts.Add(s.Substring(iFirst, iLast - iFirst)); //part before the delimiter
        //                parts.Add(new string(s[iLast], 1));//the delimiter
        //                iFirst = iLast + 1;
        //                continue;
        //            }

        //            //No delimiters were found, but at least one character remains. Add the rest and stop.
        //            parts.Add(s.Substring(iFirst, s.Length - iFirst));
        //            break;

        //        } while (iFirst < s.Length);
        //    }

        //    return parts;
        //}

        //internal static LinkedListSingly<LinkedListSingly<string>> SplitRecipe(string s)
        //{
        //    // recipe elements is meade up of recipe lines, which are made up of strings split by spaces
        //    LinkedListSingly<LinkedListSingly<string>> recipeElements = new LinkedListSingly<LinkedListSingly<string>>();


        //    // keep track of the start of the current element being split
        //    int indexElementStart = 0;

        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        LinkedListSingly<string> recipeLine = new LinkedListSingly<string>();

        //        // if the current index is a line break
        //        if (s[i] == '\n')
        //        {
        //            recipeElements.Add(recipeLine);
        //        }
        //        // if the current index is a space or if it is the end of the string
        //        else if (s[i] == ' ' || i == s.Length - 1)
        //        {
        //            // create an array to hold the new element
        //            char[] element = new char[i - indexElementStart];
        //            for (int j = indexElementStart; j < i; j++)
        //            {
        //                element[j] = s[j];
        //            }

        //            recipeLine.Add(element.ToString());
        //        }
        //    }


        //    return recipeElements;

        //}

         //========== THE BELOW METHOD WORKS TO SPLIT A SINGLE LINE, RETURNS TYPE CHAR[] ---- except last element cuts off final char ==========================
        internal static LinkedListDoubly<char[]> SplitRecipe(string s)
        {
            // recipe elements is made up of recipe lines, which are made up of strings split by spaces
            LinkedListDoubly<char[]> recipeElements = new LinkedListDoubly<char[]>();


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
                    recipeElements.Add(element);

                    // if the current index is a slash, add it as a separate element
                    // this is separated to make is easier to identify and process fractions
                    if (s[i]=='/')
                    {
                        // create an array to hold the slash
                        char[] slash = { s[i] };

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
                    recipeElements.Add(element);
                }

            }

            return recipeElements;

        }


    }
}
