using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_Service
{
    internal class MessageService
    {
        MathService mathService = new MathService();

        public string ReturnCalculationMessage(string num1, string num2)
        {
            double validNum1;
            double validNum2;

            if (!Double.TryParse(num1, out validNum1) || !Double.TryParse(num2, out validNum2))
            {
                return $"Invalid Input!";
            }

            double sum = mathService.ReturnAddition(validNum1, validNum2);
            double difference = mathService.ReturnSubtraction(validNum1, validNum2);
            double product = mathService.ReturnMultiplication(validNum1, validNum2);
            double quotient = mathService.ReturnDivision(validNum1, validNum2);

            var newMessage = $@"{num1}+{validNum2}={sum}
{validNum1}-{validNum2}={difference}
{validNum1}*{validNum2}={product}
{validNum1}/{validNum2}={quotient}";
            return newMessage;
        }
    }
}
