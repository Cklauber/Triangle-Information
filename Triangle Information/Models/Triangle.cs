using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_Information
{
    /*
     * This will be our triangle model
     */
    class Triangle
    {
        private int[] sides = new int[3];
        public Triangle(int value1, int value2, int value3)
        {
            sides[0] = value1;
            sides[1] = value2;
            sides[3] = value3;
        }
        /*
         * A triangle is valid if the sum of smaller sides are bigger than the bigger side
         */
        public bool isValid()
        {
            bool valid = false;
            decimal biggerSide = sides.Max();
            decimal sumOfSmallerSides = sides.Except(sides.Where(a => a == biggerSide)).Sum();
            if(sumOfSmallerSides > biggerSide)
            {
                valid = true;
            }
            return valid;
        }

    }
}
