using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_Service
{
    internal class MathService
    {
        public double ReturnAddition(double num1, double num2)
        {

            return num1 + num2;
        }

        public double ReturnSubtraction(double num1, double num2)
        {
            return num1 - num2;
        }

        public double ReturnMultiplication(double num1, double num2)
        {
            var product = num1 * num2;
            return product;
        }

        public double ReturnDivision(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}
