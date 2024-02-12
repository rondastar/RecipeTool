using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTool
{
    internal class Unit
    {
        private string _name;

        public Unit(string name)
        {
            _name = name;
        }

        public string Name { get => _name; set => _name = value; }
    }
}
