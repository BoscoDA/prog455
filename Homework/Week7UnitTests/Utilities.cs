using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Week7UnitTests
{
    public class Utilities
    {
        //A Method that takes a double and return the floor of that number
        public double FloorDouble(double num)
        {
            var floor = Math.Floor(num);
            return floor;
        }

        //A Methods that takes 2 strings (first name and last name )
        //and returns a string that joins them with a comma in between
        public string JoinName(string firstName, string lastName)
        {
            if(firstName.Length == 0)
            {
                firstName = "John";
            }

            if(lastName.Length == 0)
            {
                lastName = "Doe";
            }

            return firstName + "," + lastName;
        }

        //A  Method for password hashing that takes a string and returns a hash
        public string CreateHash(string password)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                var bytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        //A  Method that takes in an integer and returns a bool whether the number is prime or not
        public bool IsPrime(int num)
        {
            if (num <= 0)
            {
                return false;
            }

            for (int i = 2; i < (int)(Math.Sqrt(num) + 1); i++)
            {
                if(num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //A Method that takes in an integer and returns all it's positive none-prime divisors
        public List<int> GenerateDivisors(int num)
        {
            List<int> divisors = new List<int>();

            if(num < 0)
            {
                num *= -1;
            }

            for (int i = 2; i < (int)(Math.Sqrt(num) + 1); i++)
            {
                if (num % i == 0)
                {
                    int temp = num / i;
                    if (IsPrime(temp) != true && divisors.Contains(temp) != true)
                    {
                        divisors.Add(temp);
                    }

                    if (IsPrime(i) != true && divisors.Contains(i) != true)
                    {
                        divisors.Add(i);
                    }
                }
            }

            if (divisors.Count > 0)
            {
                divisors.Add(num);
            }

            return divisors.OrderBy(i => i).ToList();
        }

        //A Method that takes 2 integers and returns the floor of the result from dividing the largest number
        //of the two by the other number
        public double CalcFloor(int num1, int num2)
        {

            double numerator = num1 > num2 ? num1 : num2;
            double denominator = num1 > num2 ? num2 : num1;

            return FloorDouble(numerator / denominator);

        }

        //A method that takes in an integer and calculates all of it's positive none-prime divisors, then adds them to a dictionary ordered from smallest to largest.
        //You must use only odd numbers for your dictionary keys (1,3,5,7...n where n is always odd )
        public Dictionary<int, int> CreateDictionaryOfDivisors(int num)
        {
            Dictionary<int, int> divisors = new Dictionary<int, int>();
            int key = 1;

            foreach(int i in GenerateDivisors(num))
            {
                divisors.Add(key, i);
                key += 2;
            }

            return divisors;
        }
    }
}
