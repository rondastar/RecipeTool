using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeTool
{
    internal class Quantity
    {
        private double _number;
        private int _whole;
        private int _numerator;
        private int _denominator;


        // constructor for number (double) quantity
        public Quantity(double number) { _number = number; }

        // constructor for whole number quantity
        public Quantity(int whole) { _whole = whole; }

        // constructor for fraction quantity
        public Quantity(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        // constructor for mixed number quantity
        public Quantity(int whole, int numerator, int denominator)
        {
            _whole = whole;
            _numerator = numerator;
            _denominator = denominator;
        }

        public int Whole { get => _whole; set => _whole = value; }
        public int Numerator { get => _numerator; set => _numerator = value; }
        public int Denominator { get => _denominator; set => _denominator = value; }
    }
}
