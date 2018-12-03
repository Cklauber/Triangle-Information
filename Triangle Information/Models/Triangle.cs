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
            sides[2] = value3;
        }
        /*
         * A triangle is valid if the sum of smaller sides are bigger than the bigger side
         */
        public bool isValid()
        { 
            bool valid = false;
            if(sides[0] + sides[1] > sides[2] || sides[1] + sides[2] > sides[0] || sides[2] + sides[0] > sides[2])
            {
                valid = true;
            }




            //int biggerSide = sides.Max();
            //int sumOfSmallerSides = sides.Except(sides.Where(a => a == biggerSide)).Sum();
            //System.Diagnostics.Debug.WriteLine("Bigger side " + biggerSide);
            //System.Diagnostics.Debug.WriteLine("Sum of smaller sides " + sumOfSmallerSides);
            //if (sumOfSmallerSides > biggerSide)
            //{
            //    valid = true;
            //}
            //if(sides[0] == sides[1] & sides[1] == sides[2])
            //{
            //    valid = true;
            //}
            return valid;
        }
        public string triangleType()
        {
            string type = "Triangle";
            try
            {
                int biggerSide = sides.Max();
                int[] bc = sides.Except(sides.Where(a => a == biggerSide)).ToArray();
                if (Math.Pow(biggerSide, 2) == Math.Pow(bc[0],2) + Math.Pow(bc[2], 2))
                {
                    type = "Right";
                    return type;
                }
            }
            catch
            {
                //Not a right triangle.
            }
            if (sides[0] == sides[1] & sides[1] == sides[2])
            {
                type = "Equilateral";
                return type;
            }
            if (sides[0] == sides[1] || sides[1] == sides[2] || sides[0] == sides[1])
            {
                type = "Isosceles";
                return type;
            }

            return type;
        }

    }
}
