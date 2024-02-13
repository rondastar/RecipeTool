using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecipeTool
{
    internal class Quantity
    {
        private double _number;
        private int _whole;
        private int _numerator;
        private int _denominator;
        private string _qtyString;

        // default constructor
        public Quantity() { }

        // constructor for number (double) quantity
        public Quantity(double number) { _number = number; _qtyString = $"{_number}"; }

        // constructor for whole number quantity
        public Quantity(int whole) { _whole = whole; _qtyString = $"{_whole}"; }

        // constructor for fraction quantity
        public Quantity(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
            _qtyString = $"{_numerator}/{_denominator}";
        }

        // constructor for mixed number quantity
        public Quantity(int whole, int numerator, int denominator)
        {
            _whole = whole;
            _numerator = numerator;
            _denominator = denominator;
            _qtyString = $"{whole} {_numerator}/{_denominator}";
        }

        public int Whole { get => _whole; set => _whole = value; }
        public int Numerator { get => _numerator; set => _numerator = value; }
        public int Denominator { get => _denominator; set => _denominator = value; }
        public double Number { get => _number; set => _number = value; }
        public string QtyString { get => _qtyString; set => _qtyString = value; }

        public override string ToString()
        {
            return $"{ QtyString}";
        }
    }
}
