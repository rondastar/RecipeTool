﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTool
{
    internal class IngredientLine
    {
        private Quantity _qty;
        private Unit _unit;
        private Ingredient _ingredient;

        internal Quantity Qty { get => _qty; set => _qty = value; }
        internal Unit Unit { get => _unit; set => _unit = value; }
        internal Ingredient Ingredient { get => _ingredient; set => _ingredient = value; }

        public IngredientLine()
        {
        } // default constructor
        public IngredientLine(Quantity qty, Unit unit, Ingredient ingredient)
        {
            Qty = qty;
            Unit = unit;
            Ingredient = ingredient;
        }

        public IngredientLine(Quantity qty, Ingredient ingredient)
        {
            Qty = qty;
            Ingredient = ingredient;
        }

        public IngredientLine(Ingredient ingredient) { Ingredient = ingredient; }

        internal static IngredientLine SortIngredientLine(LinkedListDoubly<string> lineString)
        {
            // these fields are used to store the parts of the ingredient line until they are used in their respective constructors
            double number = -1;      // used if there is a quantity with a decimal
            int whole = -1;          // used if the quantity is a whole number
            int numerator = -1;      // used if quantity contains a fraction
            int denominator = -1;    // used if quantity contains a fraction

            bool isDouble = false;          // true indicates quantity is a number with a decimal
            bool isWholeNumber = false;     // true indicates quantity is a whole number
            bool isFraction = false;        // true indicates quantity is a fraction
            bool isMixedNumber = false;     // true indicates quantity is a mixed number

            bool isKnownQuantity = false;   // true indicates the quantity is a double, whole number, fraction, or mixed number
            bool isQuantityLoopComplete = false;    // true indicates the quantity loop has run

            bool isKnownUnit = false;   // true indicates there is a unit

            string unit = "";
            string ingredient = "";

            string[] unitNames = { "C", "cup", "T", "tablespoon", "tsp", "teaspoon", "grams" };

            while (lineString != null)
            {
                // runs until the quantity is determined
                do
                {
                    // checks if the first element is an integer
                    if (int.TryParse(lineString[0], out int j))
                    {
                        // runs if quantity is a fraction
                        if (lineString[1] == "/")
                        {
                            int.TryParse(lineString[2], out int k);
                            numerator = j;
                            denominator = k;
                            isFraction = true;
                            isKnownQuantity = true;

                            // remove the first 3 elements, which make up the fraction
                            lineString.RemoveAtFront();
                            lineString.RemoveAtFront();
                            lineString.RemoveAtFront();
                        }
                        // runs if quantity is a mixed number
                        else if (lineString[2] == "/")
                        {
                            int.TryParse(lineString[1], out int k);
                            int.TryParse(lineString[3], out int l);
                            whole = j;
                            numerator = k;
                            denominator = l;
                            isMixedNumber = true;
                            isKnownQuantity = true;

                            // remove the first 4 elements, which make up the mixed number
                            lineString.RemoveAtFront();
                            lineString.RemoveAtFront();
                            lineString.RemoveAtFront();
                            lineString.RemoveAtFront();
                        }
                        else // if there is no fraction, the element is a whole number
                        {
                            whole = j;
                            isWholeNumber = true;
                            isKnownQuantity = true;

                            lineString.RemoveAtFront(); // removes the number
                        }
                    }
                    // runs if first element is a number with a decimal
                    else if (double.TryParse(lineString[0], out double m))
                    {
                        number = m;
                        isDouble = true;
                        isKnownQuantity = true;

                        lineString.RemoveAtFront();
                        // removes the number
                    }
                    // quantity is known - quantity bools are all up-to-date
                    isQuantityLoopComplete = true;

                    // checks whether new head is a unit
                    // ==================== this needs to be more sophisticated to encompass all possible
                    // units and check more efficiently =================================================
                    for (int i = 0; i < unitNames.Length; i++)
                    {
                        if (unitNames[i] == lineString[0])
                        {
                            unit = unitNames[i];
                            isKnownUnit = true;
                        }
                    }

                } while (!isQuantityLoopComplete);

                //ingredient += lineString[0];
            }

            IngredientLine sortedIngredientLine;
            Ingredient recipeIngredient = new Ingredient(ingredient);

            if(isKnownQuantity)
            {
                Quantity quantity;

                if (isKnownUnit) // has unit
                {
                    Unit recipeUnit = new Unit(unit);
                    if (isWholeNumber)
                    {
                        quantity = new Quantity(whole);
                    }
                    else if (isFraction)
                    {
                        quantity = new Quantity(numerator, denominator);
                    }
                    else if (isMixedNumber)
                    {
                        quantity = new Quantity(whole, numerator, denominator);
                    }
                    else // runs if quantity is a double
                    {
                        quantity = new Quantity(number);
                    }
                    
                    // ingredient line with quantity, unit, and ingredient
                    sortedIngredientLine = new IngredientLine(quantity, recipeUnit, recipeIngredient);
                    return sortedIngredientLine;
                }
                else // no unit
                {
                    if (isWholeNumber)
                    {
                        quantity = new Quantity(whole);
                    }
                    else if (isFraction)
                    {
                        quantity = new Quantity(numerator, denominator);
                    }
                    else if (isMixedNumber)
                    {
                        quantity = new Quantity(whole, numerator, denominator);
                    }
                    else // runs if quantity is a double
                    {
                        quantity = new Quantity(number);
                    }

                    // ingredient line with quantity and ingredient only
                    sortedIngredientLine = new IngredientLine(quantity, recipeIngredient);
                    return sortedIngredientLine;

                }

            } // if(isKnownQuantity)

            sortedIngredientLine = new IngredientLine(recipeIngredient);
            return sortedIngredientLine;
        } // SortIngredientLine
    }
}
