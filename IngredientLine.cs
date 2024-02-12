using System;
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

        public IngredientLine(Quantity qty, Unit unit, Ingredient ingredient)
        {
            _qty = qty;
            _unit = unit;
            _ingredient = ingredient;
        }

        public IngredientLine(Quantity qty, Ingredient ingredient)
        {
            _qty = qty;
            _ingredient = ingredient;
        }

        public IngredientLine(Ingredient ingredient) { _ingredient = ingredient; }
    }
}
