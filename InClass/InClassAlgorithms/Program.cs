using System.Security.Cryptography.X509Certificates;

namespace InClassAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pythag();

            NumberPattern(7);

            MaxMin("When the fox jumped on the box. The horse started speaking Norse; And the chicken crossed the street");
            
            Console.ReadKey();
        }

        static void Pythag()
        {
            //a^2 + b^2 = c^2 a > 0, a < b, c >b, c>a
            int found = 0;

            int iter = 0;
            while (found < 1)
            {
                for (int a = 1; a < 10000000; a++)
                {
                    iter++;
                    for (int b = a + 1; b < (a * a); b++)
                    {
                        iter++;
                        
                        var c = Convert.ToInt64(Math.Sqrt((a * a) + (b * b)));
                        if ((a * a) + (b * b) == (c * c))
                        {
                            found++;
                            Console.WriteLine($"{a},{b},{c}: {iter}");
                        }

                        if (found == 10)
                        {
                            break;
                        }

                    }
                    if (found == 10)
                    {
                        break;
                    }
                }
            }
        }

        static void NumberPattern(int N)
        {
            int level = 0;
            for(int i = N; i > 0; i--)
            {
                if(i == N)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    int temp = 0;
                    for (int j = N - level; j < N; j++)
                    {
                        Console.Write(j);
                        temp = j + 1;
                    }

                    for (int k = 0; k <= level; k++)
                    {
                        Console.Write(N-k);
                    }

                    Console.WriteLine("");
                }

                level++;
            }
        }

        static void MaxMin(string input)
        {
            
            string temp = input.ToLower();
            Dictionary<char,int> map = new Dictionary<char,int>();
            foreach(char chr in temp)
            {
                if(chr != ' ' && chr != '.' && chr != ',' && chr != ';')
                {
                    if (!map.ContainsKey(chr))
                    {
                        map.Add(chr, 0);
                    }

                    map[chr]++;
                }
                
            }

            char min = map.MinBy(x => x.Value).Key;
            char max = map.MaxBy(x => x.Value).Key;

            //foreach(KeyValuePair<char, int> pair in map)
            //{
            //    Console.WriteLine($"{pair.Key}: {pair.Value}");
            //}

            Console.Write($"Minimum occuring char: ");
            foreach (KeyValuePair<char, int> pair in map)
            {
                if (pair.Value == map[min])
                {
                    Console.Write(pair.Key);
                }
            }

            Console.WriteLine(":" + map[min]);

            Console.WriteLine($"");

            Console.Write($"Maximum occuring char: ");
            foreach (KeyValuePair<char, int> pair in map)
            {
                if (pair.Value == map[max])
                {
                    Console.Write(pair.Key);
                }
            }

            Console.WriteLine(":" + map[max]);
        }

        static void River(int a, int b, int c, int d)
        {
            // boat travels at the speed of the slowest person
            //3, 6, 9, 7
            // (3,9) 9 fastest, slowest
            // (3) 12 fastest
            // (3,7) 19 fastest, slowest
            // (3) 22 fastest
            // (3,6) 28 fastest, slowest



            List<KeyValuePair<string, int>> right = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> left = new List<KeyValuePair<string, int>>();

            int maxtime = 30;
            int currentTime = 0;

            while(currentTime < maxtime)
            {
                string rightCur = "";
                foreach(KeyValuePair<string, int> pair in right)
                {
                    rightCur += pair.Key + " ";
                }

                string leftCur = "";
                foreach (KeyValuePair<string, int> pair in left)
                {
                    leftCur += pair.Key + " ";
                }

                Console.WriteLine(rightCur);
                Console.WriteLine(leftCur);

                //cross
                string fastest = right.MaxBy(x => x.Value).Key;
                string slowest = right.MinBy(x => x.Value).Key;
                int time = right.MaxBy(x => x.Value).Value;

                Console.WriteLine($"{fastest} and {slowest} cross to the left. Takes {time} minutes");
                currentTime += time;
                //return

            }

        }
    }
}