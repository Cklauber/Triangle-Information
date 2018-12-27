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
        public void setValue1(int value1)
        {
            sides[0] = value1;
        }
        public void setValue2(int value2)
        {
            sides[1] = value2;
        }
        public void setValue3(int value3)
        {
            sides[2] = value3;
        }
        /*
         * A triangle is valid if the sum of two sides are greater than the other side
         */
        public bool isValid()
        { 
            bool valid = false;
            if(sides[0] + sides[1] > sides[2] && sides[1] + sides[2] > sides[0] && sides[2] + sides[0] > sides[2])
            {
                valid = true;
            }
            return valid;
        }
        public string getTriangleType()
        {
            if (this.isValid())
            {
                string type = "Triangle";
                int biggerSide = sides.Max();
                int[] bc = sides.Except(sides.Where(a => a == biggerSide)).ToArray();
                try
                {
                    if (Math.Pow(biggerSide, 2) == (Math.Pow(bc[0], 2) + Math.Pow(bc[1], 2)))
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
                if (sides[0] == sides[1] || sides[1] == sides[2] || sides[0] == sides[2])
                {
                    type = "Isosceles";
                    return type;
                }

                return type;
            }
            else return "";

        }

    }
}
