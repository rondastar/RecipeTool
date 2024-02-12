using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTool
{
    internal class Ingredient
    {
        private string name;

        public Ingredient(string name)
        {
            this.name = name;
        }

        internal string Name { get => name; set => name = value; }
    }
}

